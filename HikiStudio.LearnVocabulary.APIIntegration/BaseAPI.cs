using HikiStudio.LearnVocabulary.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HikiStudio.LearnVocabulary.APIIntegration
{
    public class BaseAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseAPI(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TResponse> GetAsync<TResponse>(string url, string? token = null)
        {
            using var client = CreateHttpClient(token);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            CheckResponseSuccess(response, body);
#pragma warning disable CS8603 // Possible null reference return.
            return JsonConvert.DeserializeObject<TResponse>(body);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false)
        {
            using var client = CreateHttpClient();
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            CheckResponseSuccess(response, body);
#pragma warning disable CS8603 // Possible null reference return.
            return JsonConvert.DeserializeObject<List<T>>(body);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<TResponse> PostAsync<TResponse, TData>(TData payload, string url)
        {
            using var client = CreateHttpClient();
            var json = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            CheckResponseSuccess(response, body);
#pragma warning disable CS8603 // Possible null reference return.
            return JsonConvert.DeserializeObject<TResponse>(body);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<TResponse> PutAsync<TResponse, TData>(TData payload, string url)
        {
            using var client = CreateHttpClient();
            var json = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            CheckResponseSuccess(response, body);
#pragma warning disable CS8603 // Possible null reference return.
            return JsonConvert.DeserializeObject<TResponse>(body);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string url)
        {
            using var client = CreateHttpClient();
            var response = await client.DeleteAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            CheckResponseSuccess(response, body);
#pragma warning disable CS8603 // Possible null reference return.
            return JsonConvert.DeserializeObject<TResponse>(body);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<TResponse> DeleteWithBodyAsync<TResponse, TData>(TData payload, string url)
        {
            using var client = CreateHttpClient();
            var json = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Delete, url) { Content = httpContent });
            var body = await response.Content.ReadAsStringAsync();
            CheckResponseSuccess(response, body);
#pragma warning disable CS8603 // Possible null reference return.
            return JsonConvert.DeserializeObject<TResponse>(body);
#pragma warning restore CS8603 // Possible null reference return.
        }

        private HttpClient CreateHttpClient(string? token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var baseAddress = _configuration[SystemConstants.AppSettings.BaseAddress] ?? "https://localhost:7068/";
            client.BaseAddress = new Uri(baseAddress);
            if (token != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        private void CheckResponseSuccess(HttpResponseMessage response, string body)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(body);
            }
        }
    }
}
