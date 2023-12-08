using HikiStudio.LearnVocabulary.Data.Configurations;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HikiStudio.LearnVocabulary.Data.EF
{
    public class LanguageLearningDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LanguageLearningDbContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.ApplyConfiguration(new AppRoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());

            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new VocabularyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PronunciationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VocabularyWordConfiguration());
            modelBuilder.ApplyConfiguration(new AudioClipConfiguration());
            modelBuilder.ApplyConfiguration(new VocabularyLearningLogConfiguration());

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseLearningLogConfiguration());
            modelBuilder.ApplyConfiguration(new CourseInVocabularyWordConfiguration());
            modelBuilder.ApplyConfiguration(new FavouriteCourseConfiguration());

            modelBuilder.ApplyConfiguration(new VocabularyRelationshipConfiguration());

            //
            //modelBuilder.Seed();
        }

        public override DbSet<AppRole> Roles { get; set; }

        public DbSet<PronunciationType> PronunciationTypes { get; set; }

        public DbSet<AudioClip> AudioClips { get; set; }

        public DbSet<VocabularyType> VocabularyTypes { get; set; }

        public DbSet<VocabularyWord> VocabularyWords { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<VocabularyLearningLog> VocabularyLearningLogs { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseLearningLog> CourseLearningLogs { get; set; }

        public DbSet<CourseInVocabularyWord> CourseInVocabularyWords { get; set; }

        public DbSet<FavouriteCourse> FavouriteCourses { get; set; }

        public DbSet<VocabularyRelationship> VocabularyRelationships { get; set; }

    }
}
