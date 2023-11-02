using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IVocabularyWordService
    {
        Task<APIResponse<List<VocabularyWordViewModel>>> GetAllVocabylaryWordAsync(int? vocabularyTypeID);

        Task<APIResponse<bool>> CreateVocabularyWordAsync(CreateVocabularyWordRequest request);

        Task<APIResponse<bool>> UpdateVocabularyWordAsync(UpdateVocabularyWordRequest request, long vocabularyWordID);

        Task<APIResponse<bool>> DeleteVocabularyWordAsync(long vocabularyWordID);


    }
}
