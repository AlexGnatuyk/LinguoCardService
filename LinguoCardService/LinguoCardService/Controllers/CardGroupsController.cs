using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.DataContracts.Models;
using LinguoCardService.Domain.Abstractions;
using NLog;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// Card Groups Controller
    /// </summary>
    [RoutePrefix(WebApiConfig.RoutePrefix)]
    public class CardGroupsController : ApiController
    {
        private readonly ICardGroupsService _service;
        private readonly ILogger _logger;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public CardGroupsController(ICardGroupsService service, ILogger logger)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Get a groups of card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CardGroups/")]
        public CardGroup GetGroupById(int id)
        {
            _logger.Info($"[CardGroupsController] The group of words with id = {id} was requestet ");
            return _service.GetGroup(id);
        }

        /// <summary>
        /// Get a list of avialable cards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CardGroups/AllList")]
        public List<int> GetCardsList()
        {
            _logger.Info($"[CardGroupsController] The list of cards was requested");
            return _service.GetListOfcards();
        }

        /// <summary>
        /// Add new goup of cards, or add card in other group
        /// </summary>
        /// <param name="mainId"></param>
        /// <param name="additionalId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CardGroups/Add")]
        public bool AddGroup(int mainId, int additionalId)
        {
            _logger.Info($"[CardGroupsController] Goup with mainId {mainId} and additionalId {additionalId} was added");
            return _service.AddGroup(mainId, additionalId);
        }

        /// <summary>
        /// Delete goup of cards
        /// </summary>
        /// <param name="mainId">Id of main card in group (id of group)</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("CardGroups/Delete")]
        public bool DeleteGroupOfCards(int mainId)
        {
            _logger.Info($"[CardGroupsController] The group with mainId {mainId} was deleted ");
            return _service.DeleteGroupOfCards(mainId);
        }

    }
}
