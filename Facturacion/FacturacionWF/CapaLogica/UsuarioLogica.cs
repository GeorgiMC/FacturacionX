using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class UsuarioLogica
    {
        public List<UsuarioDatos> SeleccionarArticulos(string cia)
        {
            List<UsuarioDatos> lista = new List<UsuarioDatos>();
            DataSet ds = UsuarioDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                UsuarioDatos obj = new UsuarioDatos();
                obj.cia = row["cia"].ToString();
                obj.usuario = row["usuario"].ToString();
                obj.contrasena = row["contrasena"].ToString();
                if (row["tipo"].ToString() == "AM")
                {
                    obj.tipo = "Administrador";
                }
                else
                {
                    obj.tipo = "Vendedor";
                }
                lista.Add(obj);
            }
            return lista;
        }

        public Boolean ValidaUsuario(string usuario,string contrasena)
        {
            bool ind = false;
            UsuarioDatos usu = new UsuarioDatos();
            VendedorDatos ven = new VendedorDatos();
            DataSet ds = UsuarioDatos.ValidaUsuario(usuario,contrasena);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                usu.cia = row["cia"].ToString();
                usu.usuario = row["usuario"].ToString();
                //usu.contrasena = row["contrasena"].ToString();
                usu.tipo = row["tipo"].ToString();

                ven.cia = row["cia"].ToString();
                ven.codigo = row["codigo"].ToString();
                ven.nombre = row["nombre"].ToString();
                ven.usuario = row["usuario"].ToString();
                ven.caja = row["caja"].ToString();
                ind = true;
                Global.GlobalUser = usu;
                Global.GlobalVend = ven;
            }
            return ind;
        }
    }
}
