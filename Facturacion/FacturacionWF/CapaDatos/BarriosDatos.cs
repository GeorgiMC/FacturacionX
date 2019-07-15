using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BarriosDatos
    {
        public string codBarrio { get; set; }
        public string nomBarrio { get; set; }

        public static DataSet SeleccionarTodos(string provincia,string canton,string distrito)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarBarrio");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@provincia", provincia);
            comando.Parameters.AddWithValue("@canton", canton);
            comando.Parameters.AddWithValue("@distrito", distrito);
            DataSet ds = db.ExecuteReader(comando, "distrito");
            return ds;
        }
    }
}
