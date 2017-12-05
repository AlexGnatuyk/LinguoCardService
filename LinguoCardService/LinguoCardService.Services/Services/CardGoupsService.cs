using System;
using System.Collections.Generic;
using LinguoCardService.DataContracts.Models;
using LinguoCardService.Domain.Abstractions;
using NLog;

namespace LinguoCardService.Services.Services
{
    public class CardGoupsService : ICardGroupsService
    {
        private readonly ICardGroupsRepository _repository;
        private readonly IGroupFacade _facade;
        private readonly ILogger _logger;

        public CardGoupsService(ICardGroupsRepository repository, IGroupFacade facade, ILogger logger)
        {
            _logger = logger;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public CardGroup GetGroup(int id)
        {
            _logger.Info($"[CardGoupsService] The group of words with id = {id} was requestet ");
            return _facade.GetGroup(id);
        }

        public List<int> GetListOfcards()
        {
            _logger.Info($"[CardGoupsService] The list of cards was requested");
            return _repository.GetListOfCards();
        }

        public bool AddGroup(int mainId, int additionalId)
        {
            _logger.Info($"[CardGoupsService] Goup with mainId {mainId} and additionalId {additionalId} was added");
            return _repository.AddGroup(mainId, additionalId);
        }

        public bool DeleteGroupOfCards(int mainId)
        {
            _logger.Info($"[CardGoupsService] The group with mainId {mainId} was deleted ");
            return _repository.DeleteGroupOfCard(mainId);
        }
    }
}