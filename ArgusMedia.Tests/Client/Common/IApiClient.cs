namespace ArgusMedia.Tests.Client
{
    public interface IApiClient
    {
        Task<TResponseModel> GetAsync<TResponseModel>(string url);

        Task DeleteAsync(string url);

        Task<TResponseModel> PostAsync<TRequestModel, TResponseModel>(string url, TRequestModel requestModel);
    }
}
