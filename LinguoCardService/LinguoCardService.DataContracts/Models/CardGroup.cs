using System.Collections.Generic;

namespace LinguoCardService.DataContracts.Models
{
    public class CardGroup
    {
        public int Id { get; set; }
        private List<Card> Cards { get; set; }
    }
}