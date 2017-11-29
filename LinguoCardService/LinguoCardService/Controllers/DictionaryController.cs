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
        /// <param name="id"></param>
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
        /// Get a tranlate in English by Russian word
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
        /// Get a tranlate in Russian by English word
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

    }
}