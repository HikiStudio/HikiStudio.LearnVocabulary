using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.AudioClips.DataRequest;
using HikiStudio.LearnVocabulary.ViewModels.AudioClips.DataResponse;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using System.Text;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class AudioClipService : IAudioClipService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AudioClipService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<string>> DownloadAndSaveMP3Async(string audioUrl, string savePath, string key, string vocabularyTypeName)
        {
            try
            {
                savePath += $"\\{key}.mp3";

                if (File.Exists(savePath))
                {
                    return new APISuccessResponse<string>() { ResultObj = savePath };
                }

                audioUrl = audioUrl.Replace("api.soundoftext.com/sounds", "files.soundoftext.com") + ".mp3";

                using (var client = _httpClientFactory.CreateClient())
                {
                    var response = await client.GetAsync(audioUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                        {
                            string directoryPath = Path.GetDirectoryName(savePath) ?? "Test";

                            using (FileStream fileStream = File.Create(savePath))
                            {
                                await contentStream.CopyToAsync(fileStream);
                            }
                        }

                        return new APISuccessResponse<string>() { ResultObj = $"{vocabularyTypeName}\\{key}.mp3" };
                    }
                    else
                    {
                        return new APIErrorResponse<string>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(DownloadAndSaveMP3Async), audioUrl) };
                    }
                }
            }
            catch (Exception ex)
            {
                return new APIErrorResponse<string>(ex);
            }
        }

        public async Task<APIResponse<string>> GetInfoFileMP3WithKey(string key, string vocabularyTypeName = "Test")
        {
            var client = _httpClientFactory.CreateClient();
            try
            {
                var soundRequest = SetSoundRequest(key); 
                var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(soundRequest);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(SystemConstants.AppSettings.URLDownloadFileMP3, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var soundResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<SoundResponse>(responseContent);
                    if (soundResponse is null)
                    {
                        return new APIErrorResponse<string>() { Message = MessageConstants.ObjectNotFound("soundResponse") };
                    }

                    string urlDownloadVocabularyWordMP3 = SystemConstants.AppSettings.URLDownloadFileMP3 + "/" + soundResponse.id;
                    string urlFolderLocalSaveVocabularyWordMp3 = SystemConstants.AppSettings.URLFolderSaveVocabularyWord + "\\" + vocabularyTypeName;
                    
                    if (!Directory.Exists(urlFolderLocalSaveVocabularyWordMp3))
                    {
                        Directory.CreateDirectory(urlFolderLocalSaveVocabularyWordMp3);
                    }

                    var resultDownloadAndSaveVocabularyWord = await DownloadAndSaveMP3Async(urlDownloadVocabularyWordMP3, urlFolderLocalSaveVocabularyWordMp3, key, vocabularyTypeName);

                    return resultDownloadAndSaveVocabularyWord;
                }
                else
                    return new APIErrorResponse<string>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(GetInfoFileMP3WithKey), key) };
            }
            catch (Exception ex)
            {
                return new APIErrorResponse<string>(ex);
            }
        }

        private SoundRequest SetSoundRequest(string key)
        {
            return new SoundRequest()
            {
                engine = "Google",
                data = new SoundData()
                {
                    text = key,
                    voice = "en-US"
                }
            };
        }
    }
}
