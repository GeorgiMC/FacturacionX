using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DetalleFacturaDatos
    {
        public string cia {get;set;}
        public string documento { get; set; }
        public int secuencia { get; set; }
        public string articulo { get; set; }
        public float porcDescuento { get; set; }
        public float porcImpuesto { get; set; }
        public string unidadMedida { get; set; }
        public float cantidad { get; set; }
        public float costo { get; set; }
        public float precio { get; set; }
        public float montoImpuesto { get; set; }
        public float montoDescuento { get; set; }
        public float total { get; set; }
        public string descripcion { get; set; }

        public static DataSet SeleccionarTodos(string cia,string documento)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarFacturas");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            comando.Parameters.AddWithValue("@documento", documento);
            DataSet ds = db.ExecuteReader(comando, "detallefactura");
            return ds;
        }

        public void InsertarDetalleFactura(DetalleFacturaDatos detFactura)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarDetalleFactura");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", detFactura.cia);
            comando.Parameters.AddWithValue("@documento", detFactura.documento);
            comando.Parameters.AddWithValue("@secuencia", detFactura.secuencia);
            comando.Parameters.AddWithValue("@articulo", detFactura.articulo);
            comando.Parameters.AddWithValue("@porcDescuento", detFactura.porcDescuento);
            comando.Parameters.AddWithValue("@porcImpuesto", detFactura.porcImpuesto);
            comando.Parameters.AddWithValue("@unidadMedida", detFactura.unidadMedida);
            comando.Parameters.AddWithValue("@cantidad", detFactura.cantidad);
            comando.Parameters.AddWithValue("@costo", detFactura.costo);
            comando.Parameters.AddWithValue("@precio", detFactura.precio);
            comando.Parameters.AddWithValue("@montoImpuesto", detFactura.montoImpuesto);
            comando.Parameters.AddWithValue("@montoDescuento", detFactura.montoDescuento);
            comando.Parameters.AddWithValue("@total", detFactura.total);
            comando.Parameters.AddWithValue("@descripcion", detFactura.descripcion);
            DataSet ds = db.ExecuteReader(comando, "detallefactura");
        }
    }
}
