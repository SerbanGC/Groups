using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Exceptions;

namespace Midleware
{
    public class GroupExceptionMiddleware : IMiddleware
    {


        public GroupExceptionMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (GroupException e)
            {
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}