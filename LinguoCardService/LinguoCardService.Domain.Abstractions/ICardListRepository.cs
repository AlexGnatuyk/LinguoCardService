using System.Collections.Generic;

namespace LinguoCardService.Domain.Abstractions
{
    public interface ICardListRepository
    {
        List<int> GetListOfCards();
    }
}