using System;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class FormListaServicios : Form
    {
        private SistemaBanco sistema;

        public FormListaServicios(SistemaBanco sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDatos();
            ConfigurarEventHandlers();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar columnas
            dgvServicios.Columns.Clear();
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdServicio",
                HeaderText = "ID",
                Width = 100
            });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripción",
                Width = 300
            });
        }

        private void CargarDatos()
        {
            dgvServicios.Rows.Clear();
            foreach (var servicio in sistema.Servicios.ObtenerTodos())
            {
                dgvServicios.Rows.Add(servicio.IdServicio, servicio.Descripcion);
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