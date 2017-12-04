using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LinguoCardService.Startup))]

namespace LinguoCardService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            AutofacWebapiConfig.SetDependencyResolver(config);
            app.UseWebApi(config);
        }
    }
}
