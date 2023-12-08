using HikiStudio.LearnVocabulary.Utilities.Enums;

namespace HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships
{
    public class VocabularyRelationshipViewModel
    {
        public long VocabularyRelationshipID { get; set; }

        public long FirstVocabularyWordID { get; set; }

        public long SecondVocabularyWordID { get; set; }

        public string Word { get; set; } = String.Empty;

        public VocabularyRelationshipType VocabularyRelationshipType { get; set; }

    }
}
