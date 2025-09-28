using System;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class FormConfiguracionVentanillas : Form
    {
        private SistemaBanco sistema;

        public FormConfiguracionVentanillas(SistemaBanco sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            ConfigurarEventHandlers();
        }

        private void ConfigurarEventHandlers()
        {
            this.btnGuardar.Click += btnGuardar_Click;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            sistema.ConfigurarVentanillas((int)nudNormales.Value, (int)nudPreferenciales.Value);
            MessageBox.Show("Ventanillas configuradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}