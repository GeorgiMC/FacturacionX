using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DetalleFactura
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
    }
}
