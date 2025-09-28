namespace BancoApp
{
    partial class FormSimulacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button btnIniciarDetener;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Label lblEstadoSimulacion;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.FlowLayoutPanel panelColas;
        private System.Windows.Forms.FlowLayoutPanel panelVentanillas;

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
        /// No se puede modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelColas = new System.Windows.Forms.FlowLayoutPanel();
            this.panelVentanillas = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEstadoSimulacion = new System.Windows.Forms.Label();
            this.panelControl = new System.Windows.Forms.Panel();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.btnIniciarDetener = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.splitContainer);
            this.panelPrincipal.Controls.Add(this.lblEstadoSimulacion);
            this.panelPrincipal.Controls.Add(this.panelControl);
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(10);
            this.panelPrincipal.Size = new System.Drawing.Size(1200, 800);
            this.panelPrincipal.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(10, 130);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelColas);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelVentanillas);
            this.splitContainer.Size = new System.Drawing.Size(1180, 660);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.TabIndex = 3;
            // 
            // panelColas
            // 
            this.panelColas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelColas.Location = new System.Drawing.Point(0, 0);
            this.panelColas.Name = "panelColas";
            this.panelColas.Size = new System.Drawing.Size(1180, 300);
            this.panelColas.TabIndex = 0;
            // 
            // panelVentanillas
            // 
            this.panelVentanillas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVentanillas.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.panelVentanillas.Location = new System.Drawing.Point(0, 0);
            this.panelVentanillas.Name = "panelVentanillas";
            this.panelVentanillas.Size = new System.Drawing.Size(1180, 356);
            this.panelVentanillas.TabIndex = 0;
            // 
            // lblEstadoSimulacion
            // 
            this.lblEstadoSimulacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEstadoSimulacion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.lblEstadoSimulacion.ForeColor = System.Drawing.Color.Red;
            this.lblEstadoSimulacion.Location = new System.Drawing.Point(10, 100);
            this.lblEstadoSimulacion.Name = "lblEstadoSimulacion";
            this.lblEstadoSimulacion.Size = new System.Drawing.Size(1180, 30);
            this.lblEstadoSimulacion.TabIndex = 2;
            this.lblEstadoSimulacion.Text = "Simulación detenida";
            this.lblEstadoSimulacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.btnAgregarCliente);
            this.panelControl.Controls.Add(this.btnIniciarDetener);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(10, 50);
            this.panelControl.Name = "panelControl";
            this.panelControl.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl.Size = new System.Drawing.Size(1180, 50);
            this.panelControl.TabIndex = 1;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Location = new System.Drawing.Point(170, 5);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(180, 40);
            this.btnAgregarCliente.TabIndex = 1;
            this.btnAgregarCliente.Text = "Agregar Cliente Aleatorio";
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            // 
            // btnIniciarDetener
            // 
            this.btnIniciarDetener.Location = new System.Drawing.Point(10, 5);
            this.btnIniciarDetener.Name = "btnIniciarDetener";
            this.btnIniciarDetener.Size = new System.Drawing.Size(150, 40);
            this.btnIniciarDetener.TabIndex = 0;
            this.btnIniciarDetener.Text = "Iniciar Simulación";
            this.btnIniciarDetener.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1180, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Simulación en Tiempo Real - Banco \'Tu Plata es Mía\'";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSimulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FormSimulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulación de Atención en Ventanillas";
            this.Load += new System.EventHandler(this.FormSimulacion_Load);
            this.panelPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}