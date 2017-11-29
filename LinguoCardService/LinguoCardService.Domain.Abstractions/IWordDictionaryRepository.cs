using LinguoCardService.DataContracts;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IWordDictionaryRepository
    {
        WordDictionary GetById(int id, string language);
        WordDictionary GetByOriginallWord(string original);
        WordDictionary GetByTranslateWord(string translate);
        WordDictionary SetWord(string original, string translate);
    }
}