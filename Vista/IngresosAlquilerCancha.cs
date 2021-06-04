using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Vista
{
    public partial class IngresosAlquilerCancha : Form
    {
        public IngresosAlquilerCancha()
        {
            InitializeComponent();
        }


        reportesLourdesDB dB = new reportesLourdesDB();

        private void IngresosAlquilerCancha_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //obtener las fechas para el parametro de busqueda 
            DateTime fechaInicial = dateTimePicker1.Value;
            DateTime fechaFinal = dateTimePicker2.Value;
            //mostrar los datos obtenidos en el datagridview 
            dataGridView1.DataSource = dB.getGananciaCancha(fechaInicial, fechaFinal);

        }
    }
}
