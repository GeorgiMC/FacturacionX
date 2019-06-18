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
        public ClienteDatos ObtenerClientes(string cia)
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
                listaClientes.Add(clie);
            }
            return listaClientes;
        }
    }
}
