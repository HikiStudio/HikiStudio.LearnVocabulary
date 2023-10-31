using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class LanguageConfiguration : EntityTypeConfigurationBase<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);

            builder.ToTable("Languages");

            builder.HasKey(x => x.LanguageID);
            builder.Property(x => x.LanguageID).UseIdentityColumn();

            builder.Property(x => x.LanguageName).IsRequired(true).HasMaxLength(500);
        }
    }
}
