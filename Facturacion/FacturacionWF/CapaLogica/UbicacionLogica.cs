using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class UbicacionLogica
    {
        public List<PaisDatos> SeleccionarPais()
        {
            List<PaisDatos> lista = new List<PaisDatos>();
            DataSet ds = PaisDatos.SeleccionarTodos();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PaisDatos obj = new PaisDatos();
                obj.codPais = row["COD_PAIS"].ToString();
                obj.nompais = row["NOM_PAIS"].ToString();

                lista.Add(obj);
            }
            return lista;
        }

        public List<ProvinciaDatos> SeleccionarProvincia()
        {
            List<ProvinciaDatos> lista = new List<ProvinciaDatos>();
            DataSet ds = ProvinciaDatos.SeleccionarTodos();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ProvinciaDatos obj = new ProvinciaDatos();
                obj.codProvincia = row["COD_PROVINCIA"].ToString();
                obj.nomProvincia = row["NOMPROVINCIA"].ToString();

                lista.Add(obj);
            }
            return lista;
        }

        public List<CantonDatos> SeleccionarCanton(string provincia)
        {
            List<CantonDatos> lista = new List<CantonDatos>();
            DataSet ds = CantonDatos.SeleccionarTodos(provincia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CantonDatos obj = new CantonDatos();
                obj.codCanton = row["COD_CANTON"].ToString();
                obj.nomCanton = row["NOM_CANTON"].ToString();

                lista.Add(obj);
            }
            return lista;
        }

        public List<DistritoDatos> SeleccionarDsitrito(string provincia,string canton)
        {
            List<DistritoDatos> lista = new List<DistritoDatos>();
            DataSet ds = DistritoDatos.SeleccionarTodos(provincia,canton);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DistritoDatos obj = new DistritoDatos();
                obj.codDistrito = row["COD_DISTRITO"].ToString();
                obj.nomDistrito = row["NOM_DISTRITO"].ToString();

                lista.Add(obj);
            }
            return lista;
        }

        public List<BarriosDatos> SeleccionarBarrio(string provincia,string canton,string distrito)
        {
            List<BarriosDatos> lista = new List<BarriosDatos>();
            DataSet ds = BarriosDatos.SeleccionarTodos(provincia,canton,distrito);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                BarriosDatos obj = new BarriosDatos();
                obj.codBarrio = row["COD_BARRIO"].ToString();
                obj.nomBarrio = row["NOM_BARRIO"].ToString();

                lista.Add(obj);
            }
            return lista;
        }
    }
}
