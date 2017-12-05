using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using LinguoCardService.DependencyInjection;

namespace LinguoCardService
{
    /// <summary>
    /// Autifac config
    /// </summary>
    public class AutofacWebapiConfig
    {
        /// <summary>
        /// IoC
        /// </summary>
        public static IContainer Container;

        /// <summary>
        /// Register dependency
        /// </summary>
        /// <param name="config"></param>
        public static void SetDependencyResolver(HttpConfiguration config)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(
                BuildContainer()
            );
        }
        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterHttpServices();
            builder.RegisterDomainServices();
            builder.RegisterLoggingServices();
            
            return builder.Build();
        }
    }
}