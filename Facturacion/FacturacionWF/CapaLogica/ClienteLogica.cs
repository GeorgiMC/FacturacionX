using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClienteLogica
    {
        public ClienteDatos ObtenerClis(string cia)
        {
            ClienteDatos clie = new ClienteDatos();
            DataSet ds = ClienteDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                clie.cia = row["cia"].ToString();
                clie.codCliente = row["codCliente"].ToString();
                clie.nombre = row["nombre"].ToString();
                clie.nombreComercial = row["nombreComercial"].ToString();
                clie.tipoCedula = row["tipoCedula"].ToString();
                clie.telefono = row["telefono"].ToString();
                clie.fax = row["fax"].ToString();
                clie.direccion = row["direccion"].ToString();
                clie.correo = row["correo"].ToString();
                clie.provincia = row["provincia"].ToString();
                clie.canton = row["canton"].ToString();
                clie.distrito = row["distrito"].ToString();
                clie.barrio = row["barrio"].ToString();
                clie.pais = row["pais"].ToString();
                clie.estado = row["estado"].ToString();
                clie.ListaPrecio = row["listaPrecio"].ToString();
            }
            return clie;
        }

        public List<ClienteDatos> SeleccionarClientes(string cia)
        {
            List<ClienteDatos> listaClientes = new List<ClienteDatos>();
            DataSet ds = ClienteDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ClienteDatos clie = new ClienteDatos();
                clie.cia = row["cia"].ToString();
                clie.codCliente = row["codCliente"].ToString();
                clie.nombre = row["nombre"].ToString();
                clie.nombreComercial = row["nombreComercial"].ToString();
                clie.tipoCedula = row["tipoCedula"].ToString();
                clie.cedula = row["cedula"].ToString();
                clie.telefono = row["telefono"].ToString();
                clie.fax = row["fax"].ToString();
                clie.direccion = row["direccion"].ToString();
                clie.correo = row["correo"].ToString();
                clie.provincia = row["provincia"].ToString();
                clie.canton = row["canton"].ToString();
                clie.distrito = row["distrito"].ToString();
                clie.barrio = row["barrio"].ToString();
                clie.pais = row["pais"].ToString();
                clie.estado = row["estado"].ToString();
                clie.ListaPrecio = row["listaPrecio"].ToString();
                listaClientes.Add(clie);
            }
            return listaClientes;
        }

        public List<ClienteDatos> ObtenerCliente(string cia, string filtro)
        {
            List<ClienteDatos> lista = new List<ClienteDatos>();
            DataSet ds = ClienteDatos.ObtenerCliente(cia,filtro);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ClienteDatos clie = new ClienteDatos();
                clie.cia = row["cia"].ToString();
                clie.codCliente = row["codCliente"].ToString();
                clie.nombre = row["nombre"].ToString();
                clie.nombreComercial = row["nombreComercial"].ToString();
                clie.tipoCedula = row["tipoCedula"].ToString();
                clie.cedula = row["cedula"].ToString();
                clie.telefono = row["telefono"].ToString();
                clie.fax = row["fax"].ToString();
                clie.direccion = row["direccion"].ToString();
                clie.correo = row["correo"].ToString();
                clie.provincia = row["provincia"].ToString();
                clie.canton = row["canton"].ToString();
                clie.distrito = row["distrito"].ToString();
                clie.barrio = row["barrio"].ToString();
                clie.pais = row["pais"].ToString();
                clie.estado = row["estado"].ToString();
                clie.ListaPrecio = row["listaPrecio"].ToString();
                lista.Add(clie);
            }
            return lista;
        }

        public List<ListaPrecioDatos> SeleccionarListaPrecio(string cia, string filtro)
        {
            List<ListaPrecioDatos> lista = new List<ListaPrecioDatos>();
            DataSet ds = ListaPrecioDatos.SeleccionarListaPrecios(cia, filtro);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListaPrecioDatos lis = new ListaPrecioDatos();
                lis.cia = row["cia"].ToString();
                lis.codigo = row["codigo"].ToString();
                lis.descripcion = row["descripcion"].ToString();

                lista.Add(lis);
            }
            return lista;
        }

        public List<ListaPrecioDatos> ObtenerListaPrecio(string cia, string codigo,string codArticulo)
        {
            List<ListaPrecioDatos> lista = new List<ListaPrecioDatos>();
            DataSet ds = ListaPrecioDatos.ObtenerListaPrecio(cia, codigo,codArticulo);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListaPrecioDatos lis = new ListaPrecioDatos();
                lis.cia = row["cia"].ToString();
                lis.codigo = row["codLista"].ToString();
                lis.codArticulo = row["codArticulo"].ToString();
                lis.descripcion = SeleccionarListaPrecio(lis.cia,lis.codigo)[0].descripcion;
                lis.precio = Convert.ToDouble(row["precio"]);
                lista.Add(lis);
            }
            return lista;
        }
    }
}
