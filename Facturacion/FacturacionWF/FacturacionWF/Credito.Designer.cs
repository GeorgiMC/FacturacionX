namespace FacturacionWF
{
    partial class Credito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCredito = new System.Windows.Forms.DataGridView();
            this.codCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCredito
            // 
            this.dgvCredito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCliente,
            this.nombre,
            this.saldo});
            this.dgvCredito.Location = new System.Drawing.Point(12, 59);
            this.dgvCredito.Name = "dgvCredito";
            this.dgvCredito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCredito.Size = new System.Drawing.Size(850, 400);
            this.dgvCredito.TabIndex = 3;
            this.dgvCredito.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCredito_CellDoubleClick);
            // 
            // codCliente
            // 
            this.codCliente.HeaderText = "Codigo Cliente";
            this.codCliente.Name = "codCliente";
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.Width = 200;
            // 
            // saldo
            // 
            this.saldo.HeaderText = "Saldo";
            this.saldo.Name = "saldo";
            // 
            // Credito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 487);
            this.Controls.Add(this.dgvCredito);
            this.Name = "Credito";
            this.Text = "Credito";
            this.Load += new System.EventHandler(this.Credito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
    }
}