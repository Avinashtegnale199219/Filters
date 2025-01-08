using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FilterProject.Models
{
    public class ErrorHandlerFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILoggerService _LoggerService;
        public ErrorHandlerFilterAttribute(ILoggerService LoggerService)
        {
            _LoggerService = LoggerService;
        }
        public override void OnException(ExceptionContext context)
        {
            string message = $"An error occurred in {context.ActionDescriptor.DisplayName}: {context.Exception}";

            _LoggerService.Log(message);

            // Set the result to redirect to the generic error view
            context.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml",  // Explicit path to the view
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState)
                {
                    {"Exception", context.Exception} // Optionally pass exception data to the view
                }
            };

            context.ExceptionHandled = true; // Mark exception as handled
        }
    }

}