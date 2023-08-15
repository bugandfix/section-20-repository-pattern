using System.Text.Json;

namespace BugAndFix_Car_Insurance.API.Infra.ExceptionHandler
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
