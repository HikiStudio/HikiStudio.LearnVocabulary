using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using Microsoft.EntityFrameworkCore;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class Mp3Service : IMp3Service
    {
        private readonly LanguageLearningDbContext _context;

        public Mp3Service(LanguageLearningDbContext context)
        {
            _context = context;
        }

        public async Task<byte[]?> GetMp3Data(long audioClipID)
        {
            var audioClip = await _context.AudioClips.FirstOrDefaultAsync(x => x.AudioClipID == audioClipID);
            if (audioClip is null)
                return null;

            string mp3Path = Path.Combine(SystemConstants.AppSettings.URLFolderSaveVocabularyWord, audioClip.AudioURL);

            if (System.IO.File.Exists(mp3Path))
            {
                return System.IO.File.ReadAllBytes(mp3Path);
            }
            return null;
        }
    }
}
