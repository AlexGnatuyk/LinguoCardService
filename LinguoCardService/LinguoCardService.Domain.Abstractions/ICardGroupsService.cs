using LinguoCardService.DataContracts.Models;

namespace LinguoCardService.Domain.Abstractions
{
    public interface ICardGroupsService
    {
        CardGroup GetGroup(int id);
    }
}