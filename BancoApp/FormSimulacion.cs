using System;
using System.Windows.Forms;
using System.Drawing;

namespace BancoApp
{
    public partial class FormSimulacion : Form
    {
        private SistemaBanco sistema;
        private System.Windows.Forms.Timer timerSimulacion;

        public FormSimulacion(SistemaBanco sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            ConfigurarTimer();
            ConfigurarEventHandlers();
            ConfigurarControlesAdicionales();
        }

        private void ConfigurarControlesAdicionales()
        {
            // Configurar propiedades adicionales que no están en el diseñador
            panelColas.AutoScroll = true;
            panelColas.BorderStyle = BorderStyle.FixedSingle;
            panelColas.Padding = new Padding(10);

            panelVentanillas.WrapContents = true;
            panelVentanillas.AutoScroll = true;
            panelVentanillas.BorderStyle = BorderStyle.FixedSingle;
            panelVentanillas.Padding = new Padding(10);
        }

        private void ConfigurarTimer()
        {
            timerSimulacion = new System.Windows.Forms.Timer();
            timerSimulacion.Interval = 1000;
            timerSimulacion.Tick += TimerSimulacion_Tick;
        }

        private void ConfigurarEventHandlers()
        {
            this.btnIniciarDetener.Click += BtnIniciarDetener_Click;
            this.btnAgregarCliente.Click += BtnAgregarCliente_Click;
            this.FormClosing += FormSimulacion_FormClosing;
        }

        private void BtnIniciarDetener_Click(object sender, EventArgs e)
        {
            if (timerSimulacion.Enabled)
            {
                timerSimulacion.Stop();
                btnIniciarDetener.Text = "Iniciar Simulación";
                lblEstadoSimulacion.Text = "Simulación detenida";
                lblEstadoSimulacion.ForeColor = Color.Red;
            }
            else
            {
                timerSimulacion.Start();
                btnIniciarDetener.Text = "Detener Simulación";
                lblEstadoSimulacion.Text = "Simulación en curso...";
                lblEstadoSimulacion.ForeColor = Color.Green;
            }
        }

        private void BtnAgregarCliente_Click(object sender, EventArgs e)
        {
            AgregarClienteAleatorio();
            ActualizarVisualizacion();
        }

        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            sistema.ProcesarAtenciones();
            ActualizarVisualizacion();
        }

