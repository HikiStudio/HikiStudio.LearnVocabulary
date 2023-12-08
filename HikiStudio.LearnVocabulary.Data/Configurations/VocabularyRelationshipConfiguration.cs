using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class VocabularyRelationshipConfiguration : EntityTypeConfigurationBase<VocabularyRelationship>
    {
        public override void Configure(EntityTypeBuilder<VocabularyRelationship> builder)
        {
            base.Configure(builder);

            builder.ToTable("VocabularyRelationships");

            builder.HasKey(x => x.VocabularyRelationshipID);
            builder.Property(x => x.VocabularyRelationshipID).UseIdentityColumn();

            builder.Property(x => x.VocabularyRelationshipType).IsRequired(true);

            builder.HasOne(x => x.VocabularyWord).WithMany(x => x.VocabularyRelationships).HasForeignKey(x => x.FirstVocabularyWordID);

            builder.HasOne(x => x.VocabularyWord).WithMany(x => x.VocabularyRelationships).HasForeignKey(x => x.SecondVocabularyWordID);
        }
    }
}
