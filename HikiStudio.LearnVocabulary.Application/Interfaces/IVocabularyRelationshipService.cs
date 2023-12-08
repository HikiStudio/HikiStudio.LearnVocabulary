using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships.DataRequest;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IVocabularyRelationshipService
    {
        Task<APIResponse<List<VocabularyRelationshipViewModel>>> GetVocabularyRelationshipByVocabularyWordIDAsync(long vocabularyWordID);

        Task<APIResponse<bool>> AssignVocabularyRelationshipAsync(List<AssignVocabularyRelationshipRequest> requests, long vocabularyWordID);
    }
}
