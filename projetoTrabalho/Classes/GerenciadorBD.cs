using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoTrabalho.Classes
{
    internal class GerenciadorBD
    {
        private string connectionString = "server=localhost;port=3306;database=" +
            "db_sistemacadastroclientes;UID=root;password=''" +
            "";

        public string getConnectionString()
        {
            return this.connectionString;
        }
    }
}
