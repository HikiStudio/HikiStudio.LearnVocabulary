using HikiStudio.LearnVocabulary.Data.Configurations.Base;
using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikiStudio.LearnVocabulary.Data.Configurations
{
    public class VocabularyWordConfiguration : EntityTypeConfigurationBase<VocabularyWord>
    {
        public override void Configure(EntityTypeBuilder<VocabularyWord> builder)
        {
            base.Configure(builder);

            builder.ToTable("VocabularyWords");

            builder.HasKey(x => x.VocabularyWordID);
            builder.Property(x => x.VocabularyWordID).UseIdentityColumn();

            builder.Property(x => x.VocabularyTypeID).IsRequired(true);

            builder.Property(x => x.LanguageID).IsRequired(true);

            builder.Property(x => x.Word).IsRequired(true).HasMaxLength(500);

            builder.Property(x => x.Definition).IsRequired(true).HasMaxLength(1000);

            builder.Property(x => x.Pronunciation).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.ExampleSentence).IsRequired(false).HasMaxLength(1000);

            builder.Property(x => x.ExampleSentenceMeaning).IsRequired(false).HasMaxLength(1000);

            builder.Property(x => x.Synonyms).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.Antonyms).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.ImageURL).IsRequired(false).HasMaxLength(500);


            builder.HasOne(x => x.VocabularyType).WithMany(x => x.VocabularyWords).HasForeignKey(x => x.VocabularyTypeID);

            builder.HasOne(x => x.Language).WithMany(x => x.VocabularyWords).HasForeignKey(x => x.LanguageID);
        }
    }
}
