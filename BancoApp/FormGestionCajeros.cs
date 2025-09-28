using System;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class FormGestionCajeros : Form
    {
        private SistemaBanco sistema;

        public FormGestionCajeros(SistemaBanco sistema)
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
                var cajero = new Cajero
                {
                    DNI = txtDNI.Text.Trim(),
                    Nombres = txtNombres.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim()
                };

                sistema.Cajeros.Agregar(cajero);
                MessageBox.Show($"Cajero {cajero.Nombres} registrado con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cajero:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            var formLista = new FormListaCajeros(sistema);
            formLista.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtDNI.Clear();
            txtNombres.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }
    }
}