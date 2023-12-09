using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyLearningLogs;

namespace HikiStudio.LearnVocabulary.APIIntegration.Interfaces
{
    public interface IVocabularyLearningLogAPIClient
    {
        Task<PagedResponse<VocabularyLearningLogViewModel>> GetPagingVocabularyLearningLogAsync(PagedRequest request);

        Task<APIResponse<StatisticsVocabularyLearningViewModel>> GetStatisticsVocabularyLearningAsync(int days);
    }
}