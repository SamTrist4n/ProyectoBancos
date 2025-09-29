namespace BancoApp
{
    partial class FormSeleccionTransaccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDeposito = new System.Windows.Forms.Button();
            this.btnRetiro = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeposito
            // 
            this.btnDeposito.BackColor = System.Drawing.Color.LightGreen;
            this.btnDeposito.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeposito.Location = new System.Drawing.Point(50, 80);
            this.btnDeposito.Name = "btnDeposito";
            this.btnDeposito.Size = new System.Drawing.Size(200, 50);
            this.btnDeposito.TabIndex = 0;
            this.btnDeposito.Text = "DEPÓSITO";
            this.btnDeposito.UseVisualStyleBackColor = false;
            // 
            // btnRetiro
            // 
            this.btnRetiro.BackColor = System.Drawing.Color.LightCoral;
            this.btnRetiro.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnRetiro.Location = new System.Drawing.Point(50, 150);
            this.btnRetiro.Name = "btnRetiro";
            this.btnRetiro.Size = new System.Drawing.Size(200, 50);
            this.btnRetiro.TabIndex = 1;
            this.btnRetiro.Text = "RETIRO";
            this.btnRetiro.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(30, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(240, 22);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Seleccione Tipo de Transacción";
            // 
            // FormSeleccionTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnRetiro);
            this.Controls.Add(this.btnDeposito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSeleccionTransaccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transacciones Manuales";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeposito;
        private System.Windows.Forms.Button btnRetiro;
        private System.Windows.Forms.Label lblTitulo;
    }
}