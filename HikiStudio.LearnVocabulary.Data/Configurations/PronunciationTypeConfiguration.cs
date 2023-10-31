using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class PronunciationTypeConfiguration : EntityTypeConfigurationBase<PronunciationType>
    {
        public override void Configure(EntityTypeBuilder<PronunciationType> builder)
        {
            base.Configure(builder);

            builder.ToTable("PronunciationTypes");

            builder.HasKey(x => x.PronunciationTypeID);
            builder.Property(x => x.PronunciationTypeID).UseIdentityColumn();

            builder.Property(x => x.PronunciationTypeName).IsRequired(true).HasMaxLength(500);

            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(1000);
        }
    }
}
