using HikiStudio.LearnVocabulary.Data.Entities.Base.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntitySoftDelete, IEntityCreatedDate
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DOB { get; set; }

        public string? UserImageURL { get; set; }

        public int? GenderId { get; set; }


        public string RefreshToken { get; set; } = null!;

        public DateTime? TokenCreated { get; set; }

        public DateTime? TokenExpires { get; set; }


        public string? OTP { get; set; }

        public DateTime? OTPExpires { get; set; }

        public bool? IsOTPVerified { get; set; }


        public int AppUserTypeId { get; set; }

        public bool IsCreateAppUserWithThirdParty { get; set; }

        public bool IsPasswordChanged { get; set; }

        public DateTime? DatePasswordChanged { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public Guid? CreatedBy { get; set; }


        #region auth
        public List<AppUserRole>? AppUserRoles { get; set; }

        public List<AppUserLogin>? AppUserLogins { get; set; }

        public List<AppUserToken>? AppUserTokens { get; set; }

        public List<AppUserClaim>? AppUserClaims { get; set; }

        public List<FavouriteCourse>? FavouriteCourses { get; set; }
        #endregion
    }
}
