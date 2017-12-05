using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Repositories;
using LinguoCardService.Services.Facades;
using LinguoCardService.Services.Services;
using NLog;


namespace LinguoCardService.DependencyInjection
{
    /// <summary>
    /// Web Api extension methods
    /// </summary>
    public static class WebApiExtentions
    {
        /// <summary>
        /// Composes web api services
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ContainerBuilder RegisterHttpServices(this ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            return builder;
        }

        /// <summary>
        /// Composes Domain Services
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ContainerBuilder RegisterDomainServices(this ContainerBuilder builder)
        {
            builder.RegisterType<WordDictionaryRepository>().As<IWordDictionaryRepository>();
            builder.RegisterType<DictionaryService>().As<IDictionaryService>();
            builder.RegisterType<CardGroupsRepository>().As<ICardGroupsRepository>();
            builder.RegisterType<CardGoupsService>().As<ICardGroupsService>();
            builder.RegisterType<QuizService>().As<IQuizService>();
            builder.RegisterType<YandexTranslateService>().As<IYandexTranslateService>();
            builder.RegisterType<GroupFacade>().As<IGroupFacade>();
            

            return builder;
        }

        /// <summary>
        /// Composes logging services
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ContainerBuilder RegisterLoggingServices(this ContainerBuilder builder)
        {
            builder.Register(c => LogManager.GetLogger("LinguoCardService")).As<ILogger>();
            //builder.RegisterType<LogManager>().As<ILogger>();

            return builder;
        }
    }
}