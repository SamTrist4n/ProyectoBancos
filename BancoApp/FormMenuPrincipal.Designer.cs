namespace BancoApp
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Button btnGestionCajeros;
        private System.Windows.Forms.Button btnGestionServicios;
        private System.Windows.Forms.Button btnConfigurarVentanillas;
        private System.Windows.Forms.Button btnIniciarSimulacion;
        private System.Windows.Forms.Button btnGenerarReportes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCargarDatos;
        private System.Windows.Forms.Button btnTransacciones;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            panelPrincipal = new Panel();
            btnCargarDatos = new Button();
            btnSalir = new Button();
            btnGenerarReportes = new Button();
            btnIniciarSimulacion = new Button();
            btnConfigurarVentanillas = new Button();
            btnGestionServicios = new Button();
            btnGestionCajeros = new Button();
            btnGestionClientes = new Button();
            lblTitulo = new Label();
            btnTransacciones = new Button();
            panelPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.Controls.Add(btnCargarDatos);
            panelPrincipal.Controls.Add(btnSalir);
            panelPrincipal.Controls.Add(btnGenerarReportes);
            panelPrincipal.Controls.Add(btnIniciarSimulacion);
            panelPrincipal.Controls.Add(btnConfigurarVentanillas);
            panelPrincipal.Controls.Add(btnGestionServicios);
            panelPrincipal.Controls.Add(btnGestionCajeros);
            panelPrincipal.Controls.Add(btnGestionClientes);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(btnTransacciones);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Margin = new Padding(4, 5, 4, 5);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(25, 31, 25, 31);
            panelPrincipal.Size = new Size(1000, 938);
            panelPrincipal.TabIndex = 0;
            // 
            // btnCargarDatos
            // 
            btnCargarDatos.Location = new Point(500, 156);
            btnCargarDatos.Margin = new Padding(4, 5, 4, 5);
            btnCargarDatos.Name = "btnCargarDatos";
            btnCargarDatos.Size = new Size(375, 62);
            btnCargarDatos.TabIndex = 8;
            btnCargarDatos.Text = "Cargar Datos desde CSV";
            btnCargarDatos.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(62, 719);
            btnSalir.Margin = new Padding(4, 5, 4, 5);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(375, 62);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGenerarReportes
            // 
            btnGenerarReportes.Location = new Point(62, 625);
            btnGenerarReportes.Margin = new Padding(4, 5, 4, 5);
            btnGenerarReportes.Name = "btnGenerarReportes";
            btnGenerarReportes.Size = new Size(375, 62);
            btnGenerarReportes.TabIndex = 6;
            btnGenerarReportes.Text = "Generar Reportes";
            btnGenerarReportes.UseVisualStyleBackColor = true;
            // 
            // btnIniciarSimulacion
            // 
            btnIniciarSimulacion.Location = new Point(62, 531);
            btnIniciarSimulacion.Margin = new Padding(4, 5, 4, 5);
            btnIniciarSimulacion.Name = "btnIniciarSimulacion";
            btnIniciarSimulacion.Size = new Size(375, 62);
            btnIniciarSimulacion.TabIndex = 5;
            btnIniciarSimulacion.Text = "Iniciar Simulación Gráfica";
            btnIniciarSimulacion.UseVisualStyleBackColor = true;
            // 
            // btnConfigurarVentanillas
            // 
            btnConfigurarVentanillas.Location = new Point(62, 438);
            btnConfigurarVentanillas.Margin = new Padding(4, 5, 4, 5);
            btnConfigurarVentanillas.Name = "btnConfigurarVentanillas";
            btnConfigurarVentanillas.Size = new Size(375, 62);
            btnConfigurarVentanillas.TabIndex = 4;
            btnConfigurarVentanillas.Text = "Configuración de Ventanillas";
            btnConfigurarVentanillas.UseVisualStyleBackColor = true;
            // 
            // btnGestionServicios
            // 
            btnGestionServicios.Location = new Point(62, 344);
            btnGestionServicios.Margin = new Padding(4, 5, 4, 5);
            btnGestionServicios.Name = "btnGestionServicios";
            btnGestionServicios.Size = new Size(375, 62);
            btnGestionServicios.TabIndex = 3;
            btnGestionServicios.Text = "Gestión de Servicios";
            btnGestionServicios.UseVisualStyleBackColor = true;
            // 
            // btnGestionCajeros
            // 
            btnGestionCajeros.Location = new Point(62, 250);
            btnGestionCajeros.Margin = new Padding(4, 5, 4, 5);
            btnGestionCajeros.Name = "btnGestionCajeros";
            btnGestionCajeros.Size = new Size(375, 62);
            btnGestionCajeros.TabIndex = 2;
            btnGestionCajeros.Text = "Gestión de Cajeros";
            btnGestionCajeros.UseVisualStyleBackColor = true;
            // 
            // btnGestionClientes
            // 
            btnGestionClientes.Location = new Point(62, 156);
            btnGestionClientes.Margin = new Padding(4, 5, 4, 5);
            btnGestionClientes.Name = "btnGestionClientes";
            btnGestionClientes.Size = new Size(375, 62);
            btnGestionClientes.TabIndex = 1;
            btnGestionClientes.Text = "Gestión de Clientes";
            btnGestionClientes.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(25, 31);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(950, 78);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Menú Principal";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnTransacciones
            // 
            btnTransacciones.Location = new Point(500, 250);
            btnTransacciones.Margin = new Padding(4, 5, 4, 5);
            btnTransacciones.Name = "btnTransacciones";
            btnTransacciones.Size = new Size(375, 62);
            btnTransacciones.TabIndex = 9;
            btnTransacciones.Text = "Transacciones Manuales";
            btnTransacciones.UseVisualStyleBackColor = true;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 938);
            Controls.Add(panelPrincipal);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión - Banco 'Tu Plata es Mía'";
            panelPrincipal.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}