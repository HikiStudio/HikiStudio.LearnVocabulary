using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes.DataRequest;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IVocabularyTypeService
    {
        Task<APIResponse<List<VocabularyTypeViewModel>>> GetAllVocabularyTypesAsync();

        Task<APIResponse<bool>> CreateVocabularyTypeAsync(CreateVocabularyTypeRequest request);

        Task<APIResponse<bool>> UpdateVocabularyTypeAsync(UpdateVocabularyTypeRequest request, int vocabularyTypeID);

        Task<APIResponse<bool>> DeleteVocabularyTypeAsync(int vocabularyTypeID);

    }
}
