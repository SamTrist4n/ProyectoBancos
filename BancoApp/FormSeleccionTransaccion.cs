using System;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class FormSeleccionTransaccion : Form
    {
        private SistemaBanco sistema;

        public FormSeleccionTransaccion(SistemaBanco sistema)
        {
            InitializeComponent();
            this.sistema = sistema;
            ConfigurarEventHandlers();
        }

        private void ConfigurarEventHandlers()
        {
            this.btnDeposito.Click += BtnDeposito_Click;
            this.btnRetiro.Click += BtnRetiro_Click;
        }

        private void BtnDeposito_Click(object sender, EventArgs e)
        {
            AbrirFormTransaccion("deposito");
        }

        private void BtnRetiro_Click(object sender, EventArgs e)
        {
            AbrirFormTransaccion("retiro");
        }

        private void AbrirFormTransaccion(string tipo)
        {
            // Verificar que hay clientes cargados
            if (sistema.Clientes.ObtenerTodos().Count == 0)
            {
                MessageBox.Show("No hay clientes cargados. Use 'Cargar Datos desde CSV' en el menú principal primero.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var formTransaccion = new FormTransaccion(sistema, tipo))
            {
                formTransaccion.ShowDialog();
            }
        }
    }
}