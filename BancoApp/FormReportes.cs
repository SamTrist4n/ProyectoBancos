using System;
using System.Windows.Forms;
using System.IO;

namespace BancoApp
{
    public partial class FormReportes : Form
    {
        private SistemaBanco sistema;

        public FormReportes(SistemaBanco sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            ConfigurarEventHandlers();
        }

        private void ConfigurarEventHandlers()
        {
            this.btnReporteTransacciones.Click += BtnReporteTransacciones_Click;
            this.btnReporteVentanillas.Click += BtnReporteVentanillas_Click;
            this.btnSalir.Click += btnSalir_Click;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReporteTransacciones_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Archivos CSV (*.csv)|*.csv",
                FileName = "Reporte_Transacciones_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sistema.ExportarReporteTransacciones(saveFileDialog.FileName);
                    MessageBox.Show($"Reporte de transacciones generado exitosamente.\n\nUbicación: {saveFileDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el reporte:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReporteVentanillas_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Archivos CSV (*.csv)|*.csv",
                FileName = "Reporte_Ventanillas_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sistema.ExportarReporteVentanillas(saveFileDialog.FileName);
                    MessageBox.Show($"Reporte por ventanilla generado exitosamente.\n\nUbicación: {saveFileDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el reporte:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}