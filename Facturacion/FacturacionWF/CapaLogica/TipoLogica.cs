using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class TipoLogica
    {
        public List<TipoDatos> SeleccionarTipos(string cia,string clase)
        {
            List<TipoDatos> lista = new List<TipoDatos>();
            DataSet ds = TipoDatos.SeleccionarTodos(cia,clase);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TipoDatos obj = new TipoDatos();
                obj.cia = row["cia"].ToString();
                obj.tipo = row["tipo"].ToString();
                obj.descripcion = row["descripcion"].ToString();
                obj.clase = row["clase"].ToString();
                obj.tipoFe = row["tipoFe"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
