using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class Course : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; } = String.Empty;

        public List<CourseInVocabularyWord>? CourseVocabularies { get; set; } 

        public List<CourseLearningLog>? LearningLogs { get; set; } 
    }
}