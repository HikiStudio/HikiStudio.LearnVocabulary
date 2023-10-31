using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    /// <summary>
    /// Ngôn Ngữ
    /// </summary>
    public class Language : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int LanguageID { get; set; }

        public string? LanguageName { get; set; }

        public List<VocabularyWord>? VocabularyWords { get; set; }
    }
}
