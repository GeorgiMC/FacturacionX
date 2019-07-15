using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TipoDatos
    {
        public string cia{get; set;}
        public string tipo{get; set;}
        public string clase{get; set;}
        public string descripcion{get; set;}
        public string tipoFe{get; set;}

        public static DataSet SeleccionarTodos(string cia,string clase)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarTipoDoc");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@clase", clase);
            DataSet ds = db.ExecuteReader(comando, "tipodoc");
            return ds;
        }
    }
}
