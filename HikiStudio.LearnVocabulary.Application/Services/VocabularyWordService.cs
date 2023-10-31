using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class VocabularyWordService : IVocabularyWordService
    {
        private readonly LanguageLearningDbContext _context;

        public VocabularyWordService(LanguageLearningDbContext context)
        {
            _context = context;
        }


    }
}
