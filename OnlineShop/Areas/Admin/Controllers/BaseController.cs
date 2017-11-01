using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //    // GET: Admin/Base
        //    public ActionResult Index()
        //    {
        //        return View();
        //    }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session =(UserLogin)Session[Common.CommonConstants.USER_SESSION];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login",action = "index",Area = "Admin"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}