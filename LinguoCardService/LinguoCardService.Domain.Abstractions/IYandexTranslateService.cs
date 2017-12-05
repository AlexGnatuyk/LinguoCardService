using LinguoCardService.DataContracts;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IYandexTranslateService
    {
        string GetTranslate(string original, Language laguage);
    }
}