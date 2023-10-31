using HikiStudio.LearnVocabulary.Data.Entities.Base.Interfaces;

namespace HikiStudio.LearnVocabulary.Data.Entities.Base.Entities
{
    /// <summary>
    /// Represents an entity that supports soft deletion.
    /// </summary>
    public class EntitySoftDelete : IEntitySoftDelete
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is deleted.
        /// </summary>
        public virtual bool IsDeleted { get; set; }
    }
}
