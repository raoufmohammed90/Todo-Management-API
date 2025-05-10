using FluentValidation;
using GTS.TodoMgmt.WebApi.Dtos;
using GTS.ToDoMgmt.Application.Exceptions.Application;
using Newtonsoft.Json;
using System.Net;

namespace GTS.TodoMgmt.WebApi.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (FluentValidation.ValidationException ex)
            {
                await HandleValidationException(context, ex);
            }
            catch (UseCaseException ex)
            {
                await HandleApplicationUseCaseException(context, ex);
            }
            catch (Exception ex)
            {
                await HandleInternalServerErrorsExceptions(context, ex);
            }
        }

        private async Task HandleApplicationUseCaseException(HttpContext context, UseCaseException ex)
        {
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Response.ContentType = "application/json";
            ErrorDto response = new ErrorDto
            {
                Status = StatusCodes.Status409Conflict,
                Message = ex.Message,
                Timestamp = DateTime.UtcNow
            };
            await context.Response.WriteAsJsonAsync(response);
        }
        private async Task HandleValidationException(HttpContext context, ValidationException ex)
        {
            ErrorDto errorDto = new ErrorDto()
            {
                Status = (int)HttpStatusCode.BadRequest,
                Message = "Validation Error",
                Timestamp = DateTime.Now,
                Context = ex.Errors.Select( err => new Context
                {
                    Key = err.ErrorCode,
                    Value = err.ErrorMessage
                }).ToArray()
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            string jsonResponse = JsonConvert.SerializeObject(errorDto);
            await context.Response.WriteAsync(jsonResponse);
        }
        private async Task HandleInternalServerErrorsExceptions(HttpContext context, Exception ex)
        {
            ErrorDto errorDto = new ErrorDto()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Message = "Internal Server Error",
                Timestamp = DateTime.Now
            };
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            string jsonResponse = JsonConvert.SerializeObject(errorDto);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
