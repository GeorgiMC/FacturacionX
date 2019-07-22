using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class DetalleLogica
    {
        public List<DetalleFacturaDatos> SeleccionarDetalleFactura(string cia,string documento)
        {
            List<DetalleFacturaDatos> lista = new List<DetalleFacturaDatos>();
            DataSet ds = DetalleFacturaDatos.SeleccionarTodos(cia,documento);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DetalleFacturaDatos obj = new DetalleFacturaDatos();
                obj.cia = row["cia"].ToString();
                obj.documento = row["documento"].ToString();
                obj.secuencia = Convert.ToInt32(row["secuencia"]);
                obj.articulo = row["articulo"].ToString();
                obj.porcDescuento = (float)row["porcDescuento"];
                obj.porcImpuesto = (float)row["porcImpuesto"];
                obj.unidadMedida = row["unidadMedida"].ToString();
                obj.cantidad = (float)row["cantidad"];
                obj.costo = (float)row["costo"];
                obj.precio = (float)row["precio"];
                obj.montoImpuesto = (float)row["montoImpuesto"];
                obj.montoDescuento = (float)row["montoDescuento"];
                obj.total = (float)row["total"];
                obj.descripcion = row["descripcion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
        public void InsertarDetalleFactura(List<DetalleFacturaDatos> detallefactura)
        {
            DetalleFacturaDatos detalleDatos = new DetalleFacturaDatos();
            foreach (DetalleFacturaDatos detalle in detallefactura)
            {
                detalleDatos.InsertarDetalleFactura(detalle);
            }
        }
    }
}
