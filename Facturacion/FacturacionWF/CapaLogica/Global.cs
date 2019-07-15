using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public static class Global
    {
        private static UsuarioDatos _User = null;
        private static VendedorDatos _Vend = null;
        public static UsuarioDatos GlobalUser
        {
            get { return _User; }
            set { _User = value; }
        }

        public static VendedorDatos GlobalVend
        {
            get { return _Vend; }
            set { _Vend = value; }
        }
    }
}
