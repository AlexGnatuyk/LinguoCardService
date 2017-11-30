using System.Web.Http;
using Microsoft.Owin;
using Owin;

namespace LinguoCardService
{
    
   //[assembly:OwinStartup(typeof(LinguoCardService.Startup))]
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            AutofacWebapiConfig.SetDependencyResolver(config);

            // move other lines over here
            appBuilder.UseWebApi(config);
        }
    }
}