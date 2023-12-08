using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships.DataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class VocabularyRelationshipAPIClient : BaseAPI, IVocabularyRelationshipAPIClient
    {
        public VocabularyRelationshipAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<APIResponse<bool>> AssignVocabularyRelationshipAsync(List<AssignVocabularyRelationshipRequest> requests, long vocabularyWordID)
        {
            return await PostAsync<APIResponse<bool>, List<AssignVocabularyRelationshipRequest>>(requests, $"/api/vocabulary-relationships/assign-vocabulary-relationship/{vocabularyWordID}");
        }

        public async Task<APIResponse<List<VocabularyRelationshipViewModel>>> GetVocabularyRelationshipByVocabularyWordIDAsync(long vocabularyWordID)
        {
            return await GetAsync<APIResponse<List<VocabularyRelationshipViewModel>>>($"/api/vocabulary-relationships/get-vocabulary-relationship-by-vocabulary-word-id/{vocabularyWordID}");
        }
    }
}
