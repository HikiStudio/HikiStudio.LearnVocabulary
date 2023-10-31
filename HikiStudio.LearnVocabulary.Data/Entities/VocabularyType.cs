using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    /// <summary>
    /// Loại Từ Vựng
    /// </summary>
    public class VocabularyType : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int VocabularyTypeID { get; set; }

        public string? VocabularyTypeName { get; set; }

        
        public List<VocabularyWord>? VocabularyWords { get; set; }
    }
}
