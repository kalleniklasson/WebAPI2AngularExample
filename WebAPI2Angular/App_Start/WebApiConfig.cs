using System.Globalization;
using System.Web.Http;
using Newtonsoft.Json.Converters;
using WebAPI2Angular.DAL;
using WebAPI2Angular.IoC;
using WebAPI2Angular.Models;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebAPI2Angular
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AdjustToUniversal });
            // DateTimeZoneHandling will be effective during deserialization
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new UnityResolver(GetUnityContainer());
        }

        public static IUnityContainer GetUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRepository<Person>, Repository<Person>>(new InjectionConstructor(typeof(IUnitOfWork)));

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}
