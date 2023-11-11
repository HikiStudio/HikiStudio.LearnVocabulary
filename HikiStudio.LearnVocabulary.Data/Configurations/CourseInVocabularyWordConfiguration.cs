using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class CourseInVocabularyWordConfiguration : EntityTypeConfigurationBase<CourseInVocabularyWord>
    {
        public override void Configure(EntityTypeBuilder<CourseInVocabularyWord> builder)
        {
            base.Configure(builder);

            builder.ToTable("CourseInVocabularyWords");

            builder.HasKey(x => x.CourseInVocabularyWordID);
            builder.Property(x => x.CourseInVocabularyWordID).UseIdentityColumn();

            builder.HasOne(x => x.Course).WithMany(x => x.CourseInVocabularyWords).HasForeignKey(x => x.CourseID);

            builder.HasOne(x => x.VocabularyWord).WithMany(x => x.CourseInVocabularyWords).HasForeignKey(x => x.VocabularyWordID);
        }
    }
}
