using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// Test controller
    /// </summary>
    [RoutePrefix(WebApiConfig.RoutePrefix)]
    public class QuizController : ApiController
    {
        private readonly IQuizService _service;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="service"></param>
        public QuizController(IQuizService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

       /// <summary>
        /// Check choosen values
        /// </summary>
        /// <param name="dictionaryId">Id of card</param>
        /// <param name="chosenValue">Chosen value</param>
        /// <returns>True - correct value, False - wrong vlaue</returns>
        [HttpGet]
        [Route("Quiz/Check/")]
        public string CheckQuiz(int dictionaryId, string chosenValue)
        {
            var result = _service.CheckQuiz(dictionaryId, chosenValue);
            if (result == false) return $"{chosenValue} - uncorrect translate";
            return $"Yes, {chosenValue} it's a correct translate";
        }
    }
}