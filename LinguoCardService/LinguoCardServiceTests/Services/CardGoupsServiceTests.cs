using System.Collections.Generic;
using LinguoCardService.DataContracts;
using LinguoCardService.DataContracts.Models;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Services.Services;
using Moq;
using NLog;
using NUnit.Framework;

namespace LinguoCardServiceTests.Services
{
    [TestFixture()]
    public class CardGoupsServiceTests
    {
        private readonly WordDictionary _expectedDictionary = new WordDictionary
        {
            Id = 1,
            EnglishValue = "Car",
            RussianValue = "Машина"
        };

        private readonly List<int> _expectedList = new List<int>() {1, 2};

        private Mock<ILogger> _mockLogger;
        private Mock<ICardGroupsRepository> _mockCardGroupRepo;
        private Mock<IGroupFacade> _mockGroupFacade;

        private ICardGroupsService _service;

        [SetUp]
        public void Initialization()
        {
            _mockLogger = new Mock<ILogger>();
            _mockCardGroupRepo = new Mock<ICardGroupsRepository>();
            _mockGroupFacade = new Mock<IGroupFacade>();

            _mockCardGroupRepo
                .Setup(a => a.GetListOfCards())
                .Returns(_expectedList);
            _mockCardGroupRepo
                .Setup(a => a.DeleteGroupOfCard(1))
                .Returns(true);
            _mockCardGroupRepo
                .Setup(a => a.GetAdditionalCards(1))
                .Returns(_expectedList);
            _mockCardGroupRepo
                .Setup(a => a.AddGroup(1, 1))
                .Returns(true);
            _mockGroupFacade
                .Setup(a => a.GetGroup(1))
                .Returns(new CardGroup());
            

            _service = new CardGoupsService(_mockCardGroupRepo.Object, _mockGroupFacade.Object, _mockLogger.Object);
        }

        [Test()]
        public void GetGroupOfCards_AllIsOk()
        {
            // Act
            var result = _service.GetGroup(1);
            // Assert
            Assert.IsNotNull(result);

        }

        [Test()]
        public void GetListOfCardsTest_AllIsOk()
        {
            // Act
            var result = _service.GetListOfcards();
            // Assert
            Assert.AreEqual(_expectedList, result);

        }

        [Test()]
        public void DeleteGroupOfCar_AllIsOk()
        {
            //Act
            var result = _service.DeleteGroupOfCards(1);
            //Assert
            Assert.IsTrue(result);
        }

        [Test()]
        public void AddGroupOfCards_AllISOk()
        {
            //Act
            var result = _service.AddGroup(1, 1);
            //Assert
            Assert.IsTrue(result);
        }
    }
}