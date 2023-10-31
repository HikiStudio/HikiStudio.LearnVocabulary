using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class AppRoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {

            builder.ToTable("AppRoleClaims");

            builder.HasOne(x => x.AppRole).WithMany(x => x.AppRoleClaims).HasForeignKey(x => x.RoleId);
        }
    }
}
