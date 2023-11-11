using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using Microsoft.EntityFrameworkCore;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class FavouriteCourseService : IFavouriteCourseService
    {
        private readonly LanguageLearningDbContext _context;

        public FavouriteCourseService(LanguageLearningDbContext context)
        {
            _context = context;
        }

        public async Task<APIResponse<bool>> ChangeFavouriteCourseAsync(int courseID)
        {
            var checkFavouriteCourseExist = await _context.FavouriteCourses.FirstOrDefaultAsync(x => x.CourseID == courseID && x.UserID == SystemConstants.AppSettings.CreateByDefault);

            //create
            if (checkFavouriteCourseExist == null) {
                var result = await CreateFavouriteCourseAsync(courseID);

                if (!result.IsSuccessed)
                {
                    return result;
                }
                return new APISuccessResponse<bool>() { ResultObj = true, Message = result.Message };
            }
            //delete
            else
            {
                var result = await DeleteFavouriteCourseAsync(courseID);

                if (!result.IsSuccessed)
                {
                    return result;
                }
                return new APISuccessResponse<bool>() { ResultObj = false, Message = result.Message };
            }
        }

        public async Task<APIResponse<bool>> CreateFavouriteCourseAsync(int courseID)
        {
            var checkFavouriteCourseExist = await _context.FavouriteCourses.FirstOrDefaultAsync(x => x.CourseID == courseID && x.UserID == SystemConstants.AppSettings.CreateByDefault);

            if (checkFavouriteCourseExist != null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectAlreadyExists(nameof(FavouriteCourse)) };

            var favouriteCourse = new FavouriteCourse()
            {
                CourseID = courseID,
                IsDeleted = false,
                UserID = SystemConstants.AppSettings.CreateByDefault,
                DateCreated = DateTime.Now,
                CreatedBy = SystemConstants.AppSettings.CreateByDefault
            };

            await _context.FavouriteCourses.AddAsync(favouriteCourse);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new APISuccessResponse<bool>() { Message = MessageConstants.CreateSuccess(nameof(FavouriteCourse)) };

            return new APIErrorResponse<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateFavouriteCourseAsync), nameof(FavouriteCourse)) };
        }

        public async Task<APIResponse<bool>> DeleteFavouriteCourseAsync(int courseID)
        {
            var checkFavouriteCourseExist = await _context.FavouriteCourses.FirstOrDefaultAsync(x => x.CourseID == courseID && x.UserID == SystemConstants.AppSettings.CreateByDefault);

            if (checkFavouriteCourseExist == null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(FavouriteCourse)) };

            _context.FavouriteCourses.Remove(checkFavouriteCourseExist);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new APISuccessResponse<bool>() { Message = MessageConstants.DeleteSuccess(nameof(FavouriteCourse)) };

            return new APIErrorResponse<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(DeleteFavouriteCourseAsync), nameof(FavouriteCourse)) };
        }
    }
}
