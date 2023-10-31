using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class AudioClipConfiguration : EntityTypeConfigurationBase<AudioClip>
    {
        public override void Configure(EntityTypeBuilder<AudioClip> builder)
        {
            base.Configure(builder);

            builder.ToTable("AudioClips");

            builder.HasKey(x => x.AudioClipID);
            builder.Property(x => x.AudioClipID).UseIdentityColumn();

            builder.Property(x => x.VocabularyWordID).IsRequired(true);

            builder.Property(x => x.PronunciationTypeID).IsRequired(true);

            builder.Property(x => x.AudioURL).IsRequired(false).HasMaxLength(500);


            builder.HasOne(x => x.VocabularyWord).WithMany(x => x.AudioClips).HasForeignKey(x => x.VocabularyWordID);

            builder.HasOne(x => x.PronunciationType).WithMany(x => x.AudioClips).HasForeignKey(x => x.PronunciationTypeID);

        }
    }
}
