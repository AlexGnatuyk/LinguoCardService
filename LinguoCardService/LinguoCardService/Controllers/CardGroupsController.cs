using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.DataContracts.Models;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// Card Groups Controller
    /// </summary>
    public class CardGroupsController : ApiController
    {
        private readonly ICardGroupsService _service;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="service"></param>
        public CardGroupsController(ICardGroupsService service)
        {
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
            return _service.GetListOfcards();
        }

        /// <summary>
        /// Add new goup of cards, or add card in other group
        /// </summary>
        /// <param name="mainId"></param>
        /// <param name="additionalId"></param>
        /// <returns></returns>
        public bool AddGroup(int mainId, int additionalId)
        {
            return _service.AddGroup(mainId, additionalId);
        }
    }
}
