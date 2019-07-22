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
                obj.impuesto = row["impuesto"].ToString();
                obj.tipo = row["tipo"].ToString();
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
                obj.impuesto = row["impuesto"].ToString();
                obj.tipo = row["tipo"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public List<ImpuestoDatos> ObtenerImpuesto(string cia, string filtro)
        {
            List<ImpuestoDatos> lista = new List<ImpuestoDatos>();
            DataSet ds = ImpuestoDatos.ObtenerImpuesto(cia, filtro);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ImpuestoDatos obj = new ImpuestoDatos();
                obj.cia = row["cia"].ToString();
                obj.codigo = row["codigo"].ToString();
                obj.descripcion = row["descripcion"].ToString();
                obj.porcentaje = Convert.ToDouble(row["porcentaje"]);
                obj.impuestoFe = row["impuestoFe"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
        public List<TipoArticuloDatos> ObtenerTipoArticulo(string cia, string filtro)
        {
            List<TipoArticuloDatos> lista = new List<TipoArticuloDatos>();
            DataSet ds = TipoArticuloDatos.ObtenerTipoArticulo(cia, filtro);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TipoArticuloDatos obj = new TipoArticuloDatos();
                obj.cia = row["cia"].ToString();
                obj.codigo = row["codigo"].ToString();
                obj.descripcion = row["descripcion"].ToString();
                obj.afecta = row["afecta"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
