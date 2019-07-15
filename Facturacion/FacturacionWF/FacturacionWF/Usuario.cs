using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionWF
{
    public partial class Usuario : Form
    {
        string cia = Global.GlobalUser.cia;
        CompaniaLogica companialogica = new CompaniaLogica();
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            cboCompania.DataSource = companialogica.SeleccionarCompanias("001");
            cboCompania.DisplayMember = "nombre";
            cboCompania.ValueMember = "cia";
            cboCompania.SelectedValue = cia;

            cboTipo.Items.Add(new { Text = "Administrador", Value = "AM" });
            cboTipo.Items.Add(new { Text = "Vendedor", Value = "VN" });
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "Value";
            cboTipo.SelectedIndex = 0;
        }
    }
}
