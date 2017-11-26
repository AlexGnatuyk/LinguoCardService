using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using LinguoCardService.DependencyInjection;

namespace LinguoCardService
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

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
            
            return builder.Build();
        }
    }
}