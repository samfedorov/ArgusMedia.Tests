using ArgusMedia.Tests.Common.Configuration;

namespace ArgusMedia.Tests.Client
{
    public class RestaurantApiManager
    {
        private readonly IApiClient _apiClient;

        public BillController BillController { get; }
        public OrderController OrderController { get; }
        public ProductController ProductController { get; }

        public RestaurantApiManager()
        {
            _apiClient = new ApiClient(TestConfiguration.BaseUrl);

            BillController = new BillController(_apiClient);
            OrderController = new OrderController(_apiClient);
            ProductController = new ProductController(_apiClient);
        }
    }
}
