using ArgusMedia.Tests.Models.Response;

namespace ArgusMedia.Tests.Common.Helpers
{
    public static class ProductResponseModelExtensions
    {
        public static ProductResponseModel GetProductByName(this List<ProductResponseModel> products, string productName)
            => products.FirstOrDefault(x => x.Name == productName);
    }
}
