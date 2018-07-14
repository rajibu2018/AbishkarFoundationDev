namespace AbishkarFoundation.ApiService.RequestModel
{
    public class ResponseBase
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string Message { get; set; }
        public ResponseBase()
        {
            ResponseStatus = ResponseStatus.Success;
        }
    }
    public enum ResponseStatus
    {
        Success,
        Failur,
        Warning
    }
}
