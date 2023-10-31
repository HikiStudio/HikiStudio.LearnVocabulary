using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    /// <summary>
    /// Từ Vựng
    /// </summary>
    public class VocabularyWord : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public long VocabularyWordID { get; set; }

        public int VocabularyTypeID { get; set; }

        public int LanguageID { get; set; }

        public string Word { get; set; } = string.Empty;

        /// <summary>
        /// Nghĩa của từ
        /// </summary>
        public string Definition { get; set; } = string.Empty;

        /// <summary>
        /// Phiên âm
        /// </summary>
        public string? Pronunciation { get; set; }

        public string? ExampleSentence { get; set; }

        public string? Synonyms { get; set; }

        public string? Antonyms { get; set; }

        public string? ImageURL { get; set; }


        public VocabularyType? VocabularyType { get; set; }

        public Language? Language { get; set; }

        public List<AudioClip>? AudioClips {  get; set; }
    }
}
