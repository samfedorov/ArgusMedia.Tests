using ArgusMedia.Tests.Models.Response;

namespace ArgusMedia.Tests.Client
{
    public class ProductController
    {
        private readonly IApiClient _apiClient;

        public ProductController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<ProductResponseModel>> GetAllProducts()
        {
            var response = await _apiClient.GetAsync<List<ProductResponseModel>>(RouteEndpoints.ProductEndpoint);
            return response;
        }
    }
}
