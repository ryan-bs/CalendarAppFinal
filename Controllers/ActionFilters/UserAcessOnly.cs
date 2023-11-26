using CalendarAppFinal.Data;
using Microsoft.AspNetCore.Mvc;

namespace CalendarAppFinal.Controllers.ActionFilters
{
    public class UserAcessOnly : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute, Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    {
        private DAL _dal = new DAL();

        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
            if (context.RouteData.Values.ContainsKey("id"))
            {
                int id = int.Parse((string)context.RouteData.Values["id"]);
                if (context.HttpContext.User != null)
                {
                    var username = context.HttpContext.User.Identity.Name;
                    if (username != null)
                    {
                        var myevent = _dal.GetEvento(id);
                        if (myevent.User != null)
                        {
                            if (myevent.User.UserName != username)
                            {
                                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "NotFound" }));
                            }
                        }
                    }
                }
            }
        }
    }
}

