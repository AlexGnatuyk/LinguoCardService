using System;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Services.Repositories
{
    public class WordDictionaryRepository : IWordDictionaryRepository
    {
        public WordDictionary GetById()
        {
            var connectionString = @"Data Source=(localhost);Initial Catalog=LinguoCards;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            DataContext db = new DataContext(connectionString);

            // Получаем таблицу пользователей
            Table<WordDictionary> users = db.GetTable<WordDictionary>();
            var query = from u in db.GetTable<WordDictionary>()
                where u.Id == 1
                select u;
            foreach (var VARIABLE in query)
            {
                return VARIABLE;
            }
            throw new ArgumentException();
        }

        public WordDictionary GetByOriginallWord()
        {
            throw new System.NotImplementedException();
        }

        public WordDictionary GetByTranslateWord()
        {
            throw new System.NotImplementedException();
        }
    }
}