using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.Data.EF
{
    public class LanguageLearningDbContextFactory : IDesignTimeDbContextFactory<LanguageLearningDbContext>
    {
        public LanguageLearningDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("LanguageLearningDB");

            var optionsBuilder = new DbContextOptionsBuilder<LanguageLearningDbContext>();
            optionsBuilder.UseSqlServer(connectionString ?? "");

            return new LanguageLearningDbContext(optionsBuilder.Options);
        }
    }
}
