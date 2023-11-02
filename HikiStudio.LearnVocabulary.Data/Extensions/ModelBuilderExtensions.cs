using HikiStudio.LearnVocabulary.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HikiStudio.LearnVocabulary.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminId = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F");

            var adminRoleId = new Guid("E1DB1200-1BB6-4156-9DA3-135E91D94ABA");
            var teamMemeberRoleId = new Guid("C489F858-AABD-4264-96C1-5CDCA251D871");
            var creatorRoleId = new Guid("71B1B0A6-7EAB-476C-B177-1D37E120184C");
            var readerRoleId = new Guid("2F0C7B75-8934-4101-BEF2-C850E42D21DE");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole() { Id = adminRoleId, Name = "admin", NormalizedName = "ADMIN", Description = "Administrator Role", CreatedBy = adminId, DateCreated = DateTime.Now },
                new AppRole() { Id = teamMemeberRoleId, Name = "teamMembers", NormalizedName = "TEAMMEMBERS", Description = "Team Members Role", CreatedBy = adminId, DateCreated = DateTime.Now },
                new AppRole() { Id = creatorRoleId, Name = "creator", NormalizedName = "CREATOR", Description = "Creator Role", CreatedBy = adminId, DateCreated = DateTime.Now },
                new AppRole() { Id = readerRoleId, Name = "reader", NormalizedName = "READER", Description = "Reader Role", CreatedBy = adminId, DateCreated = DateTime.Now });

            var appUserDefaultNull = new AppUser();

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = adminId,
                    UserName = "quangbdhz",
                    NormalizedUserName = "ADMIN",
                    Email = "tranquangbdhz@gmail.com",
                    NormalizedEmail = "TRANQUANGBDHZ@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Tran",
                    LastName = "Quang",
                    DOB = new DateTime(2001, 10, 08),
                    UserImageURL = "",
                    IsDeleted = false,
                    GenderId = 1
                });

            var hikistudioId = new Guid("0AE34DB7-EA08-42D2-9AEF-098EFCDD2C1E");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = hikistudioId,
                    UserName = "hikistudio",
                    NormalizedUserName = "HIKISTUDIO",
                    Email = "hikistudio@hiki.space",
                    NormalizedEmail = "HIKISTUDIO@HIKI.SPACE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "HikiStudio",
                    UserImageURL = "",
                    DOB = new DateTime(2000, 05, 08),
                    IsDeleted = false,
                    IsPasswordChanged = true,
                    DatePasswordChanged = DateTime.Now,
                    GenderId = 2
                });

            var teamMemeberId = new Guid("3E3245CB-BC7B-4C08-AD09-72FBD736FC9A");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = teamMemeberId,
                    UserName = "lionelmessi",
                    NormalizedUserName = "YUKINO",
                    Email = "lionelmessi@hiki.space",
                    NormalizedEmail = "LIONELMESSI@HIKI.SPACE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Lionel",
                    LastName = "Messi",
                    DOB = new DateTime(1990, 10, 08),
                    UserImageURL = "",
                    IsDeleted = false,
                    IsPasswordChanged = true,
                    DatePasswordChanged = DateTime.Now,
                    GenderId = 1
                });

            var creatorId = new Guid("D8682AA6-255A-4B31-AEAA-1AFF35A8BE58");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = creatorId,
                    UserName = "creator",
                    NormalizedUserName = "CREATOR",
                    Email = "creator@hiki.space",
                    NormalizedEmail = "CREATOR@HIKI.SPACE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Creator",
                    LastName = "HikiStudio",
                    DOB = new DateTime(2001, 10, 08),
                    UserImageURL = "",
                    IsDeleted = false,
                    IsPasswordChanged = true,
                    DatePasswordChanged = DateTime.Now,
                    GenderId = 2
                });

            var readerId = new Guid("4354ACBC-A32A-4A28-B865-DEB49695171F");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = readerId,
                    UserName = "reader",
                    NormalizedUserName = "READER",
                    Email = "reader@hiki.space",
                    NormalizedEmail = "READER@HIKI.SPACE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Reader",
                    LastName = "HikiStudio",
                    DOB = new DateTime(2001, 10, 08),
                    UserImageURL = "",
                    IsDeleted = false,
                    IsPasswordChanged = true,
                    DatePasswordChanged = DateTime.Now,
                    GenderId = 3
                });

            modelBuilder.Entity<AppUserRole>().HasData(
                new AppUserRole() { RoleId = adminRoleId, UserId = adminId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = adminId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = adminRoleId, UserId = hikistudioId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = hikistudioId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = teamMemeberRoleId, UserId = teamMemeberId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = teamMemeberId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = creatorRoleId, UserId = creatorId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = creatorId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = readerId, AppUserRoleId = Guid.NewGuid() });

            modelBuilder.Entity<Language>().HasData(
                new Language() { LanguageID = 1, LanguageName = "English", CreatedBy = adminId, DateCreated = DateTime.Now, IsDeleted = false });

            modelBuilder.Entity<VocabularyType>().HasData(
                new VocabularyType() { VocabularyTypeID = 1, VocabularyTypeName = "900 Vocabulary", IsDeleted = false, CreatedBy = adminId, DateCreated = DateTime.Now },
                new VocabularyType() { VocabularyTypeID = 2, VocabularyTypeName = "Adjective", IsDeleted = false, CreatedBy = adminId, DateCreated = DateTime.Now },
                new VocabularyType() { VocabularyTypeID = 3, VocabularyTypeName = "Adverb", IsDeleted = false, CreatedBy = adminId, DateCreated = DateTime.Now },
                new VocabularyType() { VocabularyTypeID = 4, VocabularyTypeName = "Verb", IsDeleted = false, CreatedBy = adminId, DateCreated = DateTime.Now },
                new VocabularyType() { VocabularyTypeID = 5, VocabularyTypeName = "Reading", IsDeleted = false, CreatedBy = adminId, DateCreated = DateTime.Now },
                new VocabularyType() { VocabularyTypeID = 6, VocabularyTypeName = "Listening", IsDeleted = false, CreatedBy = adminId, DateCreated = DateTime.Now });

            modelBuilder.Entity<PronunciationType>().HasData(
                new PronunciationType() { PronunciationTypeID = 1, PronunciationTypeName = "Vocal US", Description = "", CreatedBy = adminId, DateCreated = DateTime.Now, IsDeleted = false },
                new PronunciationType() { PronunciationTypeID = 2, PronunciationTypeName = "Vocal UK", Description = "", CreatedBy = adminId, DateCreated = DateTime.Now, IsDeleted = false });
        }
    }
}
