using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguoCardService.DataContracts
{
   
    public class WordDictionary
    {
       public int Id { get; set; }
       public string EnglishValue { get; set; }
       public string RussianValue { get; set; }
    }
}
