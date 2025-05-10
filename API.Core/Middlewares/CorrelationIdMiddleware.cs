using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Generate or get correlation ID from header
            var correlationId = context.Request.Headers["x-correlation-id"].FirstOrDefault()
                                ?? Guid.NewGuid().ToString();

            // Store in HttpContext for downstream usage
            context.Items["CorrelationId"] = correlationId;

            // Add to response header
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["x-correlation-id"] = correlationId;
                return Task.CompletedTask;
            });

            try
            {
                await _next(context); // Call next middleware
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Unhandled exception with CorrelationId: {CorrelationId}", correlationId);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    Error = ex.ToString(), //"An unexpected error occurred.",
                    //Error = "An unexpected error occurred.",
                    CorrelationId = correlationId
                });
            }
        }
    }
}