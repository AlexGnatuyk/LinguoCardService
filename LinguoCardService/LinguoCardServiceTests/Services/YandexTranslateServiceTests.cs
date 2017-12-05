using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Services.Services;
using Moq;
using NLog;
using NUnit.Framework;

namespace LinguoCardServiceTests.Services
{
    [TestFixture()]
    public class YandexTranslateServiceTests
    {
        private readonly WordDictionary _expectedDictionary = new WordDictionary
        {
            Id = 1,
            EnglishValue = "Car",
            RussianValue = "Машина"
        };

        private Mock<ILogger> _mockLogger;
        private Mock<IWordDictionaryRepository> _mockDictionaryRepo;

        private IYandexTranslateService _service;

        [SetUp]
        public void Initialization()
        {
            _mockLogger = new Mock<ILogger>();
            _mockDictionaryRepo = new Mock<IWordDictionaryRepository>();
            _mockDictionaryRepo
                .Setup(a => a.AddWord("original", "translate"))
                .Returns(_expectedDictionary);


            _service = new YandexTranslateService(_mockDictionaryRepo.Object, _mockLogger.Object);
        }

        [Test()]
        public void GetTranslateTest_AllIsOk()
        {
            // Act
            var result = _service.GetTranslate("Ром", Language.En);

            // Assert
            Assert.AreEqual("Rum", result);
        }
    }
}