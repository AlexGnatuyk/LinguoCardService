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
            // WARNING : Wrog request/ It's just translate, but it must be a serch by id
            var requset = "select  Words.value from Words, (select Words.id as id from Words where Words.value = 'шляпа') t1, Dictionary where Dictionary.russian_id = t1.id and Dictionary.english_id = Words.id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand commande = new SqlCommand(requset, connection);
                var response = commande.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        object idresponse = response.GetValue(0);
                    }
                }

            }


            DataContext db = new DataContext(_connectionString);

            var query = from u in db.GetTable<WordDictionary>()
                where u.Id == id
                select u;
            return query.FirstOrDefault();
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
            DataContext db = new DataContext(_connectionString);

            // Получаем таблицу пользователей

            var query = from u in db.GetTable<WordDictionary>()
                where u.Translate == translate
                select u;
            return query.FirstOrDefault();
        }

        public void SetWord(string original, string translate)
        {
            throw new System.NotImplementedException();
        }
    }
}