using System;
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

        public WordDictionary GetById(int id)
        {
            var requestResult = _repository.GetById(id);

            return requestResult;
        }

        public WordDictionary GetByOriginallWord(string original)
        {
            var requestResult = _repository.GetByOriginalWord(original);
            return requestResult;
        }

        public WordDictionary GetByTranslateWord(string translate)
        {
            var requestResult = _repository.GetByTranslateWord(translate);
            return requestResult;
        }

        public WordDictionary AddWord(string original, string translate)
        {
            var requestResult= _repository.AddWord(original,translate);
            return requestResult;
        }

        public WordDictionary UpdateWord(int id, string newWord)
        {
            var resultRequest = _repository.UpdateWord(id, newWord);
            return resultRequest;
        }

        public bool DeleteWord(int id)
        {
            var resultRequest = _repository.DeleteWord(id);
            return resultRequest;
        }
    }
}