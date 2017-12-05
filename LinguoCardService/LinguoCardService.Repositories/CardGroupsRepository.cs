using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LinguoCardService.DataContracts.Models;
using LinguoCardService.Domain.Abstractions;
using NLog;

namespace LinguoCardService.Repositories
{
    public class CardGroupsRepository : Repository,ICardGroupsRepository
    {
        private readonly ILogger _logger;

        public CardGroupsRepository(ILogger logger)
        {
            _logger = logger;
        }

        public bool AddGroup(int mainId, int additionalId)
        {
            var request =
                $"INSERT INTO [dbo].[CardGroups] ([Main_Card],[Additional_Card]) VALUES({mainId},{additionalId})";
            using (var connection = Connection)
            {
                connection.Open();
                var commande = new SqlCommand(request,connection);
                var response = commande.ExecuteNonQuery();
                if (response > 0) return true;
            }
            _logger.Error($"[CardGroupsRepository] The repository did't add the proup with mainId {mainId}, additionalId {additionalId}");
            return false;
        }

        public List<int> GetListOfCards()
        {
            
            var request = $"SELECT distinct CardGroups.Main_Card as id FROM CardGroups";

            using (var connection = Connection)
            {
                var cardsId = new List<int>();
                connection.Open();
                var commande = new SqlCommand(request, connection);
                var response = commande.ExecuteReader();
                if (!response.HasRows)
                {
                    _logger.Error($"[CardGroupsRepository] Repo cant get list of cards");
                    throw new ArgumentException();
                }
                while (response.Read())
                {
                    cardsId.Add((int)response["id"]);
                }
                return cardsId;
            }
        }

        public bool DeleteGroupOfCard(int mainId)
        {
            var request = $"DELETE FROM [dbo].[CardGroups] WHERE Main_Card = {mainId}";

            using (var connection = Connection)
            {
                connection.Open();
                var commande = new SqlCommand(request, connection);
                var response = commande.ExecuteNonQuery();
                if (response > 0) return true;
            }
            _logger.Error($"[CardGroupsRepository] Cant't delete Group with mainId {mainId}");
            return false;
        }

        public List<int> GetAdditionalCards(int mainId)
        {
           
            var request = $"SELECT distinct CardGroups.Additional_Card as id FROM CardGroups where CardGroups.Main_Card = '{mainId}'";

            using (var connection = Connection)
            {
                var cardsId = new List<int>();
                connection.Open();
                var commande = new SqlCommand(request, connection);
                var response = commande.ExecuteReader();
                if (!response.HasRows)
                {   _logger.Error($"[CardGroupsRepository] Repo can't get AdditionalList");
                    throw new ArgumentException();
                }
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