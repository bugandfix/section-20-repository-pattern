using BugAndFix_Car_Insurance.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BugAndFix_Car_Insurance.API.Filter.ActionFilters
{
    public class CarValidateMadeInAndCapacityFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var ContextData =(Car?)context.ActionArguments["carData"];
            var carId = ContextData?.CarId as int?;

            var CarMadeIn = ContextData?.MadeIN;
            var CarCapacity = ContextData?.Capacity as int?;

            if (carId.HasValue)
            {
                if (CarMadeIn == "Germany" && CarCapacity > 4)
                {
                    context.ModelState.AddModelError("Capacity", "German Cars can NOT have more than 4 capacity");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }


            }
        }
    }
}

