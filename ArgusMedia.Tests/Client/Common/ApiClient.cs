using System.Text;
using System.Text.Json;

namespace ArgusMedia.Tests.Client
{
    public class ApiClient: IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient 
            {
                BaseAddress = new Uri(baseUrl)                
            };
        }

        public async Task DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        public async Task<TResponseModel> GetAsync<TResponseModel>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await DeserializeAsync<TResponseModel>(response);
        }

        public async Task<TResponseModel> PostAsync<TRequestModel, TResponseModel>(string url, TRequestModel requestModel)
        {
            var content = new StringContent(JsonSerializer.Serialize(requestModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            return await DeserializeAsync<TResponseModel>(response);
        }

        private async Task<TResponseModel> DeserializeAsync<TResponseModel>(HttpResponseMessage httpResponseMessage)
        {
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseModel = JsonSerializer.Deserialize<TResponseModel>(responseContent, _jsonOptions);
            return responseModel;
        }
    }
}
