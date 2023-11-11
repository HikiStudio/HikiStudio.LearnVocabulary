using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class CourseConfiguration : EntityTypeConfigurationBase<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.ToTable("Courses");

            builder.HasKey(x => x.CourseID);
            builder.Property(x => x.CourseID).UseIdentityColumn();

            builder.Property(x => x.CourseName).IsRequired(true).HasMaxLength(500);

            builder.Property(x => x.CourseCode).IsRequired(false).HasMaxLength(200);

            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(2000).IsUnicode(true);

            builder.Property(x => x.CourseType).IsRequired(true);
        }
    }
}
