namespace ArgusMedia.Tests.Models.Requests
{
    public class CreateOrderRequestModel
    {
        public CreateOrderRequestModel() { }

        public CreateOrderRequestModel(Guid clientId, Guid productId, DateTime createdDate) 
        {
            ClientId = clientId;
            ProductId = productId;
            CreatedDate = createdDate;
        }

        public Guid ProductId { get; set; }

        public Guid ClientId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
