using System;
using System.Collections.Generic;
using LinguoCardService.DataContracts.Models;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Services.Services
{
    public class CardGoupsService : ICardGroupsService
    {
        private readonly ICardGroupsRepository _repository;

        public CardGoupsService(ICardGroupsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public CardGroup GetGroup(int id)
        {
            return _repository.GetGroup(id);
        }

        public List<int> GetListOfcards()
        {
            return _repository.GetListOfCards();
        }

        public bool AddGroup(int mainId, int additioanlId)
        {
            return _repository.AddGroup(mainId, additioanlId);
        }

        public bool DeleteGroupOfCards(int mainId)
        {
            return _repository.DeleteGroupOfCard(mainId);
        }
    }
}