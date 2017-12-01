using System.Collections.Generic;

namespace LinguoCardService.DataContracts.Models
{
    public class CardGroup
    {
        public int Id { get; set; }
        public List<Card> Cards { get; set; }
    }
}