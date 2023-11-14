using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class CourseLearningLogConfiguration : EntityTypeConfigurationBase<CourseLearningLog>
    {
        public override void Configure(EntityTypeBuilder<CourseLearningLog> builder)
        {
            base.Configure(builder);

            builder.ToTable("CourseLearningLogs");

            builder.HasKey(x => x.CourseLearningLogID);
            builder.Property(x => x.CourseLearningLogID).UseIdentityColumn();

            builder.Property(x => x.LearningDate).IsRequired(true);

            builder.Property(x => x.Log).IsRequired(false).HasMaxLength(2000);

            builder.Property(x => x.QuizTypeID).IsRequired(false);

            builder.Property(x => x.Duration).IsRequired(false);

            builder.Property(x => x.Score).IsRequired(true).HasDefaultValue(0);

            builder.HasOne(x => x.Course).WithMany(x => x.CourseLearningLogs).HasForeignKey(x => x.CourseID);
        }
    }
}
