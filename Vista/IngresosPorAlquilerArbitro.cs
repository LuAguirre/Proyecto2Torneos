using Administracion_Torneos.BD;
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
    public partial class IngresosPorAlquilerArbitro : Form
    {
        reportesLourdesDB dB = new reportesLourdesDB();
        public IngresosPorAlquilerArbitro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //obtener las fechas para el parametro de busqueda 
            DateTime horaInicial = dateTimePicker1.Value;
            DateTime horaFinal = dateTimePicker2.Value;
            //mostrar los datos en el datagridview 
            dataGridView1.DataSource = dB.getGananciaArbitro(horaInicial, horaFinal);
        }
    }
}
