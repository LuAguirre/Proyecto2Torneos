
namespace Administracion_Torneos.Vista
{
    partial class Reporte_Arbitrosss
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
            this.listArbitros = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listArbitros)).BeginInit();
            this.SuspendLayout();
            // 
            // listArbitros
            // 
            this.listArbitros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listArbitros.Location = new System.Drawing.Point(27, 201);
            this.listArbitros.Margin = new System.Windows.Forms.Padding(4);
            this.listArbitros.Name = "listArbitros";
            this.listArbitros.RowHeadersWidth = 51;
            this.listArbitros.Size = new System.Drawing.Size(758, 315);
            this.listArbitros.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(158, 77);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(455, 55);
            this.label7.TabIndex = 18;
            this.label7.Text = "Reporte de arbitros";
            // 
            // Reporte_Arbitrosss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(798, 576);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listArbitros);
            this.Name = "Reporte_Arbitrosss";
            this.Text = "Reporte_Arbitrosss";
            this.Load += new System.EventHandler(this.Reporte_Arbitrosss_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listArbitros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView listArbitros;
        private System.Windows.Forms.Label label7;
    }
}