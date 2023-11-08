using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class VocabularyLearningLog : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public long VocabularyLearningLogID {  get; set; }

        public Guid? UserID {  get; set; }

        public TimeSpan? Duration { get; set; } 

        public string? Notes { get; set; }

        public string? DeviceInfo { get; set; }
    }
}
