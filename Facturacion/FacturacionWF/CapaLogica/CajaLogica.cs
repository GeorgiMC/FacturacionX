using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CajaLogica
    {
        public List<CajaDatos> SeleccionarCajas(string cia)
        {
            List<CajaDatos> lista = new List<CajaDatos>();
            DataSet ds = CajaDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CajaDatos obj = new CajaDatos();
                obj.cia = row["cia"].ToString();
                obj.caja = row["caja"].ToString();
                obj.descripcion = row["descripcion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public CajaDatos ObtenerCaja(string cia,string caja)
        {
            CajaDatos obj = new CajaDatos();
            DataSet ds = CajaDatos.ObtenerCaja(cia,caja);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                obj.cia = row["cia"].ToString();
                obj.caja = row["caja"].ToString();
                obj.descripcion = row["descripcion"].ToString();
            }
            return obj;
        }
    }
}
