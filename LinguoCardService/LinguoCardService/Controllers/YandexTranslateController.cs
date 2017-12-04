using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// Yandex Translate Controller
    /// </summary>
    [RoutePrefix(WebApiConfig.RoutePrefix)]
    public class YandexTranslateController : ApiController
    {
        private readonly IYandexTranslateService _service;

        /// <summary>
        /// Controller's constuctor
        /// </summary>
        /// <param name="service"></param>
        public YandexTranslateController(IYandexTranslateService service)
        {
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
            var result = _service.GetTranslate(original, language);
            return result;
        }
    }
}
