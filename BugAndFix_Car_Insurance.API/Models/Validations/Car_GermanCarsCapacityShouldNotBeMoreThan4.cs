using System.ComponentModel.DataAnnotations;

namespace BugAndFix_Car_Insurance.API.Models.Validations
{
    public class Car_GermanCarsCapacityShouldNotBeMoreThan4 : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var car = validationContext.ObjectInstance as Car;

            if (car != null && !string.IsNullOrWhiteSpace(car.MadeIN))
            {
                if (car.MadeIN.Equals("Germany", StringComparison.OrdinalIgnoreCase) && car.Capacity > 4)
                {
                    return new ValidationResult("German Cars can NOT have more than 4 capacity");
                }
            }

            return ValidationResult.Success;
        }
    }
}
