using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs.DataRequest;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs;

namespace HikiStudio.LearnVocabulary.APIIntegration.Interfaces
{
    public interface ICourseLearningLogAPIClient
    {
        Task<PagedResponse<CourseLearningLogViewModel>> GetPagingCourseLearningLogByCourseIDAsync(PagedRequest request, long courseID);

        Task<APIResponse<bool>> CreateCourseLearningLogAsync(CreateCourseLearningLogRequest request);
    }
}
