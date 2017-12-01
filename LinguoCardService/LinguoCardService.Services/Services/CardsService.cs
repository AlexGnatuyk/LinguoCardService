using System;
using System.Collections.Generic;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Services.Services
{
    public class CardsService : ICardsService
    {
        private readonly ICardListRepository _repository;
        public CardsService(ICardListRepository repository)
        {
            this._repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
        }

        public List<int> GetListOfcards()
        {
            return _repository.GetListOfCards();
        }
    }
}