
namespace Administracion_Torneos.Vista
{
    partial class MenuOperador
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
            this.btnJugadores = new System.Windows.Forms.Button();
            this.btnPagoAmonestaciones = new System.Windows.Forms.Button();
            this.btnAmonestaciones = new System.Windows.Forms.Button();
            this.btnArbitros = new System.Windows.Forms.Button();
            this.btnEquipo = new System.Windows.Forms.Button();
            this.btnTorneo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnJugadores
            // 
            this.btnJugadores.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnJugadores.Location = new System.Drawing.Point(177, 233);
            this.btnJugadores.Margin = new System.Windows.Forms.Padding(4);
            this.btnJugadores.Name = "btnJugadores";
            this.btnJugadores.Size = new System.Drawing.Size(124, 49);
            this.btnJugadores.TabIndex = 15;
            this.btnJugadores.Text = "Jugadores";
            this.btnJugadores.UseVisualStyleBackColor = false;
            this.btnJugadores.Click += new System.EventHandler(this.btnJugadores_Click);
            // 
            // btnPagoAmonestaciones
            // 
            this.btnPagoAmonestaciones.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPagoAmonestaciones.Location = new System.Drawing.Point(495, 233);
            this.btnPagoAmonestaciones.Margin = new System.Windows.Forms.Padding(4);
            this.btnPagoAmonestaciones.Name = "btnPagoAmonestaciones";
            this.btnPagoAmonestaciones.Size = new System.Drawing.Size(128, 49);
            this.btnPagoAmonestaciones.TabIndex = 14;
            this.btnPagoAmonestaciones.Text = "Pago Amonestaciones";
            this.btnPagoAmonestaciones.UseVisualStyleBackColor = false;
            this.btnPagoAmonestaciones.Click += new System.EventHandler(this.btnPagoAmonestaciones_Click);
            // 
            // btnAmonestaciones
            // 
            this.btnAmonestaciones.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAmonestaciones.Location = new System.Drawing.Point(495, 154);
            this.btnAmonestaciones.Margin = new System.Windows.Forms.Padding(4);
            this.btnAmonestaciones.Name = "btnAmonestaciones";
            this.btnAmonestaciones.Size = new System.Drawing.Size(128, 49);
            this.btnAmonestaciones.TabIndex = 13;
            this.btnAmonestaciones.Text = "Amonestaciones";
            this.btnAmonestaciones.UseVisualStyleBackColor = false;
            this.btnAmonestaciones.Click += new System.EventHandler(this.btnAmonestaciones_Click);
            // 
            // btnArbitros
            // 
            this.btnArbitros.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnArbitros.Location = new System.Drawing.Point(177, 154);
            this.btnArbitros.Margin = new System.Windows.Forms.Padding(4);
            this.btnArbitros.Name = "btnArbitros";
            this.btnArbitros.Size = new System.Drawing.Size(124, 49);
            this.btnArbitros.TabIndex = 12;
            this.btnArbitros.Text = "Arbitros";
            this.btnArbitros.UseVisualStyleBackColor = false;
            this.btnArbitros.Click += new System.EventHandler(this.btnArbitros_Click);
            // 
            // btnEquipo
            // 
            this.btnEquipo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEquipo.Location = new System.Drawing.Point(495, 67);
            this.btnEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEquipo.Name = "btnEquipo";
            this.btnEquipo.Size = new System.Drawing.Size(128, 49);
            this.btnEquipo.TabIndex = 11;
            this.btnEquipo.Text = "Equipo";
            this.btnEquipo.UseVisualStyleBackColor = false;
            this.btnEquipo.Click += new System.EventHandler(this.btnEquipo_Click);
            // 
            // btnTorneo
            // 
            this.btnTorneo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTorneo.Location = new System.Drawing.Point(177, 67);
            this.btnTorneo.Margin = new System.Windows.Forms.Padding(4);
            this.btnTorneo.Name = "btnTorneo";
            this.btnTorneo.Size = new System.Drawing.Size(124, 49);
            this.btnTorneo.TabIndex = 10;
            this.btnTorneo.Text = "Torneo";
            this.btnTorneo.UseVisualStyleBackColor = false;
            this.btnTorneo.Click += new System.EventHandler(this.btnTorneo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(135, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 42);
            this.label1.TabIndex = 9;
            this.label1.Text = "Control de Torneos  PLUSTI";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MenuOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Administracion_Torneos.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(797, 363);
            this.Controls.Add(this.btnJugadores);
            this.Controls.Add(this.btnPagoAmonestaciones);
            this.Controls.Add(this.btnAmonestaciones);
            this.Controls.Add(this.btnArbitros);
            this.Controls.Add(this.btnEquipo);
            this.Controls.Add(this.btnTorneo);
            this.Controls.Add(this.label1);
            this.Name = "MenuOperador";
            this.Text = "MenuControlReportes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuOperador_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJugadores;
        private System.Windows.Forms.Button btnPagoAmonestaciones;
        private System.Windows.Forms.Button btnAmonestaciones;
        private System.Windows.Forms.Button btnArbitros;
        private System.Windows.Forms.Button btnEquipo;
        private System.Windows.Forms.Button btnTorneo;
        private System.Windows.Forms.Label label1;
    }
}