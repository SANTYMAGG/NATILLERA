using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NATILLERA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // HABILITAR CORS PARA TODOS LOS ORÍGENES (PRUEBAS)
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Resto de configuración
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
