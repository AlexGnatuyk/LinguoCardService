using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Repositories;
using LinguoCardService.Services.Services;


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
            builder.RegisterType<CardGroupsRepository>().As<ICardGroupsRepository>();
            builder.RegisterType<CardGoupsService>().As<ICardGroupsService>();
            builder.RegisterType<QuizService>().As<IQuizService>();
            builder.RegisterType<YandexTranslateService>().As<IYandexTranslateService>();

            return builder;
        }
    }
}