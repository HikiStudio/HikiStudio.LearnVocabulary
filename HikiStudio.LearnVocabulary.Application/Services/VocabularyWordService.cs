using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.AudioClips;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class VocabularyWordService : IVocabularyWordService
    {
        private readonly LanguageLearningDbContext _context;

        private readonly IAudioClipService _audioClipService;

        public VocabularyWordService(LanguageLearningDbContext context, IAudioClipService audioClipService)
        {
            _context = context;
            _audioClipService = audioClipService;
        }

        public async Task<APIResponse<bool>> CreateVocabularyWordAsync(CreateVocabularyWordRequest request)
        {
            var vocabularyType = await _context.VocabularyTypes.FirstOrDefaultAsync(x => x.VocabularyTypeID == request.VocabularyTypeID);
            if (vocabularyType is null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(VocabularyType)) };

            var resultDownloadMP3VocabularyWord = await _audioClipService.GetInfoFileMP3WithKey(request.Word.Trim(), vocabularyType.VocabularyTypeName);
                if (!resultDownloadMP3VocabularyWord.IsSuccessed)
                return new APIErrorResponse<bool>() { Message = resultDownloadMP3VocabularyWord.Message };

            var checkVocabularyWordExist = await _context.VocabularyWords.FirstOrDefaultAsync(x => x.Word.Trim().ToLower() == request.Word.Trim().ToLower());
            if (checkVocabularyWordExist != null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectAlreadyExists(nameof(VocabularyWord)) };

            var vocabularyWord = new VocabularyWord()
            {
                VocabularyTypeID = request.VocabularyTypeID,
                LanguageID = 1,
                Word = request.Word.Trim(),
                Definition = request.Definition.Trim(),
                Pronunciation = request.Pronunciation != null ? request.Pronunciation.Trim() : null,
                ExampleSentence = request.ExampleSentence != null ? request.ExampleSentence.Trim() : null,
                Synonyms = request.Synonyms,
                Antonyms = request.Antonyms,
                CreatedBy = SystemConstants.AppSettings.CreateByDefault,
                DateCreated = DateTime.Now,
                IsDeleted = false,
                AudioClips = new List<AudioClip>()
                {
                    new AudioClip()
                    {
                        PronunciationTypeID = 1,
                        AudioURL = resultDownloadMP3VocabularyWord.ResultObj ?? ""
                    }
                }
            };

            await _context.VocabularyWords.AddAsync(vocabularyWord);
            await _context.SaveChangesAsync();

            return new APISuccessResponse<bool>() { Message = MessageConstants.CreateSuccess(nameof(VocabularyWord))};
        }

        public async Task<APIResponse<bool>> DeleteVocabularyWordAsync(long vocabularyWordID)
        {
            var vocabularyWord = await _context.VocabularyWords
                                        .Include(vw => vw.AudioClips)
                                        .FirstOrDefaultAsync(vw => vw.VocabularyWordID == vocabularyWordID);

            if (vocabularyWord == null)
            {
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(VocabularyWord) )};
            }

            if(vocabularyWord.AudioClips != null)
            {
                _context.AudioClips.RemoveRange();
            }

            _context.VocabularyWords.Remove(vocabularyWord);

            await _context.SaveChangesAsync();

            return new APISuccessResponse<bool>() { Message = MessageConstants.DeleteSuccess(nameof(VocabularyWord)) };
        }

        public async Task<APIResponse<List<VocabularyWordViewModel>>> GetAllVocabylaryWordAsync(int? vocabularyTypeID)
        {
            IQueryable<VocabularyWord> query = _context.VocabularyWords.Include(vw => vw.AudioClips);

            if (vocabularyTypeID.HasValue)
            {
                query = query.Where(vw => vw.VocabularyTypeID == vocabularyTypeID.Value);
            }

            var vocabularyWords = await query.ToListAsync();

            if (vocabularyWords == null)
            {
                return new APIErrorResponse<List<VocabularyWordViewModel>>()
                {
                    Message = MessageConstants.ObjectNotFound(nameof(VocabularyWord))
                };
            }

            var vocabularyWordViewModels = vocabularyWords.Select(vw => new VocabularyWordViewModel
            {
                VocabularyWordID = vw.VocabularyWordID,
                VocabularyTypeID = vw.VocabularyTypeID,
                LanguageID = vw.LanguageID,
                Word = vw.Word,
                Definition = vw.Definition,
                Pronunciation = vw.Pronunciation,
                ExampleSentence = vw.ExampleSentence,
                Synonyms = vw.Synonyms,
                Antonyms = vw.Antonyms,
                ImageURL = vw.ImageURL,
                AudioClips = vw.AudioClips == null ? null : vw.AudioClips.Select(ac => new AudioClipViewModel
                {
                    AudioClipID = ac.AudioClipID,
                    VocabularyWordID = ac.VocabularyWordID,
                    PronunciationTypeID = ac.PronunciationTypeID,
                    AudioURL = ac.AudioURL
                }).ToList()
            }).ToList();

            return new APISuccessResponse<List<VocabularyWordViewModel>>() { ResultObj = vocabularyWordViewModels };
        }

        public async Task<APIResponse<bool>> UpdateVocabularyWordAsync(UpdateVocabularyWordRequest request, long vocabularyWordID)
        {
            var vocabularyWord = await _context.VocabularyWords.Include(vw => vw.AudioClips).FirstOrDefaultAsync(vw => vw.VocabularyWordID == vocabularyWordID);
            if (vocabularyWord == null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(VocabularyWord)) };

            var existingWord = await _context.VocabularyWords.FirstOrDefaultAsync(x => x.Word.Trim().ToLower() == request.Word.Trim().ToLower() && x.VocabularyWordID != vocabularyWordID);
            if (existingWord != null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectAlreadyExists(nameof(VocabularyWord)) };

            var vocabularyType = await _context.VocabularyTypes.FirstOrDefaultAsync(x => x.VocabularyTypeID == request.VocabularyTypeID);
            if (vocabularyType == null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(VocabularyType)) };

            var resultDownloadMP3VocabularyWord = await _audioClipService.GetInfoFileMP3WithKey(request.Word.Trim(), vocabularyType.VocabularyTypeName);
            if (!resultDownloadMP3VocabularyWord.IsSuccessed)
                return new APIErrorResponse<bool>() { Message = resultDownloadMP3VocabularyWord.Message };

            vocabularyWord.VocabularyTypeID = request.VocabularyTypeID;
            vocabularyWord.Word = request.Word.Trim();
            vocabularyWord.Definition = request.Definition.Trim();
            vocabularyWord.Pronunciation = request.Pronunciation != null ? request.Pronunciation.Trim() : null;
            vocabularyWord.ExampleSentence = request.ExampleSentence != null ? request.ExampleSentence.Trim() : null;
            vocabularyWord.Synonyms = request.Synonyms;
            vocabularyWord.Antonyms = request.Antonyms;
            vocabularyWord.ImageURL = request.ImageURL;

            var audioClip = vocabularyWord.AudioClips != null ? vocabularyWord.AudioClips.FirstOrDefault() : null;
            if (audioClip != null)
            {
                audioClip.AudioURL = resultDownloadMP3VocabularyWord.ResultObj ?? "";
            }

            await _context.SaveChangesAsync();

            return new APISuccessResponse<bool>() { Message = MessageConstants.UpdateSuccess(nameof(VocabularyWord)) };
        }
    }
}
