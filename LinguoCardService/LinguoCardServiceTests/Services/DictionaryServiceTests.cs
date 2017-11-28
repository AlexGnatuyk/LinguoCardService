using LinguoCardService.DataContracts;
using LinguoCardService.Repositories;
using LinguoCardService.Services.Services;
using NUnit.Framework;

namespace LinguoCardServiceTests.Services
{
    [TestFixture()]
    public class DictionaryServiceTests
    {
        public WordDictionary GetWordDictionary()
        {
            var expected = new WordDictionary
            {
                Id = 1,
                Original = "Car",
                Translate = "Машина"
            };

            return expected;
        }

        [Test()]
        public void GetByIdTest()
        {
            var expected = GetWordDictionary();
            var repository = new WordDictionaryRepository();
            var service = new DictionaryService(repository);
            var id = 1;

            var result = service.GetById(id);

            if (expected.Id == result.Id && expected.Original == result.Original && expected.Translate == result.Translate) Assert.IsTrue(true);
            else
            {
                Assert.IsFalse(true);
            }
        }
    }
}