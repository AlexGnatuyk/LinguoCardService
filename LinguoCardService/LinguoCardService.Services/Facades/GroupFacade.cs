using System;
using System.Collections.Generic;
using LinguoCardService.DataContracts.Models;
using LinguoCardService.Domain.Abstractions;
using NLog;

namespace LinguoCardService.Services.Facades
{
    public class GroupFacade :IGroupFacade
    {
        private readonly ICardGroupsRepository _cardGroupRepository;
        private readonly IWordDictionaryRepository _dictionaryRepository;
        private readonly ILogger _logger;

        public GroupFacade(
            ICardGroupsRepository cardGroupRepository, 
            IWordDictionaryRepository dictionaryRepository, 
            ILogger logger)
        {
            _logger = logger;
            _cardGroupRepository = cardGroupRepository ?? throw new ArgumentNullException(nameof(cardGroupRepository));
            _dictionaryRepository = dictionaryRepository ?? throw new ArgumentNullException(nameof(dictionaryRepository));
        }

        public CardGroup GetGroup(int id)
        {
            _logger.Info($"[GroupFacade] The group of words with id = {id} was requestet ");
            var resultGroup = new CardGroup();

            var mainCard = new Card(_dictionaryRepository.GetById(id));

            if (mainCard == null)
            {
                _logger.Error($"[GroupFacade] Main card is null with groupId {id}");
                throw new ArgumentException();
            }
            var mainCardList = new List<Card> { mainCard };
            var additionald = _cardGroupRepository.GetAdditionalCards(mainCard.Id);

            for (var i = 0; i < additionald.Count; i++)
            {
                var temp = new Card(_dictionaryRepository.GetById(additionald[i]));
                mainCardList[i].AdditinalWord = temp.RussianValue;
                if (i == additionald.Count - 1)
                {
                    temp.AdditinalWord = mainCardList[i].RussianValue;
                }
                mainCardList.Add(temp);

            }
            resultGroup.Id = mainCard.Id;
            resultGroup.Cards = mainCardList;
            return resultGroup;
        }
       
    }
}