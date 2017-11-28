using System.Configuration;
using System.Data.Linq;
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