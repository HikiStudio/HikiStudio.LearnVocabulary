using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs.DataRequest;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface ICourseLearningLogService
    {
        Task<PagedResponse<CourseLearningLogViewModel>> GetPagingCourseLearningLogByCourseIDAsync(PagedRequest request, long courseID);

        Task<APIResponse<bool>> CreateCourseLearningLogAsync(CreateCourseLearningLogRequest request);
    }
}
