using Microsoft.AspNetCore.Identity;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class AppUserClaim : IdentityUserClaim<Guid>
    {
        public AppUser? AppUser { get; set; }
    }
}
