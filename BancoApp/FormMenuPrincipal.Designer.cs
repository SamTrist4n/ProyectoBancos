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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.btnGestionCajeros = new System.Windows.Forms.Button();
            this.btnGestionServicios = new System.Windows.Forms.Button();
            this.btnConfigurarVentanillas = new System.Windows.Forms.Button();
            this.btnIniciarSimulacion = new System.Windows.Forms.Button();
            this.btnGenerarReportes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.btnCargarDatos);
            this.panelPrincipal.Controls.Add(this.btnSalir);
            this.panelPrincipal.Controls.Add(this.btnGenerarReportes);
            this.panelPrincipal.Controls.Add(this.btnIniciarSimulacion);
            this.panelPrincipal.Controls.Add(this.btnConfigurarVentanillas);
            this.panelPrincipal.Controls.Add(this.btnGestionServicios);
            this.panelPrincipal.Controls.Add(this.btnGestionCajeros);
            this.panelPrincipal.Controls.Add(this.btnGestionClientes);
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(20);
            this.panelPrincipal.Size = new System.Drawing.Size(800, 600);
            this.panelPrincipal.TabIndex = 0;
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.Location = new System.Drawing.Point(400, 100);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(300, 40);
            this.btnCargarDatos.TabIndex = 8;
            this.btnCargarDatos.Text = "Cargar Datos desde CSV";
            this.btnCargarDatos.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(760, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Menú Principal";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.Location = new System.Drawing.Point(50, 100);
            this.btnGestionClientes.Name = "btnGestionClientes";
            this.btnGestionClientes.Size = new System.Drawing.Size(300, 40);
            this.btnGestionClientes.TabIndex = 1;
            this.btnGestionClientes.Text = "Gestión de Clientes";
            this.btnGestionClientes.UseVisualStyleBackColor = true;
            // 
            // btnGestionCajeros
            // 
            this.btnGestionCajeros.Location = new System.Drawing.Point(50, 160);
            this.btnGestionCajeros.Name = "btnGestionCajeros";
            this.btnGestionCajeros.Size = new System.Drawing.Size(300, 40);
            this.btnGestionCajeros.TabIndex = 2;
            this.btnGestionCajeros.Text = "Gestión de Cajeros";
            this.btnGestionCajeros.UseVisualStyleBackColor = true;
            // 
            // btnGestionServicios
            // 
            this.btnGestionServicios.Location = new System.Drawing.Point(50, 220);
            this.btnGestionServicios.Name = "btnGestionServicios";
            this.btnGestionServicios.Size = new System.Drawing.Size(300, 40);
            this.btnGestionServicios.TabIndex = 3;
            this.btnGestionServicios.Text = "Gestión de Servicios";
            this.btnGestionServicios.UseVisualStyleBackColor = true;
            // 
            // btnConfigurarVentanillas
            // 
            this.btnConfigurarVentanillas.Location = new System.Drawing.Point(50, 280);
            this.btnConfigurarVentanillas.Name = "btnConfigurarVentanillas";
            this.btnConfigurarVentanillas.Size = new System.Drawing.Size(300, 40);
            this.btnConfigurarVentanillas.TabIndex = 4;
            this.btnConfigurarVentanillas.Text = "Configuración de Ventanillas";
            this.btnConfigurarVentanillas.UseVisualStyleBackColor = true;
            // 
            // btnIniciarSimulacion
            // 
            this.btnIniciarSimulacion.Location = new System.Drawing.Point(50, 340);
            this.btnIniciarSimulacion.Name = "btnIniciarSimulacion";
            this.btnIniciarSimulacion.Size = new System.Drawing.Size(300, 40);
            this.btnIniciarSimulacion.TabIndex = 5;
            this.btnIniciarSimulacion.Text = "Iniciar Simulación Gráfica";
            this.btnIniciarSimulacion.UseVisualStyleBackColor = true;
            // 
            // btnGenerarReportes
            // 
            this.btnGenerarReportes.Location = new System.Drawing.Point(50, 400);
            this.btnGenerarReportes.Name = "btnGenerarReportes";
            this.btnGenerarReportes.Size = new System.Drawing.Size(300, 40);
            this.btnGenerarReportes.TabIndex = 6;
            this.btnGenerarReportes.Text = "Generar Reportes";
            this.btnGenerarReportes.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(50, 460);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(300, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión - Banco 'Tu Plata es Mía'";
            this.panelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}