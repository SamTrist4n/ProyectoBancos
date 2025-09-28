using System;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class FormMenuPrincipal : Form
    {
        private SistemaBanco sistema;

        public FormMenuPrincipal()
        {
            InitializeComponent();
            sistema = new SistemaBanco();
            ConfigurarEventHandlers();
        }

        private void ConfigurarEventHandlers()
        {
            this.btnGestionClientes.Click += btnGestionClientes_Click;
            this.btnGestionCajeros.Click += btnGestionCajeros_Click;
            this.btnGestionServicios.Click += btnGestionServicios_Click;
            this.btnConfigurarVentanillas.Click += btnConfigurarVentanillas_Click;
            this.btnIniciarSimulacion.Click += btnIniciarSimulacion_Click;
            this.btnGenerarReportes.Click += btnGenerarReportes_Click;
            this.btnSalir.Click += btnSalir_Click;
            this.btnCargarDatos.Click += btnCargarDatos_Click;
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            FormGestionClientes form = new FormGestionClientes(sistema);
            form.ShowDialog();
        }

        private void btnGestionCajeros_Click(object sender, EventArgs e)
        {
            FormGestionCajeros form = new FormGestionCajeros(sistema);
            form.ShowDialog();
        }

        private void btnGestionServicios_Click(object sender, EventArgs e)
        {
            FormGestionServicios form = new FormGestionServicios(sistema);
            form.ShowDialog();
        }

        private void btnConfigurarVentanillas_Click(object sender, EventArgs e)
        {
            FormConfiguracionVentanillas form = new FormConfiguracionVentanillas(sistema);
            form.ShowDialog();
        }

        private void btnIniciarSimulacion_Click(object sender, EventArgs e)
        {
            FormSimulacion form = new FormSimulacion(sistema);
            form.ShowDialog();
        }

        private void btnGenerarReportes_Click(object sender, EventArgs e)
        {
            FormReportes form = new FormReportes(sistema);
            form.ShowDialog();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                CsvLoader loader = new CsvLoader(sistema);
                loader.CargarTodo();

                MessageBox.Show("Datos cargados correctamente desde los archivos CSV.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los archivos CSV:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}