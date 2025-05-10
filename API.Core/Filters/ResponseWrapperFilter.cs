using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Core.Filters
{
    public class ResponseWrapperFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult objectResult &&
                objectResult.StatusCode >= 200 && objectResult.StatusCode < 300)
            {
                var correlationId = context.HttpContext.Items["CorrelationId"]?.ToString();

                var wrapped = new
                {
                    status = "success",
                    correlationId = correlationId, // Optional: include in body too
                    data = objectResult.Value
                };

                context.Result = new ObjectResult(wrapped)
                {
                    StatusCode = objectResult.StatusCode
                };
            }

            await next();
        }
    }
}