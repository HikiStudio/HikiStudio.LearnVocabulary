using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    /// <summary>
    /// Âm Thanh
    /// </summary>
    public class AudioClip : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public long AudioClipID { get; set; }

        public long VocabularyWordID { get; set; }

        public int PronunciationTypeID { get; set; }

        public string AudioURL { get; set; } = String.Empty;


        public VocabularyWord? VocabularyWord { get; set; }

        public PronunciationType? PronunciationType { get; set; }
    }
}
