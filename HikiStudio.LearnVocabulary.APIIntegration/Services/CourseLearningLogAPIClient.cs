using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs.DataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class CourseLearningLogAPIClient : BaseAPI, ICourseLearningLogAPIClient
    {
        public CourseLearningLogAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<APIResponse<bool>> CreateCourseLearningLogAsync(CreateCourseLearningLogRequest request)
        {
            return await PostAsync<APIResponse<bool>, CreateCourseLearningLogRequest>(request, $"/api/course-learning-logs/create");
        }

        public async Task<PagedResponse<CourseLearningLogViewModel>> GetPagingCourseLearningLogByCourseIDAsync(PagedRequest request, long courseID)
        {
            return await PostAsync<PagedResponse<CourseLearningLogViewModel>, PagedRequest>(request, $"/api/course-learning-logs/get-paging-course-learning-logs/{courseID}");
        }
    }
}
