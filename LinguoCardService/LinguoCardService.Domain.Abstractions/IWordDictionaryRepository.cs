using LinguoCardService.DataContracts;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IWordDictionaryRepository
    {
        WordDictionary GetById();
        WordDictionary GetByOriginallWord();
        WordDictionary GetByTranslateWord();
    }
}