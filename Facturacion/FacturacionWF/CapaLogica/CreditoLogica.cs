using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CreditoLogica
    {
        public List<CreditoDatos> ObtenerCredito(string cia, string cliente, string estado)
        {
            List<CreditoDatos> lista = new List<CreditoDatos>();
            DataSet ds = CreditoDatos.ObtenerCredito(cia, cliente, estado);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CreditoDatos obj = new CreditoDatos();
                obj.cia = row["cia"].ToString();
                obj.moneda = row["moneda"].ToString();
                obj.cod_cliente = row["cod_cliente"].ToString();
                obj.dias_credito = float.Parse(row["dias_credito"].ToString());
                obj.limite_credito = float.Parse(row["limite_credito"].ToString());
                obj.interes = float.Parse(row["interes"].ToString());
                obj.saldo = float.Parse(row["saldo"].ToString());
                obj.estado = row["estado"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
