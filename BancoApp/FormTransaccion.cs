using System;
using System.Windows.Forms;
using System.Linq;

namespace BancoApp
{
    public partial class FormTransaccion : Form
    {
        private SistemaBanco sistema;
        private string tipoTransaccion;

        public FormTransaccion(SistemaBanco sistema, string tipoTransaccion)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.tipoTransaccion = tipoTransaccion;
            ConfigurarFormulario();
            CargarClientes();
            ConfigurarEventHandlers();
        }

        private void ConfigurarFormulario()
        {
            this.Text = $"Transacción - {tipoTransaccion.ToUpper()}";
            lblTitulo.Text = $"Realizar {tipoTransaccion}";
            lblIdServicio.Text = tipoTransaccion == "deposito" ? "1" : "2";
        }

        private void ConfigurarEventHandlers()
        {
            this.btnProcesar.Click += BtnProcesar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = sistema.Clientes.ObtenerTodos();
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "Nombres";
                cmbClientes.ValueMember = "DNI";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var cliente = (Cliente)cmbClientes.SelectedItem;
                string idServicio = tipoTransaccion == "deposito" ? "1" : "2";
                int segundos = cliente.CalcularTiempoAtencion();

                // Buscar ventanilla disponible según prioridad del cliente
                var ventanilla = AsignarVentanilla(cliente);

                if (ventanilla == null)
                {
                    MessageBox.Show("No hay ventanillas disponibles para atender al cliente", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Registrar la transacción
                RegistrarTransaccion(cliente, ventanilla, idServicio, monto, segundos);

                MessageBox.Show($"Transacción realizada exitosamente:\n" +
                              $"Cliente: {cliente.Nombres}\n" +
                              $"Servicio: {tipoTransaccion}\n" +
                              $"Monto: ${monto}\n" +
                              $"Ventanilla: {ventanilla.NroVentanilla}\n" +
                              $"Tiempo: {segundos} segundos",
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar transacción: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Ventanilla AsignarVentanilla(Cliente cliente)
        {
            int prioridad = cliente.CalcularPrioridad();
            bool esPreferencial = (prioridad == 1 || prioridad == 2);

            // Buscar ventanilla disponible del tipo correspondiente
            var ventanilla = sistema.Ventanillas
                .FirstOrDefault(v => !v.Atendido && v.Preferencial == esPreferencial);

            if (ventanilla != null)
            {
                string nroTicket = sistema.GenerarNumeroTicket();
                int tiempoAtencion = cliente.CalcularTiempoAtencion();
                ventanilla.AsignarCliente(cliente.DNI, nroTicket, tiempoAtencion);
                return ventanilla;
            }

            return null;
        }

        private void RegistrarTransaccion(Cliente cliente, Ventanilla ventanilla, string idServicio, decimal monto, int segundos)
        {
            var atencion = new Atencion
            {
                NroTicket = ventanilla.NroTicket,
                FechaHora = DateTime.Now,
                IdCliente = cliente.DNI,
                IdCajero = ventanilla.DNICajero,
                IdServicio = idServicio,
                Monto = monto,
                Segundos = segundos
            };

            sistema.Atenciones.Agregar(atencion);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}