using System.Collections.Generic;

namespace LinguoCardService.Domain.Abstractions
{
    public interface ICardsService
    {
        List<int> GetListOfcards();
    }
}