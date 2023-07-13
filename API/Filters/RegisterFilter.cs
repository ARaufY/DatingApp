using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Filters
{
    public class RegisterFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key, 
                        kvp => kvp.Value.Errors
                            .Select(x => x.ErrorMessage))
                    .ToList();
                var errorResponse = new ErrorResp();
                foreach (var errorModel in from error 
                    in errorsInModelState from subError 
                    in error.Value select new Message(){Id = 69, Details = subError})
                {
                    
                    errorResponse.Messages.Add(errorModel);
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            await next();
        }
    }
}