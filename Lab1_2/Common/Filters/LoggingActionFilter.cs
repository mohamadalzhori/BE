using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Text;
using System.Xml;

namespace Lab_1.Common.Filters
{
    public class LoggingActionFilter : Attribute, IActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
            var statusCode = context.HttpContext.Response.StatusCode;

            var logs = new StringBuilder();

            logs.Append($"Action executed: {context.ActionDescriptor.DisplayName}\n");
            logs.Append($"Response status code: {statusCode}\n");

            if (result is ObjectResult objectResult)
            {
                var json = JsonConvert.SerializeObject(objectResult.Value, Newtonsoft.Json.Formatting.Indented);
                logs.Append($"Result JSON: {json}\n");
            }

            //if (result is not null)
            //{
            //     var json = JsonConvert.SerializeObject(((ObjectResult)result).Value, Newtonsoft.Json.Formatting.Indented);
            //    logs.Append($"Result JSON: {json}\n");
            //}

            _logger.LogInformation(logs.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var logs = new StringBuilder();

            logs.Append($"Action executing: {context.ActionDescriptor.DisplayName}\n");

            foreach (var (key, value) in context.ActionArguments)
            {
                logs.Append($"Parameter: {key} = {value}\n");
            }

            _logger.LogInformation(logs.ToString());
        }

    }
}
