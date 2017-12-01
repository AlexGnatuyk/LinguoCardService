using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Repositories
{
    public class CardsRepository : Repository, ICardListRepository
    {
        public List<int> GetListOfCards()
        {
            List<int> cardsId = new List<int>();
            var request = $"SELECT distinct CardGroups.Main_Card as id FROM CardGroups";

            using (var connection = Connection)
            {
                connection.Open();
                var commande = new SqlCommand(request, connection);
                var response = commande.ExecuteReader();
                if (!response.HasRows) throw new ArgumentException();
                while (response.Read())
                {
                    cardsId.Add((int) response["id"]) ;
                }
                return cardsId;
            }
            throw new ArgumentException();
        }
    }
}