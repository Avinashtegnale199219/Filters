using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace FilterProject.Models
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch? _timer = null;

        private readonly ILoggerService _LoggerService;
        public LoggingFilterAttribute(ILoggerService LoggerService)
        {
            _LoggerService = LoggerService;
        }

        //before controller action method called
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _timer = Stopwatch.StartNew();

            var actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var parameters = JsonConvert.SerializeObject(context.ActionArguments);

            string message = $"Starting {controllerName}.{actionName} with parameters {parameters}";
            _LoggerService.Log(message);
            base.OnActionExecuting(context);
        }

        //after controller action method called
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _timer?.Stop();
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];

            string message = $"Finished {controllerName}.{actionName} in {_timer.ElapsedMilliseconds}ms";

            _LoggerService.Log(message);

            base.OnActionExecuted(context);
        }
    }
}
