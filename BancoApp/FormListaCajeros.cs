using System;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class FormListaCajeros : Form
    {
        private SistemaBanco sistema;

        public FormListaCajeros(SistemaBanco sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarEventHandlers();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar columnas
            dgvCajeros.Columns.Clear();
            dgvCajeros.Columns.Add(new DataGridViewTextBoxColumn { Name = "DNI", HeaderText = "DNI", Width = 100 });
            dgvCajeros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombres", HeaderText = "Nombres", Width = 150 });
            dgvCajeros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Direccion", HeaderText = "Dirección", Width = 150 });
            dgvCajeros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", Width = 120 });
            dgvCajeros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono", Width = 100 });

            // Cargar datos
            dgvCajeros.Rows.Clear();
            foreach (var cajero in sistema.Cajeros.ObtenerTodos())
            {
                dgvCajeros.Rows.Add(cajero.DNI, cajero.Nombres, cajero.Direccion, cajero.Email, cajero.Telefono);
            }
        }

        private void ConfigurarEventHandlers()
        {
            this.btnCerrar.Click += btnCerrar_Click;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}