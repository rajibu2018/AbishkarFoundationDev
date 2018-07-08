namespace AbishkarFoundation.ApiService.RequestModel
{
    public class ResponseBase
    {
        public ResponseType ResponseType { get; set; }
    }
    public enum ResponseType
    {
        Success,
        Failur,
        Warning
    }
}
