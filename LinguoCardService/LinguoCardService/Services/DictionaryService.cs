using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Repositories;

namespace LinguoCardService.Services
{
    public class DictionaryService : IDictionaryServices
    {
        private readonly WordDictionaryRepository _repository;
        public DictionaryService(WordDictionaryRepository repository)
        {
            this._repository = repository ??
                              throw new ArgumentNullException(nameof(WordDictionaryRepository));
        }

        public WordDictionary GetById(int id)
        {
            var requestResult = _repository.GetById(id);

            return requestResult;
        }

        public WordDictionary GetByOriginallWord(string original)
        {
            throw new NotImplementedException();
        }

        public WordDictionary GetByTranslateWord(string translate)
        {
            throw new NotImplementedException();
        }

        public void SetWord(string original, string translate)
        {
            throw new NotImplementedException();
        }
    }
}