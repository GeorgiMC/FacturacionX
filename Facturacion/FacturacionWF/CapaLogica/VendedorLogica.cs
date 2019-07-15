using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class VendedorLogica
    {
        public List<VendedorDatos> SeleccionarArticulos(string cia)
        {
            List<VendedorDatos> lista = new List<VendedorDatos>();
            DataSet ds = VendedorDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                VendedorDatos obj = new VendedorDatos();
                obj.cia = row["cia"].ToString();
                obj.codigo = row["codigo"].ToString();
                obj.nombre = row["nombre"].ToString();
                obj.usuario = row["usuario"].ToString();
                obj.caja = row["caja"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
