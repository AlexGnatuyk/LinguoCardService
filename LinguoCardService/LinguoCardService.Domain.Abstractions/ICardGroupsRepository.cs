﻿using System.Collections.Generic;
using LinguoCardService.DataContracts.Models;

namespace LinguoCardService.Domain.Abstractions
{
    public interface ICardGroupsRepository
    {
        CardGroup GetGroup(int id);
        bool AddGroup(int mainId, int additionalId);
        List<int> GetListOfCards();
        bool DeleteGroupOfCard(int mainId);
    }
}