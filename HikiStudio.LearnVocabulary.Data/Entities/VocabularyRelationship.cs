using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;
using HikiStudio.LearnVocabulary.Utilities.Enums;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class VocabularyRelationship : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public long VocabularyRelationshipID { get; set; }

        public long FirstVocabularyWordID { get; set; }

        public long SecondVocabularyWordID { get; set; }

        public VocabularyRelationshipType VocabularyRelationshipType { get; set; }


        public VocabularyWord? VocabularyWord { get; set; }
    }
}
