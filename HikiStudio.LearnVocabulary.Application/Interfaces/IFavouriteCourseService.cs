using HikiStudio.LearnVocabulary.ViewModels.Common.API;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IFavouriteCourseService
    {
        Task<APIResponse<bool>> ChangeFavouriteCourseAsync(int courseID);

        Task<APIResponse<bool>> CreateFavouriteCourseAsync(int courseID);

        Task<APIResponse<bool>> DeleteFavouriteCourseAsync(int courseID);
    }
}
