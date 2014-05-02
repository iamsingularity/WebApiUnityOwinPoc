using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.ServiceRuntime;
using Owin;
using System;
using System.Diagnostics;
using System.Web.Http;

namespace AnalyticsLogger
{
    class Startup
    {
        private static readonly IUnityContainer _container = UnityHelpers.GetConfiguredContainer();

        public static void StartServer()
        {

            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["LoggingEndpoint"];
            string baseAddress = String.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);

            Trace.TraceInformation(String.Format("Starting OWIN at {0}", baseAddress), "Information");

            var startup = _container.Resolve<Startup>();
            IDisposable webApplication = WebApp.Start(baseAddress, startup.Configuration);

            //try
            //{
            //    Console.WriteLine("Started...");
            //    Console.ReadKey();
            //}
            //finally
            //{
            //    webApplication.Dispose();
            //}
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityDependencyResolver(UnityHelpers.GetConfiguredContainer());

            config.Routes.MapHttpRoute(
                "Default",
                "{controller}/{id}",
                new { id = RouteParameter.Optional });

            //config.Routes.MapHttpRoute(
            //              name: "DefaultApi",
            //              routeTemplate: "api/{controller}/{id}",
            //              defaults: new { id = RouteParameter.Optional }
            //          );

            appBuilder.UseWebApi(config);
        }
    }
}
