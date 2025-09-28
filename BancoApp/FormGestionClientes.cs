using System;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class FormGestionClientes : Form
    {
        private SistemaBanco sistema;

        public FormGestionClientes(SistemaBanco sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            ConfigurarEventHandlers();
        }

        private void ConfigurarEventHandlers()
        {
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnListar.Click += btnListar_Click;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                DNI = txtDNI.Text,
                Nombres = txtNombres.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Discapacidad = chkDiscapacidad.Checked,
                Niños = (int)nudNiños.Value,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Monto = nudMonto.Value
            };

            sistema.Clientes.Agregar(cliente);
            MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            FormListaClientes formLista = new FormListaClientes(sistema);
            formLista.ShowDialog();
        }

        private void LimpiarCampos()
        {
            txtDNI.Clear();
            txtNombres.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            chkDiscapacidad.Checked = false;
            nudNiños.Value = 0;
            txtEmail.Clear();
            txtTelefono.Clear();
            nudMonto.Value = 0;
        }
    }
}