using LinguoCardService.DataContracts;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IDictionaryService
    {
        WordDictionary GetById(int id);
        WordDictionary GetByOriginallWord(string original);
        WordDictionary GetByTranslateWord(string translate);
        WordDictionary AddWord(string original, string translate);
        bool UpdateWord(string oldValue, string newWord);
        bool DeleteWord(int id);
    }
}