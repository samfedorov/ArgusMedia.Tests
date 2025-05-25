namespace ArgusMedia.Tests.Models.Response
{
    public class BillResponseModel
    {
		public Guid? ClientId { get; set; }

		public IEnumerable<OrderDetailsResponseModel> Orders { get; set; }

		public decimal Bill { get; set; }

		public decimal DrinkBill { get; set; }

		public decimal FoodBill { get; set; }

		public decimal DiscountPercent { get; set; }

		public decimal ServiceChargePercent { get; set; }

		public decimal Discount { get; set; }

		public decimal ServiceCharge { get; set; }

		public decimal TotalBill { get; set; }
	}
}
