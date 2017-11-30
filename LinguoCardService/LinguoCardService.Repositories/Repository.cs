using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguoCardService.Repositories
{
   public class Repository
    {
        private static readonly string _connctionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SqlConnection Connection => new SqlConnection((_connctionString));
    }
}
