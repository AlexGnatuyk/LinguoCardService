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
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(WordDictionary),
            Description = "Translate word by id")]
        public IHttpActionResult GetTranslateById(int id)
        {
            var result = _dictionaryService.GetById(id);
            return Content(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Get a translate in English by Russian word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Dictionary/translate/ru-en/{word}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(WordDictionary),
            Description = "Translate word from russian to english")]
        public IHttpActionResult GetTranslateByRussianWord(string word)
        {
            var result = _dictionaryService.GetByTranslateWord(word);
            return Content(HttpStatusCode.OK, result);
        }
        /// <summary>
        /// Get a translate in Russian by English word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Dictionary/translate/en-ru/{word}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(WordDictionary),
            Description = "Translate word from english to russian")]
        public IHttpActionResult GetTranslateByEnglishWord(string word)
        {
            var result = _dictionaryService.GetByOriginallWord(word);
            return Content(HttpStatusCode.OK, result);
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
        public IHttpActionResult AddWordsInDictionary(string original, string translate)
        {
            var result = _dictionaryService.SetWord(original, translate);
            return Content(HttpStatusCode.OK, result);
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
        public IHttpActionResult UpdateWordInDictionary(int id, string newWord)
        {
            var result = _dictionaryService.UpdateWord(id, newWord);
            return Content(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Delete Word and translation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Dictionary/Delete/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Word and translation was successfully delete")]
        public IHttpActionResult DeleteWordById(int id)
        {
            var result = _dictionaryService.DeleteWord(id);
            return Content(HttpStatusCode.OK, result);
        }

    }
}