using LinguoCardService.DataContracts;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IWordDictionaryRepository
    {
        WordDictionary GetById(int id);
        WordDictionary GetByOriginalWord(string original);
        WordDictionary GetByTranslateWord(string translate);
        WordDictionary AddWord(string original, string translate);
        bool UpdateWord(string oldValue, string newValue);
        bool DeleteWord(int id);
    }
}