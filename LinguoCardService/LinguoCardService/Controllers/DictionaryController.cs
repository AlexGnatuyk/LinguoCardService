using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using NLog;
using Swashbuckle.Swagger.Annotations;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// Dictionary Controller
    /// </summary>
    [RoutePrefix(WebApiConfig.RoutePrefix)]
    public class DictionaryController : ApiController
    {
        private readonly IDictionaryService _dictionaryService;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor injection
        /// </summary>
        /// <param name="dictionaryServices"></param>
        /// <param name="logger"></param>
        public DictionaryController(IDictionaryService dictionaryServices, ILogger logger)
        {
            _logger = logger;
            this._dictionaryService = dictionaryServices 
                ?? throw new ArgumentNullException(nameof(dictionaryServices));
        }


        /// <summary>
        /// Gets a given dictionary
        /// </summary>
        /// <param name="id">Id of word</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Dictionary/{id}")]
        public WordDictionary GetTranslateById(int id)
        {
            _logger.Info($"[DictionaryController] The dictionary with id {id} was requested ");
            return _dictionaryService.GetById(id);
            
        }

        /// <summary>
        /// Get a translation by word
        /// </summary>
        /// <param name="word">Word what shuld be translated</param>
        /// <param name="language">You should choose from which language you want translate Eng - 0, Ru - 1</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Dictionary/translate/{word}")]
        public WordDictionary GetTranslateByWord(string word, Language language = Language.En)
        {
            _logger.Info($"[DictionaryController] The dictionary with word {word} was requested ");
            if (language.ToString() == "Ru") return _dictionaryService.GetByTranslateWord(word);
            return _dictionaryService.GetByOriginallWord(word);
        }
        
        /// <summary>
        /// Add you own word and translation in dictionary
        /// </summary>
        /// <param name="original">Word in English</param>
        /// <param name="translate">Word in Russian</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Dictionaty/AddWord/{original}-{translate}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(WordDictionary),
            Description = "Word was added in dictionary")]
        public WordDictionary AddWordsInDictionary(string original, string translate)
        {
            _logger.Info($"[DictionaryController] The dictionary with original: {original} and translate: {translate} was added ");
            return _dictionaryService.AddWord(original, translate);
           
        }

        /// <summary>
        /// Update Word in dictionary
        /// </summary>
        /// <param name="oldValue">Old value</param>
        /// <param name="newWord"> New Value</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Dictionary/UpdateWord")]
        public bool UpdateWordInDictionary(string oldValue, string newWord)
        {
            _logger.Info($"[DictionaryController] The word with old value {oldValue} was updated on {newWord} ");
            return _dictionaryService.UpdateWord(oldValue, newWord);
            
        }

        /// <summary>
        /// Delete Word and translation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Dictionary/Delete/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Word and translation was successfully delete")]
        public bool DeleteWordById(int id)
        {
            _logger.Info($"[DictionaryController] The dictionary with id {id} was deleted ");
            return _dictionaryService.DeleteWord(id);
        }

    }
}