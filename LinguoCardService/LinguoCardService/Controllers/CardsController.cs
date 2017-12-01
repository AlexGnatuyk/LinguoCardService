using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// CardsController
    /// </summary>
    [RoutePrefix(WebApiConfig.RoutePrefix)]
    public class CardsController : ApiController
    {
        private readonly ICardsService _service;
        
        /// <summary>
        /// Cards controller constuctor
        /// </summary>
        /// <param name="service"></param>
        public CardsController(ICardsService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Get a list of avialable cards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Cards/")]
        public List<int> GetCardsList()
        {
            return _service.GetListOfcards();
        }
    }
}