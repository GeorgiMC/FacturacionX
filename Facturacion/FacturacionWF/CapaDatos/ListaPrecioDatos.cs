using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ListaPrecioDatos
    {
        public string cia { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string codArticulo { get; set; }
        public double precio { get; set; }

        public static DataSet SeleccionarListaPrecios(string cia,String filtro)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarListaPrecio");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@filtro", filtro);
            DataSet ds = db.ExecuteReader(comando, "ListaPrecio");
            return ds;
        }

        public static DataSet ObtenerListaPrecio(string cia, string codigo, string codArticulo)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerDetalleListaPrecio");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@codArticulo", codArticulo);
            DataSet ds = db.ExecuteReader(comando, "ListaPrecio");
            return ds;
        }
    }
}
