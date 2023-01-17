using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreOfBuild.Domain;

namespace StoreOfBuild.Web.Filter
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool IsAjax = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            if(IsAjax)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 500;
                var message = context.Exception is DomainException ? context.Exception.Message : "Aconteu um erro inesperado";
                context.Result = new JsonResult(message);
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}