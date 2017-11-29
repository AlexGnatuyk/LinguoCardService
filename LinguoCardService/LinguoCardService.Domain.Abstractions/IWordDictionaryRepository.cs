using LinguoCardService.DataContracts;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IWordDictionaryRepository
    {
        WordDictionary GetById(int id);
        WordDictionary GetByOriginalWord(string original);
        WordDictionary GetByTranslateWord(string translate);
        WordDictionary SetWord(string original, string translate);
        WordDictionary UpdateWord(int id, string newValue);
        bool DeleteWord(int id);
    }
}