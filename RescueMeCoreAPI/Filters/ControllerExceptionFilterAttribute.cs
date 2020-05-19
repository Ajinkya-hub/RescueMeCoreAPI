using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace RescueMeCoreAPI.Filters
{
    public class ControllerExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var e = context.Exception;
            var response = new HttpResponseMessage();
            if (e is KeyNotFoundException || e is ArgumentOutOfRangeException)
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            else if (e is ArgumentException)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            response.Content = new StringContent(e.Message);
            //context.Result = response;
        }
    }
}
