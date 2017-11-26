using NUnit.Framework;
using LinguoCardService.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguoCardService.Services.Repositories.Tests
{
    [TestFixture()]
    public class WordDictionaryRepositoryTests
    {
        [Test()]
        public void GetByIdTest()
        {
            var repository = new WordDictionaryRepository();
            var result = repository.GetById();
            Assert.Fail();
        }
    }
}