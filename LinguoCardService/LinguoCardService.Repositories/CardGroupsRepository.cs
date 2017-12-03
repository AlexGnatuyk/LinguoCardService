using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LinguoCardService.DataContracts.Models;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Repositories
{
    public class CardGroupsRepository : Repository,ICardGroupsRepository
    {
        private readonly IWordDictionaryRepository _dictionaryRepository;
        public CardGroupsRepository(IWordDictionaryRepository dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository 
                ?? throw new ArgumentNullException(nameof(dictionaryRepository));
        }

        public CardGroup GetGroup(int id)
        {
            CardGroup resultGroup = new CardGroup();

            var mainCard = new Card(_dictionaryRepository.GetById(id));

            if (mainCard == null) throw new ArgumentException();
            List<Card> mainCardList = new List<Card> {mainCard};
            var additionald = GetListOfAdditionalCards(mainCard.Id);
            
            for (int i = 0; i < additionald.Count; i++)
            {
                Card temp = new Card(_dictionaryRepository.GetById(additionald[i]));
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

        public bool AddGroup(int mainId, int additionalId)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetListOfAdditionalCards(int mainId)
        {
            List<int> cardsId = new List<int>();
            var request = $"SELECT distinct CardGroups.Additional_Card as id FROM CardGroups where CardGroups.Main_Card = '{mainId}'";

            using (var connection = Connection)
            {
                connection.Open();
                var commande = new SqlCommand(request, connection);
                var response = commande.ExecuteReader();
                if (!response.HasRows) throw new ArgumentException();
                while (response.Read())
                {
                    cardsId.Add((int)response["id"]);
                }
                return cardsId;
            }
            throw new ArgumentException();
        }
    }
}