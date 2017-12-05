using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Services.Services;
using Moq;
using NLog;
using NUnit.Framework;

namespace LinguoCardServiceTests.Services
{
    [TestFixture()]
    public class QuizServiceTests
    {
        private readonly WordDictionary _expectedDictionary = new WordDictionary
        {
            Id = 1,
            EnglishValue = "Car",
            RussianValue = "Машина"
        };

        private Mock<ILogger> _mockLogger;
        private Mock<IWordDictionaryRepository> _mockDictionaryRepo;

        private IQuizService _service;

        [SetUp]
        public void Initialization()
        {
            _mockLogger = new Mock<ILogger>();
            _mockDictionaryRepo = new Mock<IWordDictionaryRepository>();
            _mockDictionaryRepo
                .Setup(a => a.GetById(1))
                .Returns(_expectedDictionary);

            _service = new QuizService(_mockDictionaryRepo.Object, _mockLogger.Object);
        }

        [Test()]
        public void CheckQuizTest_ValidParametrs_AllIsOk()
        {
            //Act
            var result = _service.CheckQuiz(1, "Машина");
            //Assert
            Assert.IsTrue(result);
        }

        [Test()]
        public void CheckQuizTest_UnValidParametrs_AllIsOk()
        {
            //Act
            var result = _service.CheckQuiz(1, "Cat");
            //Assert
            Assert.IsFalse(result);
        }
    }
}