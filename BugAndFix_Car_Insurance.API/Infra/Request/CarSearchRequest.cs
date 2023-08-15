using System.ComponentModel.DataAnnotations;

namespace BugAndFix_Car_Insurance.API.Infra.Request
{
    public class CarSearchRequest : CustomRequest
    {
        public int CarId { get; set; }
        
        public string? Brand { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }

        public int? Capacity { get; set; }

        public string? MadeIN { get; set; }

        public double? Price { get; set; }
    }
}
