using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.AudioClips;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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

            var checkVocabularyWordExist = await _context.VocabularyWords.FirstOrDefaultAsync(x => x.Word.Trim().ToLower() == request.Word.Trim().ToLower() && x.VocabularyTypeID == request.VocabularyTypeID);
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
                ExampleSentenceMeaning = request.ExampleSentenceMeaning != null ? request.ExampleSentenceMeaning.Trim() : null,
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

        public async Task<List<VocabularyWordViewModel>> GetAllVocabularyWordAsync(int? vocabularyTypeID)
        {
            IQueryable<VocabularyWord> query = _context.VocabularyWords.Include(vt => vt.VocabularyType).Include(vw => vw.AudioClips);

            if (vocabularyTypeID.HasValue && vocabularyTypeID != 0)
            {
                query = query.Where(vw => vw.VocabularyTypeID == vocabularyTypeID.Value);
            }

            var vocabularyWordViewModels = await query
                .Select(vw => new VocabularyWordViewModel
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
                    DateCreated = vw.DateCreated,
                    AudioClips = vw.AudioClips == null ? null : vw.AudioClips.Select(ac => new AudioClipViewModel
                    {
                        AudioClipID = ac.AudioClipID,
                        VocabularyWordID = ac.VocabularyWordID,
                        PronunciationTypeID = ac.PronunciationTypeID,
                        AudioURL = ac.AudioURL
                    }).ToList()
                })
                .ToListAsync();

            return vocabularyWordViewModels;
        }

        public async Task<PagedResponse<VocabularyWordViewModel>> GetPagingVocabularyWordAsync(PagedRequest request, int? vocabularyTypeID)
        {
            IQueryable<VocabularyWord> query = _context.VocabularyWords.Include(vw => vw.AudioClips);

            if (vocabularyTypeID.HasValue && vocabularyTypeID != 0)
            {
                query = query.Where(vw => vw.VocabularyTypeID == vocabularyTypeID.Value);
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(vw => vw.Word.ToLower().Contains(request.SearchValue.ToLower()) || vw.Definition.ToLower().Contains(request.SearchValue.ToLower()));
            }

            query = query.OrderBy($"{request.SortColumn} {request.SortColumnDirection}");

            var totalRecords = await query.CountAsync();
            var vocabularyWordViewModels = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .Select(vw => new VocabularyWordViewModel
                {
                    VocabularyWordID = vw.VocabularyWordID,
                    VocabularyTypeID = vw.VocabularyTypeID,
                    LanguageID = vw.LanguageID,
                    Word = vw.Word,
                    Definition = vw.Definition,
                    Pronunciation = vw.Pronunciation,
                    ExampleSentence = vw.ExampleSentence,
                    ExampleSentenceMeaning = vw.ExampleSentenceMeaning,
                    Synonyms = vw.Synonyms,
                    Antonyms = vw.Antonyms,
                    ImageURL = vw.ImageURL,
                    DateCreated = vw.DateCreated,
                    AudioClips = vw.AudioClips == null ? null : vw.AudioClips.Select(ac => new AudioClipViewModel
                    {
                        AudioClipID = ac.AudioClipID,
                        VocabularyWordID = ac.VocabularyWordID,
                        PronunciationTypeID = ac.PronunciationTypeID,
                        AudioURL = ac.AudioURL
                    }).ToList()
                })
                .ToListAsync();

            var pagedResponse = new PagedResponse<VocabularyWordViewModel>
            {
                Draw = request.Draw,
                RecordsFiltered = totalRecords,
                RecordsTotal = totalRecords,
                Data = vocabularyWordViewModels
            };

            return pagedResponse;
        }

        public async Task<List<VocabularyWordViewModel>> GetVocabularyWordByCourseIDAsync(int courseID)
        {
            var vocabularyWords = await _context.Courses.Where(c => c.CourseID == courseID && c.IsDeleted == false)
                .SelectMany(c => c.CourseInVocabularyWords)
                .SelectMany(civw => _context.VocabularyWords.Where(vw => civw.VocabularyWordID == vw.VocabularyWordID)
                .Include(vw => vw.AudioClips)).Select(vw => new VocabularyWordViewModel
                {
                    VocabularyWordID = vw.VocabularyWordID,
                    VocabularyTypeID = vw.VocabularyTypeID,
                    LanguageID = vw.LanguageID,
                    Word = vw.Word,
                    Definition = vw.Definition,
                    Pronunciation = vw.Pronunciation,
                    ExampleSentence = vw.ExampleSentence,
                    ExampleSentenceMeaning = vw.ExampleSentenceMeaning,
                    Synonyms = vw.Synonyms,
                    Antonyms = vw.Antonyms,
                    ImageURL = vw.ImageURL,
                    DateCreated = vw.DateCreated,
                    AudioClips = vw.AudioClips == null ? null : vw.AudioClips
                        .Select(ac => new AudioClipViewModel
                        {
                            AudioClipID = ac.AudioClipID,
                            VocabularyWordID = ac.VocabularyWordID,
                            PronunciationTypeID = ac.PronunciationTypeID,
                            AudioURL = ac.AudioURL
                        }).ToList()
                })
                .ToListAsync();

            return vocabularyWords;
        }

        public async Task<APIResponse<VocabularyWordViewModel>> GetVocabularyWordByVocabularyWordIDAsync(long vocabularyWordID)
        {
            var vocabularyWord = await _context.VocabularyWords.FirstOrDefaultAsync(x => x.VocabularyWordID == vocabularyWordID);
            if (vocabularyWord is null)
                return new APIErrorResponse<VocabularyWordViewModel>() { Message = MessageConstants.ObjectNotFound(nameof(VocabularyWord)) };

            var vocabularyWordViewModel = new VocabularyWordViewModel()
            {
                VocabularyWordID = vocabularyWord.VocabularyWordID,
                VocabularyTypeID = vocabularyWord.VocabularyTypeID,
                Word = vocabularyWord.Word,
                Definition = vocabularyWord.Definition,
                Pronunciation = vocabularyWord.Pronunciation,
                Antonyms = vocabularyWord.Antonyms,
                Synonyms = vocabularyWord.Synonyms,
                DateCreated = vocabularyWord.DateCreated,
                ExampleSentence = vocabularyWord.ExampleSentence,
                ExampleSentenceMeaning = vocabularyWord.ExampleSentenceMeaning,
                ImageURL = vocabularyWord.ImageURL,
                LanguageID = vocabularyWord.LanguageID
            };

            return new APISuccessResponse<VocabularyWordViewModel>() { ResultObj = vocabularyWordViewModel };
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
            vocabularyWord.ExampleSentenceMeaning = request.ExampleSentenceMeaning != null ? request.ExampleSentenceMeaning.Trim() : null;
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
