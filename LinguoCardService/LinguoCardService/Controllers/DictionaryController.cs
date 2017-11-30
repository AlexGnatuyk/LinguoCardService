using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
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

        /// <summary>
        /// Constructor injection
        /// </summary>
        /// <param name="dictionaryServices"></param>
        public DictionaryController(IDictionaryService dictionaryServices)
        {
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
        public WordDictionary GetTranslateByWord(string word, Language language = Language.Eng)
        {
            if (language.ToString() == "ru") return _dictionaryService.GetByTranslateWord(word);
            return _dictionaryService.GetByOriginallWord(word);
        }
        
        /// <summary>
        /// Add you own word and translation in dictionary
        /// </summary>
        /// <param name="original"></param>
        /// <param name="translate"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Dictionaty/AddWord/{original}-{translate}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(WordDictionary),
            Description = "Word was added in dictionary")]
        public WordDictionary AddWordsInDictionary(string original, string translate)
        {
            return _dictionaryService.AddWord(original, translate);
           
        }

        /// <summary>
        /// Update Word in dictionary
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newWord"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Dictionary/Update/{id}-{newWord}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(WordDictionary),
            Description = "Word was added in dictionary")]
        public WordDictionary UpdateWordInDictionary(int id, string newWord)
        {
            return _dictionaryService.UpdateWord(id, newWord);
            
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
            return _dictionaryService.DeleteWord(id);
        }

    }
}