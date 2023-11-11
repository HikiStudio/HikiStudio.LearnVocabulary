using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class FavouriteCourseConfiguration : EntityTypeConfigurationBase<FavouriteCourse>
    {
        public override void Configure(EntityTypeBuilder<FavouriteCourse> builder)
        {
            base.Configure(builder);

            builder.ToTable("FavouriteCourses");

            builder.HasKey(x => x.FavouriteCourseID);
            builder.Property(x => x.FavouriteCourseID).UseIdentityColumn();

            builder.HasOne(x => x.Course).WithMany(x => x.FavouriteCourses).HasForeignKey(x => x.CourseID);

            builder.HasOne(x => x.User).WithMany(x => x.FavouriteCourses).HasForeignKey(x => x.UserID);
        }
    }
}
