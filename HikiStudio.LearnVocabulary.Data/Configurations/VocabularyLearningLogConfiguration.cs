using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class VocabularyLearningLogConfiguration : EntityTypeConfigurationBase<VocabularyLearningLog>
    {
        public override void Configure(EntityTypeBuilder<VocabularyLearningLog> builder)
        {
            base.Configure(builder);

            builder.ToTable("VocabularyLearningLogs");

            builder.HasKey(x => x.VocabularyLearningLogID);
            builder.Property(x => x.VocabularyLearningLogID).UseIdentityColumn();

            builder.Property(x => x.UserID).IsRequired(false);

            builder.Property(x => x.Duration).IsRequired(false);

            builder.Property(x => x.Notes).HasMaxLength(2000).IsRequired(false);

            builder.Property(x => x.DeviceInfo).HasMaxLength(1000).IsRequired(false);
        }
    }
}
