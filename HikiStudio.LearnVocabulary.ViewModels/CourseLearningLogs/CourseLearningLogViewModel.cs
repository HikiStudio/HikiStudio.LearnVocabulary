namespace HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs
{
    public class CourseLearningLogViewModel
    {
        public int CourseLearningLogID { get; set; }

        public int CourseID { get; set; }

        public DateTime LearningDate { get; set; }

        public string? Log { get; set; }

        public double Score { get; set; }

        public DateTime DateCreated {  get; set; }
    }
}
