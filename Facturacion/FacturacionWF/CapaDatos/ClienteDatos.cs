using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClienteDatos
    {
        public string cia { get; set; }
        public string codCliente { get; set; }
        public string nombre { get; set; }
        public string nombreComercial { get; set; }
        public string tipoCedula { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public string fax { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string barrio { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
        public string ListaPrecio { get; set; }

        public static DataSet SeleccionarTodos(string cia)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarClientes");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "cliente");
            return ds;
        }
        public static DataSet SeleccionarCompra(string codCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarClienteFiltro");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codCliente", codCliente);
            DataSet ds = db.ExecuteReader(comando, "cliente");
            return ds;
        }
        public static DataSet ObtenerCliente(string cia, string filtro)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerClientes");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@filtro", filtro);
            DataSet ds = db.ExecuteReader(comando, "cliente");
            return ds;
        }
    }
}
