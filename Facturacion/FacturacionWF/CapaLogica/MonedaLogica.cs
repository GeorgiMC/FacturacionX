using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class MonedaLogica
    {
        public List<MonedaDatos> SeleccionarMoneda(string cia)
        {
            List<MonedaDatos> lista = new List<MonedaDatos>();
            DataSet ds = MonedaDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                MonedaDatos obj = new MonedaDatos();
                obj.cia = row["cia"].ToString();
                obj.codigo = row["codigo"].ToString();
                obj.descripcion = row["descripcion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
