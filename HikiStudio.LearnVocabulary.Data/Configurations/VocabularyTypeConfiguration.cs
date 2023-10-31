using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class VocabularyTypeConfiguration : EntityTypeConfigurationBase<VocabularyType>
    {
        public override void Configure(EntityTypeBuilder<VocabularyType> builder)
        {
            base.Configure(builder);

            builder.ToTable("VocabularyTypes");

            builder.HasKey(x => x.VocabularyTypeID);
            builder.Property(x => x.VocabularyTypeID).UseIdentityColumn();

            builder.Property(x => x.VocabularyTypeName).IsRequired(true).HasMaxLength(500);
        }
    }
}
