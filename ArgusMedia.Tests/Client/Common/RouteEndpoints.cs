namespace ArgusMedia.Tests.Client
{
    public static class RouteEndpoints
    {
        public static string OrderEndpoint
            => "api/order";

        public static string OrderDeleteEndpoint(Guid orderId)
            => $"api/order/{orderId}";

        public static string ProductEndpoint
            => "api/product";

        public static string BillEndpoint
            => "api/bill";

    }
}
