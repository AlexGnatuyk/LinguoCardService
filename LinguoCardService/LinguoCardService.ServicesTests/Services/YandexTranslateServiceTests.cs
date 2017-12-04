using NUnit.Framework;
using LinguoCardService.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinguoCardService.DataContracts;

namespace LinguoCardService.Services.Services.Tests
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