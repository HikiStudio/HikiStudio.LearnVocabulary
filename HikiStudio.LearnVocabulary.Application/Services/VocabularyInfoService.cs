
using System.Text.RegularExpressions;
using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class VocabularyInfoService : IVocabularyInfoService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public VocabularyInfoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<APIResponse<object>> GetVocabularyInfoWithKey(string key)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var url = $"https://dictionary.cambridge.org/dictionary/english/{key}";

                 var response = await httpClient.GetStringAsync(url);

                string pattern = "<div class=\"eg dexamp hax\">(.*?)</div>";
                var match = Regex.Match(response, pattern, RegexOptions.Singleline);

                if (match.Success)
                {
                    string extractedContent = match.Groups[1].Value;
                    return new APISuccessResponse<object>
                    {
                        ResultObj = extractedContent,
                    };
                }
                else
                {
                    return new APIErrorResponse<object>
                    {
                        Message = "Không tìm thấy nội dung với class 'eg dexamp hax'"
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIErrorResponse<object>
                {
                    Message = ex.Message
                };
            }
        }
    }
}
