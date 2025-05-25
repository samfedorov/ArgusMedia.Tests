namespace ArgusMedia.Tests.Models.Requests
{
    public class BillRequestModel
    {
        public BillRequestModel() { }
        
        public BillRequestModel(IEnumerable<Guid> clientIds, bool isSplit) 
        {
            ClientIds = clientIds;
            IsSplit = isSplit;
        }

        public IEnumerable<Guid> ClientIds { get; set; }

        public bool IsSplit { get; set; } = false;
    }
}
