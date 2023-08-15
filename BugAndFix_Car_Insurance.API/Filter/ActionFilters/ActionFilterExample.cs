using Microsoft.AspNetCore.Mvc.Filters;

namespace BugAndFix_Car_Insurance.API.Filter.ActionFilters
{
    public class ActionFilterExample : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Executing before...");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Executing after...");
        }
    }



}
