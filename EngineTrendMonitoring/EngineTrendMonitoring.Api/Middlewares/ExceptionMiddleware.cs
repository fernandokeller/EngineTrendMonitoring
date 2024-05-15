using EngineTrendMonitoring.Shared.Exceptions;
using EngineTrendMonitoring.Shared.Models.Result;
using System.Net;

namespace EngineTrendMonitoring.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        #region Properties
        private readonly RequestDelegate _next;
        #endregion

        #region Constructor
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Public Methods

        #region Invoke Async
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ce)
            {
                await HandleCustomExceptionAsync(httpContext, ce);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(httpContext);
            }
        }
        #endregion

        #endregion

        #region Private Methods

        #region Handle Exception Async
        private async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsJsonAsync(ResultModel.WithError("Something went wrong"));
        }
        #endregion

        #region Handle Custom Exception Async
        private async Task HandleCustomExceptionAsync(HttpContext context, CustomException customException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            await context.Response.WriteAsJsonAsync(customException.ResultModel);
        }
        #endregion

        #endregion
    }
}
