using HikiStudio.LearnVocabulary.ViewModels.Common.API;

namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IAudioClipService
    {
        Task<APIResponse<string>> DownloadAndSaveMP3Async(string audioUrl, string savePath, string key, string vocabularyTypeName);

        Task<APIResponse<string>> GetInfoFileMP3WithKey(string key, string vocabularyTypeName = "Test");
    }
}
