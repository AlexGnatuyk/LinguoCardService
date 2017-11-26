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
        public WordDictionary GetById(int id)
        {
            var connectionString =
                @"Data Source=.\sqlexpress;Initial Catalog=LinguoCards;Persist Security Info=True;User ID=sa;Password=MsSql2008";


            DataContext db = new DataContext(connectionString);

            // Получаем таблицу пользователей

            var query = from u in db.GetTable<WordDictionary>()
                where u.Id == id
                select u;
            return query.FirstOrDefault();
        }

        public WordDictionary GetByOriginallWord(string original)
        {
            throw new System.NotImplementedException();
        }

        public WordDictionary GetByTranslateWord(string translate)
        {
            throw new System.NotImplementedException();
        }
    }
}