using ArgusMedia.Tests.Client;
using ArgusMedia.Tests.Common.Helpers;
using ArgusMedia.Tests.Models.Requests;
using ArgusMedia.Tests.Models.Response;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ArgusMedia.Tests.Steps
{
    [Binding]
    public class RestaurantBillingSteps
    {
        private List<OrderResponseModel> _orderResponse { get; set; } = new();
        private static RestaurantApiManager _apiManager;
        private static ProductResponseModel _starterProduct;
        private static ProductResponseModel _mainsProduct;
        private static ProductResponseModel _drinksProduct;

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            _apiManager = new RestaurantApiManager();
            var products = await _apiManager.ProductController.GetAllProducts();
            _starterProduct = products.GetProductByName("Starters");
            _mainsProduct = products.GetProductByName("Mains");
            _drinksProduct = products.GetProductByName("Drinks");
        }

        private List<CreateOrderRequestModel> AddOrders(int productCount, Guid clientId, Guid productId, DateTime createDate)
        {
            var orders = new List<CreateOrderRequestModel>();
            for (int i = 0; i < productCount; i++)
            {
                orders.Add(new CreateOrderRequestModel(clientId, productId, createDate));
            }
            return orders;
        }

        [Given(@"the following group order at (.*):")]
        [When(@"the following group order at (.*):")]
        public async Task GivenGroupOrderAsync(string time, Table table)
        {
            var orderTime = DateTimeParser.ParseStringTimeHourMinutes(time);
            var ordersRequestModel = new List<CreateOrderRequestModel>();
            foreach (var row in table.Rows)
            {
                var clientId = Guid.NewGuid();
                int starters = int.Parse(row["Starters"]);
                int mains = int.Parse(row["Mains"]);
                int drinks = int.Parse(row["Drinks"]);

                ordersRequestModel.AddRange(AddOrders(starters, clientId, _starterProduct.Id, orderTime));
                ordersRequestModel.AddRange(AddOrders(mains, clientId, _mainsProduct.Id, orderTime));
                ordersRequestModel.AddRange(AddOrders(drinks, clientId, _drinksProduct.Id, orderTime));
            }

            _orderResponse.AddRange(await _apiManager.OrderController.MakeOrderAsync(ordersRequestModel));
        }

        [When(@"one client cancels their order")]
        public async Task WhenOneClientCancelsOrderAsync()
        {
            var cancelledClientId = _orderResponse.First().ClientId;
            var clientOrders = _orderResponse.Where(o => o.ClientId == cancelledClientId).ToList();

            foreach (var order in clientOrders)
            {
                await _apiManager.OrderController.DeleteOrderAsync(order.Id);
            }
        }

        [Then(@"the total amount should be \u00a3(.*), service charge should be \u00a3(.*) and discount should be \u00a3(.*)")]
        public async Task ThenTheTotalAmountShouldBeAsync(decimal totalAmount, decimal serviceChargeAmount, decimal discountAmount)
        {
            var clientsId = _orderResponse.Select(m => m.ClientId).Distinct().ToList();
            var billRequestModel = new BillRequestModel(clientsId, false);
            var bill = await _apiManager.BillController.CalculateBillAsync(billRequestModel);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(totalAmount, bill.FirstOrDefault().TotalBill, "The Total amount is not as expected");
                Assert.AreEqual(serviceChargeAmount, bill.FirstOrDefault().ServiceCharge, "The ServiceCharge amount is not as expected");
                Assert.AreEqual(discountAmount, bill.FirstOrDefault().Discount, "The Discount amount is not as expected");
            });
        }
    }
}
