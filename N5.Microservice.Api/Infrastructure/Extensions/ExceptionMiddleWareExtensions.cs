using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using DDDCQRS.Microservice.Api.Exceptions;
using Serilog;

namespace DDDCQRS.Microservice.Api.Infrastructure.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(
            this IApplicationBuilder app,
            IConfiguration configuration)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var errorDetails = GetErrorDeatils(contextFeature);
                        context.Response.StatusCode = errorDetails.StatusCode;

                        Log.Error("{appName} {timeStamp} {statusCode} {message} {exception}",
                            configuration["appName"], DateTime.UtcNow, errorDetails.StatusCode, errorDetails.Message,
                            contextFeature.Error);

                        await context.Response.WriteAsync(errorDetails.ToString());
                    }
                });
            });
        }

        private static ErrorDetails GetErrorDeatils(IExceptionHandlerFeature contextFeature)
        {
            // Controlled Exceptions 
            return contextFeature.Error switch
            {
                // Fluent Validators in IRequest Instances 
                InvalidRequestException invalidRequestException => new ErrorDetails
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = $"Bad Request Invalid Request Exception: {invalidRequestException.Message}",
                    Detail = invalidRequestException.Details
                },
                // Guard Validatations
                ArgumentException argumentException => new ErrorDetails
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Message = "Argument Exception (Guard)",
                    Detail = argumentException.Message
                },
                // Any Fluent Rules Business Validations 
                ValidationException validationException => new ErrorDetails
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Message = "Conflict Business Validation",
                    Detail = validationException.Message
                },

                // Exception Not Controlled => Internal Server Error
                _ => new ErrorDetails()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Internal Server Error"
                },
            };
        }
    }
}