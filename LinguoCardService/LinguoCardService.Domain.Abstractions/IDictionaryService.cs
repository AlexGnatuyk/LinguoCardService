using LinguoCardService.DataContracts;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IDictionaryService
    {
        WordDictionary GetById(int id);
        WordDictionary GetByOriginallWord(string original);
        WordDictionary GetByTranslateWord(string translate);
        WordDictionary AddWord(string original, string translate);
        WordDictionary UpdateWord(int id, string newWord);
        bool DeleteWord(int id);
    }
}