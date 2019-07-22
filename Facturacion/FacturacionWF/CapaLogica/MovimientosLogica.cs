using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class MovimientosLogica
    {
        public List<MovimientoCreditoDatos> SeleccionarArticulos(string cia, string cliente, string estado,string documento)
        {
            List<MovimientoCreditoDatos> lista = new List<MovimientoCreditoDatos>();
            DataSet ds = MovimientoCreditoDatos.ObtenerMovimientoCredito(cia, cliente, estado,documento);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                MovimientoCreditoDatos obj = new MovimientoCreditoDatos();
                obj.cia = row["cia"].ToString();
                obj.tip_doc = row["tip_doc"].ToString();
                obj.num_doc = row["num_doc"].ToString();
                obj.fec_doc = Convert.ToDateTime(row["fec_doc"].ToString());
                obj.fec_vence = Convert.ToDateTime(row["fec_vence"].ToString());
                obj.ano_fiscal = Convert.ToInt32(row["ano_fiscal"].ToString());
                obj.per_proceso = Convert.ToInt32(row["per_proceso"].ToString());
                obj.cod_cliente = row["cod_cliente"].ToString();
                obj.moneda = row["moneda"].ToString();
                obj.tip_cambio = float.Parse(row["tip_cambio"].ToString());
                obj.tip_cambio_base = float.Parse(row["tip_cambio_base"].ToString());
                obj.des_observacion = row["des_observacion"].ToString();
                obj.estado = row["estado"].ToString();
                obj.mon_saldo = float.Parse(row["mon_saldo"].ToString());
                obj.doc_ref = row["doc_ref"].ToString();
                obj.fec_reg = Convert.ToDateTime(row["fec_reg"].ToString());
                lista.Add(obj);
            }
            return lista;
        }
    }
}
