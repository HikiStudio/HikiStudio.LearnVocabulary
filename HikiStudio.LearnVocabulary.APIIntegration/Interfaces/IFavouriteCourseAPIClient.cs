using HikiStudio.LearnVocabulary.ViewModels.Common.API;

namespace HikiStudio.LearnVocabulary.APIIntegration.Interfaces
{
    public interface IFavouriteCourseAPIClient
    {
        Task<APIResponse<bool>> ChangeFavouriteCourseAsync(int courseID);

        Task<APIResponse<bool>> CreateFavouriteCourseAsync(int courseID);

        Task<APIResponse<bool>> DeleteFavouriteCourseAsync(int courseID);
    }
}
