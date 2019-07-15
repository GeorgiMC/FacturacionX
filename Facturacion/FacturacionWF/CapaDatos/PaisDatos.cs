using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class PaisDatos
    {
        public string codPais{get; set;}
        public string nompais{get; set;}
        public string zona{get; set;}
    public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarPais");
            comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "pais");
            return ds;
        }
    }
}
