using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.Domain.Abstractions;
using NLog;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// Test controller
    /// </summary>
    [RoutePrefix(WebApiConfig.RoutePrefix)]
    public class QuizController : ApiController
    {
        private readonly IQuizService _service;
        private readonly ILogger _logger;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public QuizController(IQuizService service, ILogger logger)
        {
            _logger = logger;
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
            _logger.Info($"[QuizController] Checking of  dictionary with id {dictionaryId} and word {chosenValue} was requested ");
            var result = _service.CheckQuiz(dictionaryId, chosenValue);
            if (result == false) return $"{chosenValue} - uncorrect translate";
            return $"Yes, {chosenValue} it's a correct translate";
        }
    }
}