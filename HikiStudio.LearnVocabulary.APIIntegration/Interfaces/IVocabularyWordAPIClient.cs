using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;

namespace HikiStudio.LearnVocabulary.APIIntegration.Interfaces
{
    public interface IVocabularyWordAPIClient
    {
        Task<List<VocabularyWordViewModel>> GetAllVocabularyWordAsync(int? vocabularyTypeID);

        Task<PagedResponse<VocabularyWordViewModel>> GetPagingVocabularyWordAsync(PagedRequest request, int? vocabularyTypeID);

        Task<APIResponse<VocabularyWordViewModel>> GetVocabularyWordByVocabularyWordIDAsync(long vocabularyWordID);

        Task<List<VocabularyWordViewModel>> GetVocabularyWordByCourseIDAsync(int courseID);

        Task<APIResponse<bool>> CreateVocabularyWordAsync(CreateVocabularyWordRequest request);

        Task<APIResponse<bool>> UpdateVocabularyWordAsync(UpdateVocabularyWordRequest request, long vocabularyWordID);

        Task<APIResponse<bool>> DeleteVocabularyWordAsync(long vocabularyWordID);
    }
}
