using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.Courses;
using HikiStudio.LearnVocabulary.ViewModels.Courses.DataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class CourseAPIClient : BaseAPI, ICourseAPIClient
    {
        public CourseAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<APIResponse<bool>> CreateCourseAsync(CreateCourseRequest request)
        {
            return await PostAsync<APIResponse<bool>, CreateCourseRequest>(request, "/api/courses/create");
        }

        public async Task<APIResponse<bool>> DeleteCourseAsync(int courseID)
        {
            return await DeleteAsync<APIResponse<bool>>($"/api/courses/delete/{courseID}");
        }

        public async Task<APIResponse<bool>> GenerateDailyCourseAsync()
        {
            return await GetAsync<APIResponse<bool>>($"/api/courses/generate-daily-course");
        }

        public async Task<List<CourseViewModel>> GetAllAsync()
        {
            return await GetAsync<List<CourseViewModel>>($"/api/courses/get-all");
        }

        public async Task<APIResponse<CourseViewModel>> GetCourseByCourseIDAsync(int courseID)
        {
            return await GetAsync<APIResponse<CourseViewModel>>($"/api/courses/get-course-by-course-id/{courseID}");
        }

        public async Task<PagedResponse<CourseViewModel>> GetPagingCourseAsync(PagedRequest request)
        {
            return await PostAsync<PagedResponse<CourseViewModel>, PagedRequest>(request, "/api/courses/get-paging-courses");
        }

        public async Task<APIResponse<bool>> UpdateCourseAsync(UpdateCourseRequest request, int courseID)
        {
            return await PutAsync<APIResponse<bool>, UpdateCourseRequest>(request, $"/api/courses/update/{courseID}");
        }
    }
}
