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
       public string Original { get; set; }
       public string Translate { get; set; }
    }
}
