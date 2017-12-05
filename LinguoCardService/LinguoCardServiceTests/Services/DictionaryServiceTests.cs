using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Services.Services;
using Moq;
using NLog;
using NUnit.Framework;

namespace LinguoCardServiceTests.Services
{
    [TestFixture()]
    public class DictionaryServiceTests
    {
        private readonly WordDictionary _expectedDictionary = new WordDictionary
        {
            Id = 1,
            EnglishValue = "Car",
            RussianValue = "Машина"
        };

        private Mock<ILogger> _mockLogger;
        private Mock<IWordDictionaryRepository> _mockDictionaryRepo;
        
        private IDictionaryService _service;

        [SetUp]
        public void Initialization()
        {
            _mockLogger = new Mock<ILogger>();
            _mockDictionaryRepo = new Mock<IWordDictionaryRepository>();
            _mockDictionaryRepo
                .Setup(a => a.GetById(1))
                .Returns(_expectedDictionary);
            _mockDictionaryRepo
                .Setup(a => a.GetByOriginalWord("Car"))
                .Returns(_expectedDictionary);
            _mockDictionaryRepo
                .Setup(a => a.GetByTranslateWord("Машина"))
                .Returns(_expectedDictionary);
            _mockDictionaryRepo
                .Setup(a => a.AddWord("Car","Машина"))
                .Returns(_expectedDictionary);
            _mockDictionaryRepo
                .Setup(a => a.DeleteWord(1))
                .Returns(true);
            _mockDictionaryRepo
                .Setup(a => a.UpdateWord(1,"Car"))
                .Returns(_expectedDictionary);

            _service = new DictionaryService(_mockDictionaryRepo.Object,_mockLogger.Object);
        }

        [Test()]
        public void GetByIdTests_AllIsOk()
        {
            //Act
            var result = _service.GetById(1);
            
            //Assert
            Assert.AreEqual(_expectedDictionary,result);
        }

        [Test()]
        public void GetByOriginalTests_AllIsOk()
        {
            //Act
            var result = _service.GetByOriginallWord("Car");

            //Assert
            Assert.AreEqual(_expectedDictionary,result);
        }
        [Test()]
        public void GetByTranslateTests_AllIsOk()
        {
            //Act
            var result = _service.GetByTranslateWord("Машина");

            //Assert
            Assert.AreEqual(_expectedDictionary, result);
        }

        [Test()]
        public void DeleteWords_AllIsOk()
        {
            //Act
            var result = _service.DeleteWord(1);

            //Assert
            Assert.IsTrue(result);
        }

        [Test()]
        public void UpdateWords_AllIsOk()
        {
            //Act
            var result = _service.UpdateWord(1,"Car");

            //Assert
            Assert.AreEqual(_expectedDictionary,result);
        }
    }
}