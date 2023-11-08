using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiStudio.LearnVocabulary.APIIntegration.Services
{
    public class Mp3APIClient : BaseAPI, IMp3APIClient
    {
        public Mp3APIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<byte[]?> GetMp3Data(long audioClipID)
        {
            return await GetAsync<byte[]?>($"/api/mp3/open/{audioClipID}");
        }
    }
}
