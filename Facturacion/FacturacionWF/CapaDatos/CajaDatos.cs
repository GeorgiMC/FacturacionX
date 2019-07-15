using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CajaDatos
    {
        public string cia{get; set;}
        public string caja{get; set;}
        public string descripcion{get; set;}

        public static DataSet SeleccionarTodos(string cia)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarCaja");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "caja");
            return ds;
        }

        public static DataSet ObtenerCaja(string cia,string caja)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerCaja");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@caja", caja);
            DataSet ds = db.ExecuteReader(comando, "caja");
            return ds;
        }
    }
}
