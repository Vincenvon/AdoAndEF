using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebUi.Ifrastructure;
using WebUI.Infrastructure;
using System.Configuration;




namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            if (ConfigurationManager.AppSettings["repository"].ToString() == "EF")
            {
                ControllerBuilder.Current.SetControllerFactory(new EFControllerFactory());
            }
            else
            {
                ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            }
        }
    }
}
