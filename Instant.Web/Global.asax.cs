using System.Web.Mvc;
using System.Web.Routing;

namespace Instant.Web
{
    using Instant.Web.Controllers;
    using Instant.Web.Factories;

    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute("CreateEvent", "{controller}",
                new { controller = "Events", action = "Create" },
                new { httpMethod = new HttpMethodConstraint("POST") });

            routes.MapRoute(
                "Default", // Route name 
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ConfigureContainer();
        }

        private IWindsorContainer container;

        private void ConfigureContainer()
        {
            this.container = new WindsorContainer();

            var controllerFactory = new WindsorControllerFactory(this.container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            this.container.Install(FromAssembly.This());
        }
    }
}