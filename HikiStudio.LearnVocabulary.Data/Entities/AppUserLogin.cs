using Microsoft.AspNetCore.Identity;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class AppUserLogin : IdentityUserLogin<Guid>
    {
        public int AppUserLoginId { get; set; }

        public AppUser? AppUser { get; set; }
    }
}
