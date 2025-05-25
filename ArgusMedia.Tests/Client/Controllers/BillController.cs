using ArgusMedia.Tests.Models.Requests;
using ArgusMedia.Tests.Models.Response;

namespace ArgusMedia.Tests.Client
{
    public class BillController
    {
        private readonly IApiClient _apiClient;

        public BillController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<BillResponseModel>> CalculateBillAsync(BillRequestModel requestModel)
        {
            var response = await _apiClient.PostAsync<BillRequestModel, List<BillResponseModel>>(RouteEndpoints.BillEndpoint, requestModel);
            return response;
        }
    }
}
