using LinguoCardService.DataContracts;
using LinguoCardService.Repositories;
using NUnit.Framework;

namespace LinguoCardServiceTests.Repositories
{
    [TestFixture()]
    public class WordDictionaryRepositoryTests
    {
        public WordDictionary GetWordDictionary()
        {
            var expected = new WordDictionary
            {
                Id = 1,
                EnglishValue = "Car",
                RussianValue = "Машина"
            };

            return expected;
        }

        [Test()]
        public void GetByOriginallWordTest_ValidParametrs()
        {
            var expected = GetWordDictionary();
            var repository = new WordDictionaryRepository();
            var original = "Car";

            var result = repository.GetByOriginalWord(original);

            if(expected.Id==result.Id && expected.EnglishValue==result.EnglishValue&&expected.RussianValue==result.RussianValue) Assert.IsTrue(true);
            else
            {
                Assert.IsFalse(true);
            }
            
        }

        [Test()]
        public void GetByIdTest_ValidParametrs()
        {
            var expected = GetWordDictionary();
            var repository = new WordDictionaryRepository();
            var id = 1;

            var result = repository.GetById(id);

            if (expected.Id == result.Id && expected.EnglishValue == result.EnglishValue && expected.RussianValue == result.RussianValue) Assert.IsTrue(true);
            else
            {
                Assert.IsFalse(true);
            }
        }

        [Test()]
        public void GetByTranslatelWordTest_ValidParametrs()
        {
            var expected = GetWordDictionary();
            var repository = new WordDictionaryRepository();
            var translate = "Машина";

            var result = repository.GetByTranslateWord(translate);

            if (expected.Id == result.Id && expected.EnglishValue == result.EnglishValue && expected.RussianValue == result.RussianValue) Assert.IsTrue(true);
            else
            {
                Assert.IsFalse(true);
            }
        }
        [Test()]
        public void GetByTranslatelWordTest_UnValidParametrs()
        {
            var expected = GetWordDictionary();
            var repository = new WordDictionaryRepository();
            var translate = "dsfsdf";

            var result = repository.GetByTranslateWord(translate);

            Assert.IsNull(result);
        }
    }
}