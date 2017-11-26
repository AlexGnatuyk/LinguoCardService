using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;

namespace LinguoCardService.DependencyInjection
{
    public static class WebApiExtentions
    {
        public static ContainerBuilder RegisterHttpServices(this ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            return builder;
        }
    }
}