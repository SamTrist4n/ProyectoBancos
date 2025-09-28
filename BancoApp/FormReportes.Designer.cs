namespace BancoApp
{
    partial class FormReportes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnReporteTransacciones;
        private System.Windows.Forms.Button btnReporteVentanillas;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnReporteTransacciones = new System.Windows.Forms.Button();
            this.btnReporteVentanillas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.btnSalir);
            this.panelPrincipal.Controls.Add(this.btnReporteVentanillas);
            this.panelPrincipal.Controls.Add(this.btnReporteTransacciones);
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(20);
            this.panelPrincipal.Size = new System.Drawing.Size(600, 400);
            this.panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(560, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reportes del Sistema";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReporteTransacciones
            // 
            this.btnReporteTransacciones.Location = new System.Drawing.Point(50, 80);
            this.btnReporteTransacciones.Name = "btnReporteTransacciones";
            this.btnReporteTransacciones.Size = new System.Drawing.Size(500, 40);
            this.btnReporteTransacciones.TabIndex = 1;
            this.btnReporteTransacciones.Text = "Reporte de Transacciones (Últimos 2 meses)";
            this.btnReporteTransacciones.UseVisualStyleBackColor = true;
            // 
            // btnReporteVentanillas
            // 
            this.btnReporteVentanillas.Location = new System.Drawing.Point(50, 140);
            this.btnReporteVentanillas.Name = "btnReporteVentanillas";
            this.btnReporteVentanillas.Size = new System.Drawing.Size(500, 40);
            this.btnReporteVentanillas.TabIndex = 2;
            this.btnReporteVentanillas.Text = "Reporte por Ventanilla y Atenciones";
            this.btnReporteVentanillas.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(50, 200);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(500, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FormReportes
            // 
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FormReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación de Reportes";
            this.panelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}