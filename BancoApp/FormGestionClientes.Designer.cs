namespace BancoApp
{
    partial class FormGestionClientes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblDiscapacidad;
        private System.Windows.Forms.CheckBox chkDiscapacidad;
        private System.Windows.Forms.Label lblNiños;
        private System.Windows.Forms.NumericUpDown nudNiños;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnListar;

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
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblDiscapacidad = new System.Windows.Forms.Label();
            this.chkDiscapacidad = new System.Windows.Forms.CheckBox();
            this.lblNiños = new System.Windows.Forms.Label();
            this.nudNiños = new System.Windows.Forms.NumericUpDown();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNiños)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(30, 40);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(32, 13);
            this.lblDNI.TabIndex = 0;
            this.lblDNI.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(150, 40);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(200, 20);
            this.txtDNI.TabIndex = 1;
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(30, 80);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(55, 13);
            this.lblNombres.TabIndex = 2;
            this.lblNombres.Text = "Nombres:";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(150, 80);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(300, 20);
            this.txtNombres.TabIndex = 3;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(30, 120);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(111, 13);
            this.lblFechaNacimiento.TabIndex = 4;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(200, 120);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(150, 20);
            this.dtpFechaNacimiento.TabIndex = 5;
            // 
            // lblDiscapacidad
            // 
            this.lblDiscapacidad.AutoSize = true;
            this.lblDiscapacidad.Location = new System.Drawing.Point(30, 160);
            this.lblDiscapacidad.Name = "lblDiscapacidad";
            this.lblDiscapacidad.Size = new System.Drawing.Size(75, 13);
            this.lblDiscapacidad.TabIndex = 6;
            this.lblDiscapacidad.Text = "Discapacidad:";
            // 
            // chkDiscapacidad
            // 
            this.chkDiscapacidad.Location = new System.Drawing.Point(150, 160);
            this.chkDiscapacidad.Name = "chkDiscapacidad";
            this.chkDiscapacidad.Size = new System.Drawing.Size(20, 20);
            this.chkDiscapacidad.TabIndex = 7;
            this.chkDiscapacidad.UseVisualStyleBackColor = true;
            // 
            // lblNiños
            // 
            this.lblNiños.AutoSize = true;
            this.lblNiños.Location = new System.Drawing.Point(30, 200);
            this.lblNiños.Name = "lblNiños";
            this.lblNiños.Size = new System.Drawing.Size(95, 13);
            this.lblNiños.TabIndex = 8;
            this.lblNiños.Text = "Número de Hijos:";
            // 
            // nudNiños
            // 
            this.nudNiños.Location = new System.Drawing.Point(150, 200);
            this.nudNiños.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNiños.Name = "nudNiños";
            this.nudNiños.Size = new System.Drawing.Size(120, 20);
            this.nudNiños.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 240);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 240);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(30, 280);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 12;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(150, 280);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 13;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(30, 320);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 14;
            this.lblMonto.Text = "Monto:";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMonto.Location = new System.Drawing.Point(150, 320);
            this.nudMonto.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(120, 20);
            this.nudMonto.TabIndex = 15;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(150, 380);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 40);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar Cliente";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(320, 380);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(150, 40);
            this.btnListar.TabIndex = 17;
            this.btnListar.Text = "Listar Clientes";
            this.btnListar.UseVisualStyleBackColor = true;
            // 
            // FormGestionClientes
            // 
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.nudNiños);
            this.Controls.Add(this.lblNiños);
            this.Controls.Add(this.chkDiscapacidad);
            this.Controls.Add(this.lblDiscapacidad);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.lblDNI);
            this.Name = "FormGestionClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.nudNiños)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}