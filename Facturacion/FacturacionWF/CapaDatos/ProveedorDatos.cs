using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ProveedorDatos
    {
        public string cia { get; set; }
        public string codProveedor { get; set; }
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
        public string codigoActividad { get; set; }
        public string estado { get; set; }

        public static DataSet SeleccionarTodos(string cia)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarProveedores");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "proveedor");
            return ds;
        }
        public static DataSet ObtenerProveedor(string cia, string filtro)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerProveedores");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@filtro", filtro);
            DataSet ds = db.ExecuteReader(comando, "proveedor");
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

        public static void Insertar(ProveedorDatos obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarProveedor");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", obj.cia);
            comando.Parameters.AddWithValue("@codProveedor", obj.codProveedor);
            comando.Parameters.AddWithValue("@nombre", obj.nombre);
            comando.Parameters.AddWithValue("@nombreComercial", obj.nombreComercial);
            comando.Parameters.AddWithValue("@tipoCedula", obj.tipoCedula);
            comando.Parameters.AddWithValue("@cedula", obj.cedula);
            comando.Parameters.AddWithValue("@telefono", obj.telefono);
            comando.Parameters.AddWithValue("@fax", obj.fax);
            comando.Parameters.AddWithValue("@direccion", obj.direccion);
            comando.Parameters.AddWithValue("@correo", obj.correo);
            comando.Parameters.AddWithValue("@provincia", obj.provincia);
            comando.Parameters.AddWithValue("@canton", obj.canton);
            comando.Parameters.AddWithValue("@distrito", obj.distrito);
            comando.Parameters.AddWithValue("@barrio", obj.barrio);
            comando.Parameters.AddWithValue("@pais", obj.pais);
            comando.Parameters.AddWithValue("@codigoActividad", obj.codigoActividad);
            comando.Parameters.AddWithValue("@estado", obj.estado);

            db.ExecuteNonQuery(comando);
        }
    }
}
