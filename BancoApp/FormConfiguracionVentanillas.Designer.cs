namespace BancoApp
{
    partial class FormConfiguracionVentanillas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNormales;
        private System.Windows.Forms.NumericUpDown nudNormales;
        private System.Windows.Forms.Label lblPreferenciales;
        private System.Windows.Forms.NumericUpDown nudPreferenciales;
        private System.Windows.Forms.Button btnGuardar;

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
            this.lblNormales = new System.Windows.Forms.Label();
            this.nudNormales = new System.Windows.Forms.NumericUpDown();
            this.lblPreferenciales = new System.Windows.Forms.Label();
            this.nudPreferenciales = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreferenciales)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNormales
            // 
            this.lblNormales.AutoSize = true;
            this.lblNormales.Location = new System.Drawing.Point(30, 50);
            this.lblNormales.Name = "lblNormales";
            this.lblNormales.Size = new System.Drawing.Size(200, 13);
            this.lblNormales.TabIndex = 0;
            this.lblNormales.Text = "Número de ventanillas normales:";
            // 
            // nudNormales
            // 
            this.nudNormales.Location = new System.Drawing.Point(300, 50);
            this.nudNormales.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNormales.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudNormales.Name = "nudNormales";
            this.nudNormales.Size = new System.Drawing.Size(120, 20);
            this.nudNormales.TabIndex = 1;
            this.nudNormales.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblPreferenciales
            // 
            this.lblPreferenciales.AutoSize = true;
            this.lblPreferenciales.Location = new System.Drawing.Point(30, 100);
            this.lblPreferenciales.Name = "lblPreferenciales";
            this.lblPreferenciales.Size = new System.Drawing.Size(220, 13);
            this.lblPreferenciales.TabIndex = 2;
            this.lblPreferenciales.Text = "Número de ventanillas preferenciales:";
            // 
            // nudPreferenciales
            // 
            this.nudPreferenciales.Location = new System.Drawing.Point(300, 100);
            this.nudPreferenciales.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPreferenciales.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPreferenciales.Name = "nudPreferenciales";
            this.nudPreferenciales.Size = new System.Drawing.Size(120, 20);
            this.nudPreferenciales.TabIndex = 3;
            this.nudPreferenciales.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(150, 180);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 40);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar Configuración";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FormConfiguracionVentanillas
            // 
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.nudPreferenciales);
            this.Controls.Add(this.lblPreferenciales);
            this.Controls.Add(this.nudNormales);
            this.Controls.Add(this.lblNormales);
            this.Name = "FormConfiguracionVentanillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de Ventanillas";
            ((System.ComponentModel.ISupportInitialize)(this.nudNormales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreferenciales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}