using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.BD;

namespace Administracion_Torneos.Vista
{
    public partial class Reporte_Arbitrosss : Form
    {

        public arbitroDB arbitrosContext = new arbitroDB();
        public Arbitro arbitroSeleccionado = new Arbitro();
        public Reporte_Arbitrosss()
        {
            InitializeComponent();
            listArbitros.AllowUserToAddRows = false;
            listArbitros.AllowDrop = false;
            listArbitros.AllowUserToDeleteRows = false;
            mostrar();
        }
        public void mostrar()
        {
            listArbitros.DataSource = arbitrosContext.manejoArbitros();
        }
        private void Reporte_Arbitrosss_Load(object sender, EventArgs e)
        {

        }
    }
}
