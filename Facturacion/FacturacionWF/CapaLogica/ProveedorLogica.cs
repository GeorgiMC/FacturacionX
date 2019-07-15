using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ProveedorLogica
    {
        public List<ProveedorDatos> SeleccionarProveedores(string cia)
        {
            List<ProveedorDatos> lista = new List<ProveedorDatos>();
            DataSet ds = ProveedorDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ProveedorDatos obj = new ProveedorDatos();
                obj.cia = row["cia"].ToString();
                obj.codProveedor = row["codProveedor"].ToString();
                obj.nombre = row["nombre"].ToString();
                obj.nombreComercial = row["nombreComercial"].ToString();
                obj.tipoCedula = row["tipoCedula"].ToString();
                obj.cedula = row["cedula"].ToString();
                obj.telefono = row["telefono"].ToString();
                obj.fax = row["fax"].ToString();
                obj.direccion = row["direccion"].ToString();
                obj.correo = row["correo"].ToString();
                obj.provincia = row["provincia"].ToString();
                obj.canton = row["canton"].ToString();
                obj.distrito = row["distrito"].ToString();
                obj.barrio = row["barrio"].ToString();
                obj.pais = row["pais"].ToString();
                obj.codigoActividad = row["codigoActividad"].ToString();
                obj.estado = row["estado"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
        public List<ProveedorDatos> ObtenerProveedores(string cia,string filtro)
        {
            List<ProveedorDatos> lista = new List<ProveedorDatos>();
            DataSet ds = ProveedorDatos.ObtenerProveedor(cia,filtro);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ProveedorDatos obj = new ProveedorDatos();
                obj.cia = row["cia"].ToString();
                obj.codProveedor = row["codProveedor"].ToString();
                obj.nombre = row["nombre"].ToString();
                obj.nombreComercial = row["nombreComercial"].ToString();
                obj.tipoCedula = row["tipoCedula"].ToString();
                obj.cedula = row["cedula"].ToString();
                obj.telefono = row["telefono"].ToString();
                obj.fax = row["fax"].ToString();
                obj.direccion = row["direccion"].ToString();
                obj.correo = row["correo"].ToString();
                obj.provincia = row["provincia"].ToString();
                obj.canton = row["canton"].ToString();
                obj.distrito = row["distrito"].ToString();
                obj.barrio = row["barrio"].ToString();
                obj.pais = row["pais"].ToString();
                obj.codigoActividad = row["codigoActividad"].ToString();
                obj.estado = row["estado"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
