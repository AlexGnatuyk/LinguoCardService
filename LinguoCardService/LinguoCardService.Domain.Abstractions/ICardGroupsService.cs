using System.Collections.Generic;
using LinguoCardService.DataContracts.Models;

namespace LinguoCardService.Domain.Abstractions
{
    public interface ICardGroupsService
    {
        CardGroup GetGroup(int id);
        List<int> GetListOfcards();
        bool AddGroup(int mainId, int additionalId);
    }
}