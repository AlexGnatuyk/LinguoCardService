﻿using System;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Repositories;

namespace LinguoCardService.Services.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly IWordDictionaryRepository _repository;
        public DictionaryService(IWordDictionaryRepository repository)
        {
            this._repository = repository ??
                              throw new ArgumentNullException(nameof(WordDictionaryRepository));
        }

        public WordDictionary GetById(int id, string language)
        {
            var requestResult = _repository.GetById(id, language);

            return requestResult;
        }

        public WordDictionary GetByOriginallWord(string original)
        {
            var requestResult = _repository.GetByOriginallWord(original);
            return requestResult;
        }

        public WordDictionary GetByTranslateWord(string translate)
        {
            var requestResult = _repository.GetByTranslateWord(translate);
            return requestResult;
        }

        public WordDictionary SetWord(string original, string translate)
        {
            var requestResult= _repository.SetWord(original,translate);
            return requestResult;
        }
    }
}