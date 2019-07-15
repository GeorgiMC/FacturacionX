using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DistritoDatos
    {
        public string codDistrito { get; set; }
        public string nomDistrito { get; set; }

        public static DataSet SeleccionarTodos(string provincia,string canton)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarDistrito");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@provincia", provincia);
            comando.Parameters.AddWithValue("@canton", canton);
            DataSet ds = db.ExecuteReader(comando, "distrito");
            return ds;
        }
    }
}
