using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguoCardService.DataContracts
{
    public class Card
    {
        public int Id { get; set; }
        public WordDictionary Original { get; set; }
        public  WordDictionary CorrectWord { get; set; }
        public  WordDictionary UncorrectWord { get; set; }
    }
}
