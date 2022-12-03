using Contracts.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TemplateApi
{
    public class ExceptionFilter : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (HttpStatusException ex)
            {
                await HandleHttpExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleHttpExceptionAsync(HttpContext context, HttpStatusException exception)
        {
            context.Response.ContentType = "application/json";

            //check if is an auth exception
            if (exception.Message.Equals("UNAUTHORIZED"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                var json = new
                {
                    HasError = true,
                    context.Response.StatusCode,
                    Message = exception.Message.Contains("See the inner exception for details.") ? exception.InnerException.Message : exception.Message
                };

                return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            }
            else if (exception.Message.Equals("NOTFOUND"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                var json = new
                {
                    HasError = true,
                    context.Response.StatusCode,
                    Message = exception.Message.Contains("See the inner exception for details.") ? exception.InnerException.Message : exception.Message
                };

                return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            }
            else
            {
                var json = new
                {
                    HasError = true,
                    context.Response.StatusCode,
                    Message = exception.Message.Contains("See the inner exception for details.") ? exception.InnerException.Message : exception.Message
                };

                return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            //check if is an auth exception
            if (exception.Message.Equals("UNAUTHORIZED"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                var json = new
                {
                    HasError = true,
                    context.Response.StatusCode,
                    Message = exception.Message.Contains("See the inner exception for details.") ? exception.InnerException.Message : exception.Message
                };

                return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            }
            else
            {
                var json = new
                {
                    HasError = true,
                    context.Response.StatusCode,
                    Message = exception.Message.Contains("See the inner exception for details.") ? exception.InnerException.Message : exception.Message
                };

                return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            }
        }
    }

    public static class ExceptionFilterExtension
    {
        public static IServiceCollection AddGlobalExceptionHandlerMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<ExceptionFilter>();
        }

        public static void UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionFilter>();
        }
    }
}
