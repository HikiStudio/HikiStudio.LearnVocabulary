using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes.DataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class VocabularyTypeAPIClient : BaseAPI, IVocabularyTypeAPIClient
    {
        public VocabularyTypeAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<APIResponse<bool>> CreateVocabularyTypeAsync(CreateVocabularyTypeRequest request)
        {
            return await PostAsync<APIResponse<bool>, CreateVocabularyTypeRequest>(request, "/api/vocabulary-types/create");
        }

        public async Task<APIResponse<bool>> DeleteVocabularyTypeAsync(int vocabularyTypeID)
        {
            return await DeleteAsync<APIResponse<bool>>($"/api/vocabulary-types/delete/{vocabularyTypeID}");
        }

        public async Task<APIResponse<List<VocabularyTypeViewModel>>> GetAllVocabularyTypesAsync()
        {
            return await GetAsync<APIResponse<List<VocabularyTypeViewModel>>>($"/api/vocabulary-types/get-all");
        }

        public async Task<PagedResponse<VocabularyTypeViewModel>> GetPagingVocabularyTypesAsync(PagedRequest request)
        {
            return await PostAsync<PagedResponse<VocabularyTypeViewModel>, PagedRequest>(request, "/api/vocabulary-types/get-paging-vocabulary-types");
        }

        public async Task<APIResponse<VocabularyTypeViewModel>> GetVocabularyTypeByVocabularyTypeIDAsync(int vocabularyTypeID)
        {
            return await GetAsync<APIResponse<VocabularyTypeViewModel>>($"/api/vocabulary-types/get-vocabulary-type-by-vocabulary-type-id/{vocabularyTypeID}");
        }

        public async Task<APIResponse<bool>> UpdateVocabularyTypeAsync(UpdateVocabularyTypeRequest request, int vocabularyTypeID)
        {
            return await PutAsync<APIResponse<bool>, UpdateVocabularyTypeRequest>(request, $"/api/vocabulary-types/update/{vocabularyTypeID}");
        }
    }
}
