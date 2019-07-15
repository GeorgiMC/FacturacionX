using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ArticuloDatos
    {
        public string cia { get; set; }
        public string codArticulo { get; set; }
        public string descripcion { get; set; }
        public string unidad { get; set; }
        public float cantidad { get; set; }
        public float costo { get; set; }
        public float precio { get; set; }

        public static DataSet SeleccionarTodos(string cia)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarArticulos");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "articulos");
            return ds;
        }

        public static DataSet ObtenerArticulo(string cia,string filtro)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerArticulos");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@filtro", filtro);
            DataSet ds = db.ExecuteReader(comando, "articulos");
            return ds;
        }

        public static DataSet ObtenerCantidad(string cia,string articulo)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerCantidadArticulo");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@articulo", articulo);
            DataSet ds = db.ExecuteReader(comando, "articulos");
            return ds;
        }
    }
}
