using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using NLog;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// Yandex Translate Controller
    /// </summary>
    [RoutePrefix(WebApiConfig.RoutePrefix)]
    public class YandexTranslateController : ApiController
    {
        private readonly IYandexTranslateService _service;
        private readonly ILogger _logger;

        /// <summary>
        /// Controller's constuctor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public YandexTranslateController(IYandexTranslateService service, ILogger logger)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Get a translation from Yandex Translate
        /// </summary>
        /// <param name="original">Word which is would be translate</param>
        /// <param name="language">Switch destination of translate(ru or en)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("YandexTranslate/Translate")]
        public string Translate(string original, Language language)
        {
            _logger.Info($"[YandexTranslateController] Был запросшен перевод слова {original} через Yandex Translate");
            var result = _service.GetTranslate(original, language);
            return result;
        }
    }
}
