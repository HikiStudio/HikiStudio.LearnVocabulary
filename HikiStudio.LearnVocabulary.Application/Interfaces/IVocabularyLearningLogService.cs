using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyLearningLogs;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IVocabularyLearningLogService
    {
        Task<PagedResponse<VocabularyLearningLogViewModel>> GetPagingVocabularyLearningLogAsync(PagedRequest request);

        Task<APIResponse<VocabularyLearningLogViewModel>> ReadVocabularyLearningLog();

        Task<APIResponse<bool>> WriteVocabularyLearningLog(TimeSpan duration);
    }
}
