using NUnit.Framework;
using LinguoCardService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinguoCardService.DataContracts;

namespace LinguoCardService.Repositories.Tests
{
    [TestFixture()]
    public class WordDictionaryRepositoryTests
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
        public void GetByOriginallWordTest_ValidParametrs()
        {
            var expected = GetWordDictionary();
            var repository = new WordDictionaryRepository();
            var original = "Car";

            var result = repository.GetByOriginallWord(original);

            if(expected.Id==result.Id && expected.Original==result.Original&&expected.Translate==result.Translate) Assert.IsTrue(true);
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

            if (expected.Id == result.Id && expected.Original == result.Original && expected.Translate == result.Translate) Assert.IsTrue(true);
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

            if (expected.Id == result.Id && expected.Original == result.Original && expected.Translate == result.Translate) Assert.IsTrue(true);
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