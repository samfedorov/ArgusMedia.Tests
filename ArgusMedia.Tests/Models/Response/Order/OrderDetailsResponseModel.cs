namespace ArgusMedia.Tests.Models.Response
{
    public class OrderDetailsResponseModel
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public Guid ProductId { get; set; }

        public decimal Price { get; set; }
    }
}
