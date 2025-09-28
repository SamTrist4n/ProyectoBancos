using System;
using System.Windows.Forms;
using System.Drawing;

namespace BancoApp
{
    public partial class FormListaClientes : Form
    {
        private SistemaBanco sistema;

        public FormListaClientes(SistemaBanco sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDatos();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar columnas
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "DNI", DataPropertyName = "DNI", Width = 100 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombres", DataPropertyName = "Nombres", Width = 200 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Edad", DataPropertyName = "Edad", Width = 60 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Discapacidad", DataPropertyName = "Discapacidad", Width = 100 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "N° Hijos", DataPropertyName = "Niños", Width = 80 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Width = 200 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = "Telefono", Width = 120 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Monto", DataPropertyName = "Monto", Width = 100 });
        }

        private void CargarDatos()
        {
            var listaClientes = sistema.Clientes.ObtenerTodos();
            dgvClientes.Rows.Clear();

            foreach (var cliente in listaClientes)
            {
                int edad = CalcularEdad(cliente.FechaNacimiento);
                dgvClientes.Rows.Add(
                    cliente.DNI,
                    cliente.Nombres,
                    edad,
                    cliente.Discapacidad ? "Sí" : "No",
                    cliente.Niños,
                    cliente.Email,
                    cliente.Telefono,
                    cliente.Monto.ToString("C") // Formato de moneda
                );
            }
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }
    }
}