using Common;
using Frameworks.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Frameworks.Middlewares {
    public static class CustomExceptionHandlerMiddlewareExtensions {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }

    public class CustomExceptionHandlerMiddleware {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(
            RequestDelegate next,
            IWebHostEnvironment env,
            ILogger<CustomExceptionHandlerMiddleware> logger
            ) {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next(context);
            }
            catch (Exception exception) {
                await catcher(context, exception);
            }
        }

        async Task catcher(HttpContext context, Exception exception) {
            HttpStatusCode httpStatusCode;
            ApiResultStatusCode apiStatusCode = ApiResultStatusCode.ServerError;
            string? message = null;

            async Task WriteToResponseAsync() {
                if (context.Response.HasStarted) {
                    throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");
                }

                var result = new ApiResult(false, apiStatusCode, message);
                var json = JsonConvert.SerializeObject(result);

                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }

            async Task SetUnAuthorizeResponse() {
                httpStatusCode = HttpStatusCode.Unauthorized;
                apiStatusCode = ApiResultStatusCode.UnAuthorized;

                if (_env.IsDevelopment()) {
                    var dic = new Dictionary<string, string> {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace ?? ""
                    };
                    //! for auth
                    //if (exception is SecurityTokenExpiredException tokenException)
                    //    dic.Add("Expires", tokenException.Expires.ToString());

                    message = JsonConvert.SerializeObject(dic);
                }

                await WriteToResponseAsync();
            }

            async Task SetExceptionResponse() {
                _logger.LogError(exception, exception.Message);
                httpStatusCode = HttpStatusCode.BadRequest;

                if (_env.IsDevelopment()) {
                    var dic = new Dictionary<string, string> {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace ?? "",
                    };
                    message = JsonConvert.SerializeObject(dic);
                }
                else {
                    message = exception.Message;
                }
                await WriteToResponseAsync();
            }

            if (context.Request.Path.ToString().ToLower().StartsWith(@"/api")) {
                switch (exception) {
                    //! for auth
                    //case SecurityTokenExpiredException ex:
                    //    await SetUnAuthorizeResponse();
                    //    break;
                    case UnauthorizedAccessException ex:
                        await SetUnAuthorizeResponse();
                        break;
                    default:
                        await SetExceptionResponse();
                        break;
                }
            }
            else {
                _logger.LogError(exception, exception.Message);
                context.Response.Redirect("Error", false, false);
            }
        }
    }
}
