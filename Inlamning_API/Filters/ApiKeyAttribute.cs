using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Inlamning_API.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "Key";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>(key: "ApiKey");

            if(!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var providedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if(!apiKey.Equals(providedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();

        }
    }
}
