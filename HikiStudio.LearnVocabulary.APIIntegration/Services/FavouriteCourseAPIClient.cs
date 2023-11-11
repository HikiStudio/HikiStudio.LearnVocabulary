using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class FavouriteCourseAPIClient : BaseAPI, IFavouriteCourseAPIClient
    {
        public FavouriteCourseAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public Task<APIResponse<bool>> ChangeFavouriteCourseAsync(int courseID)
        {
            return GetAsync<APIResponse<bool>>($"/api/favourite-courses/change-favourite-course/{courseID}");
        }

        public async Task<APIResponse<bool>> CreateFavouriteCourseAsync(int courseID)
        {
            return await PostAsync<APIResponse<bool>, int>(courseID, $"/api/favourite-courses/create");
        }

        public async Task<APIResponse<bool>> DeleteFavouriteCourseAsync(int courseID)
        {
            return await DeleteAsync<APIResponse<bool>>($"/api/favourite-courses/delete/{courseID}");
        }
    }
}
