using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Repositories;
using LinguoCardService.Services;

namespace LinguoCardService.DependencyInjection
{
    public static class WebApiExtentions
    {
        public static ContainerBuilder RegisterHttpServices(this ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            return builder;
        }

        public static ContainerBuilder RegisterDomainServices(this ContainerBuilder builder)
        {
            builder.RegisterType<WordDictionaryRepository>().As<IWordDictionaryRepository>();
            builder.RegisterType<DictionaryService>().As<IDictionaryService>();

            return builder;
        }
    }
}