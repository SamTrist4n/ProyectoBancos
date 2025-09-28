namespace BancoApp
{
    partial class FormListaCajeros
    {
        /// <summary>
        /// Variable del diseñador requerida
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar recursos
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.dgvCajeros = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajeros)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCajeros
            // 
            this.dgvCajeros.AllowUserToAddRows = false;
            this.dgvCajeros.AllowUserToDeleteRows = false;
            this.dgvCajeros.AutoGenerateColumns = false;
            this.dgvCajeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCajeros.Location = new System.Drawing.Point(10, 10);
            this.dgvCajeros.Name = "dgvCajeros";
            this.dgvCajeros.ReadOnly = true;
            this.dgvCajeros.Size = new System.Drawing.Size(564, 327);
            this.dgvCajeros.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrar.Location = new System.Drawing.Point(10, 337);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(564, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.dgvCajeros);
            this.panel.Controls.Add(this.btnCerrar);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(10);
            this.panel.Size = new System.Drawing.Size(584, 377);
            this.panel.TabIndex = 2;
            // 
            // FormListaCajeros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.panel);
            this.Name = "FormListaCajeros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Cajeros Registrados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajeros)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCajeros;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panel;
    }
}