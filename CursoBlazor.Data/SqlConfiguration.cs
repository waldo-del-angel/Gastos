using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBlazor.Data
{
    public class SqlConfiguration
    {
        public SqlConfiguration(string _connectionString) => ConnectionString = _connectionString;
        public string ConnectionString { get; }
    }
}
