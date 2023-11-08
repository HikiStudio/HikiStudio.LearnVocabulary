using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyLearningLogs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class VocabularyLearningLogAPIClient : BaseAPI, IVocabularyLearningLogAPIClient
    {
        public VocabularyLearningLogAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<PagedResponse<VocabularyLearningLogViewModel>> GetPagingVocabularyLearningLogAsync(PagedRequest request)
        {
            return await PostAsync<PagedResponse<VocabularyLearningLogViewModel>, PagedRequest>(request, $"/api/vocabulary-learning-logs/get-paging-vocabulary-learning-logs");
        }
    }
}
