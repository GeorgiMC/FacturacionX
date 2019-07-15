using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CantonDatos
    {
        public string codCanton { get; set; }
        public string nomCanton { get; set; }

        public static DataSet SeleccionarTodos(string provincia)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarCanton");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@provincia", provincia);
            DataSet ds = db.ExecuteReader(comando, "canton");
            return ds;
        }
    }
}
