using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class AppUserClaimConfiguration : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.ToTable("AppUserClaims");

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserClaims).HasForeignKey(x => x.UserId);
        }
    }
}