        private void AgregarClienteAleatorio()
        {
            Random rnd = new Random();
            var cliente = new Cliente
            {
                DNI = "DNI" + rnd.Next(10000000, 99999999).ToString(),
                Nombres = "Cliente " + rnd.Next(1, 1000),
                FechaNacimiento = DateTime.Now.AddYears(-rnd.Next(18, 85)),
                Discapacidad = rnd.Next(0, 10) == 0,
                Niños = rnd.Next(0, 4),
                Email = "cliente" + rnd.Next(1, 1000) + "@ejemplo.com",
                Telefono = "9" + rnd.Next(10000000, 99999999).ToString(),
                Monto = rnd.Next(100, 10000)
            };

            string nroTicket = sistema.AgregarClienteACola(cliente);
            MessageBox.Show($"Cliente {cliente.Nombres} agregado.\nTicket: {nroTicket}\nPrioridad: {cliente.CalcularPrioridad()}\nTiempo: {cliente.CalcularTiempoAtencion()}s",
                "Cliente Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarVisualizacion()
        {
            ActualizarColas();
            ActualizarVentanillas();
        }

        private void ActualizarColas()
        {
            panelColas.Controls.Clear();

            GroupBox gbPreferencial = new GroupBox
            {
                Text = "COLA PREFERENCIAL (Prioridad 1-2) - CAPACIDAD ILIMITADA",
                Width = 400,
                Height = 180,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label lblPreferencial = new Label
            {
                Text = $"Clientes en cola: {sistema.ColaPreferencial.Tamaño()}",
                Location = new Point(10, 30),
                Width = 380,
                Font = new Font("Consolas", 12, FontStyle.Bold),
                ForeColor = Color.Blue
            };

            gbPreferencial.Controls.Add(lblPreferencial);
            panelColas.Controls.Add(gbPreferencial);

            GroupBox gbNormal = new GroupBox
            {
                Text = "COLA NORMAL (Prioridad 3) - CAPACIDAD: 10",
                Width = 400,
                Height = 180,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label lblNormal = new Label
            {
                Text = $"Clientes en cola: {sistema.ColaNormal.Tamaño()}",
                Location = new Point(10, 30),
                Width = 380,
                Font = new Font("Consolas", 12, FontStyle.Bold),
                ForeColor = sistema.ColaNormal.EstaLlena() ? Color.Red : Color.Green
            };

            Label lblEstado = new Label
            {
                Text = sistema.ColaNormal.EstaLlena() ? "¡COLA LLENA!" : "Disponible",
                Location = new Point(10, 60),
                Width = 380,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = sistema.ColaNormal.EstaLlena() ? Color.Red : Color.Green
            };

            gbNormal.Controls.Add(lblNormal);
            gbNormal.Controls.Add(lblEstado);
            panelColas.Controls.Add(gbNormal);
        }

        private void ActualizarVentanillas()
        {
            panelVentanillas.Controls.Clear();

            foreach (var ventanilla in sistema.Ventanillas)
            {
                GroupBox gbVentanilla = new GroupBox
                {
                    Text = $"VENTANILLA {ventanilla.NroVentanilla} {(ventanilla.Preferencial ? "(PREFERENCIAL)" : "(NORMAL)")} ",
                    Width = 220,
                    Height = 200,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    ForeColor = ventanilla.Preferencial ? Color.Blue : Color.Black
                };

                Label lblCajero = new Label
                {
                    Text = $"Cajero: {ventanilla.DNICajero ?? "SIN ASIGNAR"}",
                    Location = new Point(10, 25),
                    Width = 200,
                    Font = new Font("Arial", 8, FontStyle.Italic)
                };

                Label lblCliente = new Label
                {
                    Location = new Point(10, 50),
                    Width = 200,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Bold)
                };

                ProgressBar pbTiempo = new ProgressBar
                {
                    Location = new Point(10, 100),
                    Width = 200,
                    Height = 25
                };

                Label lblTiempo = new Label
                {
                    Location = new Point(10, 135),
                    Width = 200,
                    Height = 30,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Consolas", 10, FontStyle.Bold)
                };

                if (ventanilla.Atendido)
                {
                    lblCliente.Text = $"ATENDIENDO:\n{ventanilla.DNICliente}";
                    lblCliente.ForeColor = Color.Red;
                    pbTiempo.Maximum = ventanilla.TiempoRestante + 5;
                    pbTiempo.Value = ventanilla.TiempoRestante;
                    lblTiempo.Text = $"{ventanilla.TiempoRestante} seg restantes";
                    lblTiempo.ForeColor = Color.DarkRed;
                }
                else
                {
                    lblCliente.Text = "✅ LIBRE";
                    lblCliente.ForeColor = Color.Green;
                    pbTiempo.Visible = false;
                    lblTiempo.Text = "Esperando cliente...";
                    lblTiempo.ForeColor = Color.Gray;
                }

                gbVentanilla.Controls.Add(lblCajero);
                gbVentanilla.Controls.Add(lblCliente);
                gbVentanilla.Controls.Add(pbTiempo);
                gbVentanilla.Controls.Add(lblTiempo);
                panelVentanillas.Controls.Add(gbVentanilla);
            }
        }

        private void FormSimulacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerSimulacion.Stop();
        }

        private void FormSimulacion_Load(object sender, EventArgs e)
        {
            // Código adicional al cargar el formulario si es necesario
        }
    }
}