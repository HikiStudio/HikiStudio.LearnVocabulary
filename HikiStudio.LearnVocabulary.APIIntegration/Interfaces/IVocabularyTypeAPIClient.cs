using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes;

namespace HikiStudio.LearnVocabulary.APIIntegration.Interfaces
{
    public interface IVocabularyTypeAPIClient
    {
        Task<APIResponse<List<VocabularyTypeViewModel>>> GetAllVocabularyTypesAsync();
    }
}
