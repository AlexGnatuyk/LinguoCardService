using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguoCardService.DataContracts
{
    [Table(Name = "Dictionary")]
    public class WordDictionary
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "original")]
        public string Original { get; set; }
        [Column(Name = "translate")]
        public string Translate { get; set; }
    }
}
