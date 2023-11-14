namespace HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs.DataRequest
{
    public class CreateCourseLearningLogRequest
    {
        public int CourseID { get; set; }

        public string? Log { get; set; }

        public int? QuizTypeID { get; set; }

        public TimeSpan? Duration { get; set; }

        public double Score { get; set; }

        public DateTime LearningDate {  get; set; }
    }
}
