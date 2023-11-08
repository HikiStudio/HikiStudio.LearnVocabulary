namespace HikiStudio.LearnVocabulary.ViewModels.VocabularyLearningLogs
{
    public class VocabularyLearningLogViewModel
    {
        public long VocabularyLearningLogID {  get; set; }

        public Guid? UserID {  get; set; }

        public TimeSpan? Duration { get; set; } 

        public string? Notes { get; set; }

        public string? DeviceInfo { get; set; }

        public DateTime DateCreated { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }
    }
}
