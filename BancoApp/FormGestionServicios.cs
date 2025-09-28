using System;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class FormGestionServicios : Form
    {
        private SistemaBanco sistema;

        public FormGestionServicios(SistemaBanco sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            ConfigurarEventHandlers();
        }

        private void ConfigurarEventHandlers()
        {
            this.btnRegistrar.Click += btnRegistrar_Click;
            this.btnListar.Click += btnListar_Click;
            this.btnSalir.Click += btnSalir_Click;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var servicio = new Servicio
                {
                    IdServicio = txtId.Text.Trim(),
                    Descripcion = txtDesc.Text.Trim()
                };

                sistema.Servicios.Agregar(servicio);
                MessageBox.Show($"Servicio {servicio.Descripcion} registrado con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar servicio:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            var formLista = new FormListaServicios(sistema);
            formLista.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtDesc.Clear();
        }
    }
}