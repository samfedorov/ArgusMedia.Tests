using ArgusMedia.Tests.Models.Requests;
using ArgusMedia.Tests.Models.Response;

namespace ArgusMedia.Tests.Client
{
    public class OrderController
    {
        private readonly IApiClient _apiClient;

        public OrderController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<OrderResponseModel>> MakeOrderAsync(List<CreateOrderRequestModel> requestModel)
        {
            var response = await _apiClient.PostAsync<List<CreateOrderRequestModel>, List<OrderResponseModel>>(RouteEndpoints.OrderEndpoint, requestModel);
            return response;
        }

        public async Task DeleteOrderAsync(Guid orderId)
        {
            await _apiClient.DeleteAsync(RouteEndpoints.OrderDeleteEndpoint(orderId));
        }
    }
}
