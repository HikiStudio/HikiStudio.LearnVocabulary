using HikiStudio.LearnVocabulary.Utilities.Enums;

namespace HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships.DataRequest
{
    public class AssignVocabularyRelationshipRequest
    {
        public long FirstVocabularyWordID { get; set; }

        public long SecondVocabularyWordID { get; set; }

        public VocabularyRelationshipType VocabularyRelationshipType { get; set; }

    }
}
