using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuarioDatos
    {
        public string cia { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string tipo { get; set; }

        public static DataSet SeleccionarTodos(string cia)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarUsuario");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "usuario");
            return ds;
        }
        public static DataSet SeleccionarCompra(string usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarUsuarioFiltro");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            DataSet ds = db.ExecuteReader(comando, "usuario");
            return ds;
        }
        public static DataSet ValidaUsuario(string usuario,string contrasena)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ValidaUsuario");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena", contrasena);
            DataSet ds = db.ExecuteReader(comando, "usuario");
            return ds;
        }
        public static void Modificar(UsuarioDatos cmp)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ModificarCompra");
            comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("@idCompra", cmp.idCompra);
            //comando.Parameters.AddWithValue("@idEmpleado", cmp.idEmpleado);
            //comando.Parameters.AddWithValue("@fecha", cmp.fecha);
            //comando.Parameters.AddWithValue("@cantidad", cmp.cantidad);
            //comando.Parameters.AddWithValue("@idDispositivo", cmp.idDispositivo);

            db.ExecuteNonQuery(comando);
        }

        public static void Insertar(int idDispositivo, DateTime fecha, int idEmpleado, int cantidad)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarCompra");
            comando.CommandType = CommandType.StoredProcedure;

            //comando.Parameters.AddWithValue("@idDispositivo", idDispositivo);
            //comando.Parameters.AddWithValue("@fecha", fecha);
            //comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
            //comando.Parameters.AddWithValue("@cantidad", cantidad);

            db.ExecuteNonQuery(comando);
        }
    }
}
