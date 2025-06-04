using NATILLERA.Clases;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

namespace NATILLERA
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureAuth(GlobalConfiguration.Configuration);

        }

        public void ConfigureAuth(HttpConfiguration config)
        {
            var jwtAuthManager = new clsAutorizacion();
            config.Filters.Add(new AuthorizeAttribute());
            config.MessageHandlers.Add(new clsJwtBearerAutorizacion(jwtAuthManager));
        }
    }
}
