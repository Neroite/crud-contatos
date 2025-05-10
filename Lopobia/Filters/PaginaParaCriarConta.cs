using Lopobia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Lopobia.Filters
{
    public class PaginaParaCriarConta : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("sessaoUsuarioLogado") != null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller","Home"},{"action","Index"} });
            }
                base.OnActionExecuting(context);
        }
    }
}
