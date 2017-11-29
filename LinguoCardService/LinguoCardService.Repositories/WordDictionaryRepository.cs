using System;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Repositories
{
    public class WordDictionaryRepository : IWordDictionaryRepository
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        public WordDictionary GetById(int id)
        {
            var responseObject = new WordDictionary();
            string request = null;

            if (id % 2 == 0)
            {
                request =
                    $"select t1.value as Russian, Words.value as English from Words,(select Dictionary.id as id, Words.value as value, Dictionary.english_id as englishID from Words, Dictionary where Words.id = '{id}' and Dictionary.russian_id = Words.id) t1 where Words.id=t1.englishID;";
            }
            else
            {
                request = $"select t1.value as English, Words.value as Russian from Words,(select Dictionary.id as id, Words.value as value, Dictionary.russian_id as russianID from Words, Dictionary where Words.id = '{id}' and Dictionary.english_id = Words.id) t1 where Words.id=t1.russianID;";
            }
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var commande = new SqlCommand(request, connection);
                var response = commande.ExecuteReader();
                if (!response.HasRows) return responseObject;
                while (response.Read())
                {
                    responseObject.Id = id;
                    responseObject.Original = response["English"] as string;
                    responseObject.Translate = response["Russian"] as string;
                }
            }
            return responseObject;
        }

        public WordDictionary GetByOriginallWord(string original)
        {
            DataContext db = new DataContext(_connectionString);

            // Получаем таблицу пользователей

            var query = from u in db.GetTable<WordDictionary>()
                where u.Original == original
                select u;
            return query.FirstOrDefault();
        }

        public WordDictionary GetByTranslateWord(string translate)
        {
            var responseObject = new WordDictionary();
            var requset = $"select Words.id, Words.value  from Words,  (select Words.id as id from Words where Words.value = '{translate}') t1,  Dictionary where Dictionary.russian_id = t1.id and Dictionary.english_id = Words.id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand commande = new SqlCommand(requset, connection);
                var response = commande.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        responseObject.Id = response["id"] as int? ?? 0;
                        responseObject.Original = response["value"] as string;
                        responseObject.Translate = translate;
                    }
                }

            }
            return responseObject;
        }

        public void SetWord(string original, string translate)
        {
            throw new System.NotImplementedException();
        }
    }
}