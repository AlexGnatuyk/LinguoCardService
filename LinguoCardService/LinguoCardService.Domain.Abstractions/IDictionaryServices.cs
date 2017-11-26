using LinguoCardService.DataContracts;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IDictionaryServices
    {
        WordDictionary GetById(int id);
        WordDictionary GetByOriginallWord(string original);
        WordDictionary GetByTranslateWord(string translate);
        void SetWord(string original, string translate);
    }
}