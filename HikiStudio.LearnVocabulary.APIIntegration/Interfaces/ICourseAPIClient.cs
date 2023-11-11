using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Courses.DataRequest;
using HikiStudio.LearnVocabulary.ViewModels.Courses;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;

namespace HikiStudio.LearnVocabulary.APIIntegration.Interfaces
{
    public interface ICourseAPIClient
    {
        Task<PagedResponse<CourseViewModel>> GetPagingCourseAsync(PagedRequest request);

        Task<List<CourseViewModel>> GetAllAsync();

        Task<APIResponse<bool>> GenerateDailyCourseAsync();

        Task<APIResponse<CourseViewModel>> GetCourseByCourseIDAsync(int courseID);

        Task<APIResponse<bool>> CreateCourseAsync(CreateCourseRequest request);

        Task<APIResponse<bool>> UpdateCourseAsync(UpdateCourseRequest request, int courseID);

        Task<APIResponse<bool>> DeleteCourseAsync(int courseID);
    }
}
