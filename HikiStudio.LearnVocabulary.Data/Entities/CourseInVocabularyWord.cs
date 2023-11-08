using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class CourseInVocabularyWord : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int CourseInVocabularyWordID { get; set; }

        public int CourseID { get; set; }

        public int VocabularyWordID { get; set; }


        public Course? Course { get; set; }

        public VocabularyWord? VocabularyWord { get; set; }
    }
}