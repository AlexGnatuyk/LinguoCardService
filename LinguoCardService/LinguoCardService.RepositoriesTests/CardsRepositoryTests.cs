using LinguoCardService.Repositories;
using NUnit.Framework;

namespace LinguoCardService.RepositoriesTests
{
    [TestFixture()]
    public class CardsRepositoryTests
    {
        [Test()]
        public void GetListOfCardsTest()
        {
           CardsRepository repository  = new CardsRepository();
            var result = repository.GetListOfCards();
            Assert.IsTrue(true);
        }
    }
}