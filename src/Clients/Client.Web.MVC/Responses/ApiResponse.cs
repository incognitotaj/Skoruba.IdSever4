namespace Client.Web.MVC.Responses
{
    public class ApiResponse<T> where T : class
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}
