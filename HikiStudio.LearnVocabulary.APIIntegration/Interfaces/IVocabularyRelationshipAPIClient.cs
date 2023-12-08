using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships.DataRequest;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships;

namespace HikiStudio.LearnVocabulary.APIIntegration.Interfaces
{
    public interface IVocabularyRelationshipAPIClient
    {
        Task<APIResponse<List<VocabularyRelationshipViewModel>>> GetVocabularyRelationshipByVocabularyWordIDAsync(long vocabularyWordID);

        Task<APIResponse<bool>> AssignVocabularyRelationshipAsync(List<AssignVocabularyRelationshipRequest> requests, long vocabularyWordID);
    }
}
