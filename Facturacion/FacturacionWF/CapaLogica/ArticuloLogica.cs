using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ArticuloLogica
    {
        public List<ArticuloDatos> SeleccionarArticulos(string cia)
        {
            List<ArticuloDatos> lista = new List<ArticuloDatos>();
            DataSet ds = ArticuloDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ArticuloDatos obj = new ArticuloDatos();
                obj.cia = row["cia"].ToString();
                obj.codArticulo = row["codArticulo"].ToString();
                obj.descripcion = row["desArticulo"].ToString();
                obj.unidad = row["unidad"].ToString();
                obj.cantidad = ObtenerCantidadArticulos(cia, row["codArticulo"].ToString());
                obj.costo = float.Parse(row["costo"].ToString());
                obj.precio = float.Parse(row["precio"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public float ObtenerCantidadArticulos(string cia,string articulo)
        {
            float cantidad = 0;
            DataSet ds = ArticuloDatos.ObtenerCantidad(cia,articulo);

            foreach (DataRow row in ds.Tables[0].Rows)
            {                
                cantidad = float.Parse(row["cantidad"].ToString());
            }
            return cantidad;
        }

        public List<ArticuloDatos> ObtenerArticulos(string cia,string filtro)
        {
            List<ArticuloDatos> lista = new List<ArticuloDatos>();
            DataSet ds = ArticuloDatos.ObtenerArticulo(cia,filtro);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ArticuloDatos obj = new ArticuloDatos();
                obj.cia = row["cia"].ToString();
                obj.codArticulo = row["codArticulo"].ToString();
                obj.descripcion = row["desArticulo"].ToString();
                obj.unidad = row["unidad"].ToString();
                obj.cantidad = ObtenerCantidadArticulos(cia, row["codArticulo"].ToString());
                obj.costo = float.Parse(row["costo"].ToString());
                obj.precio = float.Parse(row["precio"].ToString());
                lista.Add(obj);
            }
            return lista;
        }
    }
}
