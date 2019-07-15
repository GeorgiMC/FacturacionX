using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CompaniaLogica
    {
        public List<CompaniaDatos> SeleccionarCompanias(string cia)
        {
            List<CompaniaDatos> lista = new List<CompaniaDatos>();
            DataSet ds = CompaniaDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CompaniaDatos obj = new CompaniaDatos();
                obj.cia = row["cia"].ToString();
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
                obj.usuario = row["usuario"].ToString();
                obj.contrasena = row["contrasena"].ToString();
                obj.pin = row["pin"].ToString();
                obj.certificado = row["certificado"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
