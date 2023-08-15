namespace BugAndFix_Car_Insurance.API.Filter.ExceptionFilter
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 400;

        public string Message { get; set; }

        public HttpResponseException(string message)
        {
            this.Message = message;
        }
    }
}
