using LinguoCardService.DataContracts.Models;

namespace LinguoCardService.Domain.Abstractions
{
    public interface IGroupFacade
    {
        CardGroup GetGroup(int id);
    }
}