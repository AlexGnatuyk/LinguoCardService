using LinguoCardService.DataContracts;
using LinguoCardService.Services.Services;
using NUnit.Framework;

namespace LinguoCardService.ServicesTests.Services
{
    [TestFixture()]
    public class YandexTranslateServiceTests
    {
        [Test()]
        public void GetTranslateTest()
        {
            var service = new YandexTranslateService();
            var result = service.GetTranslate("mom", Language.Ru);
            result = service.GetTranslate("мама мыла раму", Language.En);
        }
    }
}