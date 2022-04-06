using Auvo.Nayckerson.AppClima.WebMVC.Controllers;
using Auvo.Nayckerson.AppClima.WebMVC.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Auvo.Nayckerson.AppClima.WebMVC
{
    public class MvcApplication : HttpApplication
    {
        private readonly ServiceCollection services;

        public MvcApplication()
        {
            services = new ServiceCollection();
        }

       
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            services.AddTransient<Context>();
            services.AddTransient<HomeController>();

            var provider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                ValidateScopes = true
            });

            ControllerBuilder.Current.SetControllerFactory(
                new MsDiControllerFactory(provider));
        }

        
        /// Referencia: https://stackoverflow.com/questions/68861721/integrating-microsoft-extensions-dependencyinjection-in-asp-net-4-6-1-project
        
        public class MsDiControllerFactory : DefaultControllerFactory
        {
            private readonly ServiceProvider provider;

            public MsDiControllerFactory(ServiceProvider provider) => this.provider = provider;

            protected override IController GetControllerInstance(
                RequestContext requestContext, Type controllerType)
            {
                IServiceScope scope = this.provider.CreateScope();

                HttpContext.Current.Items[typeof(IServiceScope)] = scope;

                return (IController)scope.ServiceProvider.GetRequiredService(controllerType);
            }

            public override void ReleaseController(IController controller)
            {
                base.ReleaseController(controller);

                var scope = HttpContext.Current.Items[typeof(IServiceScope)] as IServiceScope;

                scope?.Dispose();
            }
        }
    }
}
