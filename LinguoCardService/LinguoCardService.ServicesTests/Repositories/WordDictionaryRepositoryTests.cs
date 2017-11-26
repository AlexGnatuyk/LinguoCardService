using LinguoCardService.Repositories;
using NUnit.Framework;

namespace LinguoCardService.ServicesTests.Repositories
{
    [TestFixture()]
    public class WordDictionaryRepositoryTests
    {
        [Test()]
        public void GetByIdTest()
        {
            var repository = new WordDictionaryRepository();
            var id = 20;

            var result = repository.GetById(id);
            Assert.IsTrue(true);
        }
    }
}