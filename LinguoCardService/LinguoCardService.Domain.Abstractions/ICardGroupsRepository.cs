using System.Collections.Generic;
using LinguoCardService.DataContracts.Models;

namespace LinguoCardService.Domain.Abstractions
{
    public interface ICardGroupsRepository
    {
        bool AddGroup(int mainId, int additionalId);
        List<int> GetListOfCards();
        bool DeleteGroupOfCard(int mainId);
        List<int> GetAdditionalCards(int mainId);
    }
}