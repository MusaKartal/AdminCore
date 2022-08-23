using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminCore.Business.Filters
{
    public class AdminFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            int? AdminId = context.HttpContext.Session.GetInt32("id");
            if (!AdminId.HasValue)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"action","Login"},
                        {"controller","Account" }
                    });
            }
            base.OnActionExecuted(context);
        }
    }
}
