using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class CourseLearningLog : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int CourseLearningLogID { get; set; }

        public int CourseID { get; set; }

        public DateTime LearningDate { get; set; }

        public string? Log { get; set; }

        public int? QuizTypeID { get; set; }

        public TimeSpan? Duration { get; set; }

        public double Score { get; set; }


        public Course? Course { get; set; }
    }
}