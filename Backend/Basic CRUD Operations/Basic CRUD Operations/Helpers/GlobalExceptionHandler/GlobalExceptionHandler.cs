using Basic_CRUD_Operations.Models;
using System.Net;
using System.Text.Json;

namespace Basic_CRUD_Operations.Helpers.GlobalExceptionHandler
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly APIResponse _response;
        private readonly IHostEnvironment _host;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger,
                IHostEnvironment host)
        {
            _logger = logger;
            _response = new APIResponse();
            _host = host;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error occurred while processing the request Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Message = _host.IsDevelopment() ?
                    $"{ex?.Message} {ex?.InnerException?.Message}"
                    : $"An error occurred. Please contact the system administrator";
                var serializedResponse = JsonSerializer.Serialize(_response);
                await context.Response.WriteAsync(serializedResponse);
            }
        }
    }
}
