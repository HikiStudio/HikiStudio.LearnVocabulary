using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    /// <summary>
    /// Loại Phát Âm
    /// </summary>
    public class PronunciationType : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int PronunciationTypeID { get; set; }

        public string PronunciationTypeName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public List<AudioClip>? AudioClips { get; set; }
    }
}
