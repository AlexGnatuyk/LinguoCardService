using System;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using LinguoCardService.Repositories;
using NLog;

namespace LinguoCardService.Services.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly IWordDictionaryRepository _repository;
        private readonly ILogger _logger;

        public DictionaryService(IWordDictionaryRepository repository, ILogger logger)
        {
            _logger = logger;
            this._repository = repository ??
                              throw new ArgumentNullException(nameof(WordDictionaryRepository));
        }

        public WordDictionary GetById(int id)
        {
            _logger.Info($"[DictionaryService] The dictionary with id {id} was requested ");
            var requestResult = _repository.GetById(id);

            return requestResult;
        }

        public WordDictionary GetByOriginallWord(string original)
        {
            _logger.Info($"[DictionaryService] The dictionary with ENGLISH word {original} was requested ");
            var requestResult = _repository.GetByOriginalWord(original);
            return requestResult;
        }

        public WordDictionary GetByTranslateWord(string translate)
        {
            _logger.Info($"[DictionaryService] The dictionary with RUSSIAN word {translate} was requested ");
            var requestResult = _repository.GetByTranslateWord(translate);
            return requestResult;
        }

        public WordDictionary AddWord(string original, string translate)
        {
            _logger.Info($"[DictionaryService] The dictionary with original: {original} and translate: {translate} was added ");
            var requestResult= _repository.AddWord(original,translate);
            return requestResult;
        }

        public WordDictionary UpdateWord(int id, string newWord)
        {
            _logger.Info($"[DictionaryService] The word with id {id} was updated on {newWord} ");
            var resultRequest = _repository.UpdateWord(id, newWord);
            return resultRequest;
        }

        public bool DeleteWord(int id)
        {
            _logger.Info($"[DictionaryService] The dictionary with id {id} was deleted ");
            var resultRequest = _repository.DeleteWord(id);
            return resultRequest;
        }
    }
}