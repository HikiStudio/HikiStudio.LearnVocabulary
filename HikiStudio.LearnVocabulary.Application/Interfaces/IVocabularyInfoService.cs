using HikiStudio.LearnVocabulary.ViewModels.Common.API;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IVocabularyInfoService
    {
        Task<APIResponse<object>> GetVocabularyInfoWithKey(string key);
    }
}
