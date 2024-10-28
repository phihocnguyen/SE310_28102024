using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SE310_28102024.Models.Authentication
{
    public class Authentication:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("UserName") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller", "Access" },
                    {"Action", "Login" }
                });

            } else if(context.HttpContext.Session.GetString("UserName") == "admin")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller", "admin" },
                    {"Action", "homeadmin" }
                });
            }
        }
    }
}
