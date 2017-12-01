using System;
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
    }
}