using HikiStudio.LearnVocabulary.ViewModels.Common.API;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface ITempVocabularyWordService
    {
        Task<APIResponse<bool>> SaveDataTempToDB();
    }
}
