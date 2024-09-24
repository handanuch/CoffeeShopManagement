using CoffeeShop.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoffeeShop.Utils.Attributes;

public class JWTAttribute : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context) { }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var master = context.ActionDescriptor.EndpointMetadata.OfType<MasterAttribute>();
        if (master.Count() > 0) return;
        if (G.CREDENTIAL)
        {
            string? crd = context.HttpContext.Request.Headers["x-crd"].ToString().ToUpper();
            string? dbc;
            DBCHelper.HOLDER.TryGetValue(crd ?? "", out dbc);
            if (crd == null || dbc == null)
            {
                context.Result = new StatusCodeResult(406);
                return;
            }
        }
    }
}