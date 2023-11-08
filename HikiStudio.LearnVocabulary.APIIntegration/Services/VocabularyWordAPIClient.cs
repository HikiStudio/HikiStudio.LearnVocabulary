using CSharpFunctionalExtensions;
using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class VocabularyWordAPIClient : BaseAPI, IVocabularyWordAPIClient
    {
        public VocabularyWordAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<APIResponse<bool>> CreateVocabularyWordAsync(CreateVocabularyWordRequest request)
        {
            return await PostAsync<APIResponse<bool>, CreateVocabularyWordRequest>(request, "/api/vocabulary-words/create");
        }

        public async Task<APIResponse<bool>> DeleteVocabularyWordAsync(long vocabularyWordID)
        {
            return await DeleteAsync<APIResponse<bool>>($"/api/vocabulary-words/delete/{vocabularyWordID}");
        }

        public async Task<List<VocabularyWordViewModel>> GetAllVocabularyWordAsync(int? vocabularyTypeID)
        {
            return await GetAsync<List<VocabularyWordViewModel>>($"/api/vocabulary-words/get-all-vocabulary-words/{vocabularyTypeID}");
        }

        public async Task<PagedResponse<VocabularyWordViewModel>> GetPagingVocabularyWordAsync(PagedRequest request, int? vocabularyTypeID)
        {
            return await PostAsync<PagedResponse<VocabularyWordViewModel>, PagedRequest>(request, $"/api/vocabulary-words/get-paging-vocabulary-words?vocabularyTypeID={vocabularyTypeID}");
        }

        public async Task<APIResponse<VocabularyWordViewModel>> GetVocabularyWordByVocabularyWordIDAsync(long vocabularyWordID)
        {
            return await GetAsync<APIResponse<VocabularyWordViewModel>>($"/api/vocabulary-words/get-vocabulary-word-by-vocabulary-word-id/{vocabularyWordID}");
        }

        public async Task<APIResponse<bool>> UpdateVocabularyWordAsync(UpdateVocabularyWordRequest request, long vocabularyWordID)
        {
            return await PutAsync<APIResponse<bool>, UpdateVocabularyWordRequest>(request, $"/api/vocabulary-words/update/{vocabularyWordID}");
        }
    }
}
