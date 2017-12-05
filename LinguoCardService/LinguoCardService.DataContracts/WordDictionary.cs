using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguoCardService.DataContracts
{
   
    public class WordDictionary : IComparable<WordDictionary>
    {
       public int Id { get; set; }
       public string EnglishValue { get; set; }
       public string RussianValue { get; set; }

        public int CompareTo(WordDictionary other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var idComparison = Id.CompareTo(other.Id);
            if (idComparison != 0) return idComparison;
            var englishValueComparison = string.Compare(EnglishValue, other.EnglishValue, StringComparison.Ordinal);
            if (englishValueComparison != 0) return englishValueComparison;
            return string.Compare(RussianValue, other.RussianValue, StringComparison.Ordinal);
        }
    }
}
