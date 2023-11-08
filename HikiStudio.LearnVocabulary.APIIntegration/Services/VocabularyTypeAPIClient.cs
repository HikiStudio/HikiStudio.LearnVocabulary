using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class VocabularyTypeAPIClient : BaseAPI, IVocabularyTypeAPIClient
    {
        public VocabularyTypeAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<APIResponse<List<VocabularyTypeViewModel>>> GetAllVocabularyTypesAsync()
        {
            return await GetAsync<APIResponse<List<VocabularyTypeViewModel>>>($"/api/vocabulary-types/get-all");
        }
    }
}
