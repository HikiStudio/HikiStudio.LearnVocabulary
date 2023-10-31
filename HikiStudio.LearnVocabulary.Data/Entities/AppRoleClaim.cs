using Microsoft.AspNetCore.Identity;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class AppRoleClaim : IdentityRoleClaim<Guid>
    {
        public AppRole? AppRole { get; set; }
    }
}
