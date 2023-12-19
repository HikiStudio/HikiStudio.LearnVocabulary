using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.Courses;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes.DataRequest;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IVocabularyTypeService
    {
        Task<PagedResponse<VocabularyTypeViewModel>> GetPagingVocabularyTypesAsync(PagedRequest request);

        Task<APIResponse<List<VocabularyTypeViewModel>>> GetAllVocabularyTypesAsync();

        Task<APIResponse<VocabularyTypeViewModel>> GetVocabularyTypeByVocabularyTypeIDAsync(int vocabularyTypeID);

        Task<APIResponse<bool>> CreateVocabularyTypeAsync(CreateVocabularyTypeRequest request);

        Task<APIResponse<bool>> UpdateVocabularyTypeAsync(UpdateVocabularyTypeRequest request, int vocabularyTypeID);

        Task<APIResponse<bool>> DeleteVocabularyTypeAsync(int vocabularyTypeID);

    }
}
