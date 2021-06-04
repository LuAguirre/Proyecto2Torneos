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
    public partial class ModificarReserva : Form
    {
        reservaDB reserva = new reservaDB();
        reservaModelo r = new reservaModelo();
        public ModificarReserva()
        {
            InitializeComponent();
            cargarDatos();
        }
        //cargar datos de la base de datos 
        public void cargarDatos()
        {
            dataGridView1.DataSource = reserva.getReservas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int? buscar_id()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }
        private int? buscar_idCacha()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString());
            }

            catch
            {
                return null;
            }

        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            //mostrar datos seleccionados 
            int? idReserva = buscar_id();
            reservaModelo rm =  reserva.getReservaById(idReserva);

            textFecha.Text = Convert.ToString(rm.fecha);
            texthoraInicio.Text = Convert.ToString(rm.horaInicio);
            texthoraFinal.Text = Convert.ToString(rm.horaFinal);
            textBox4.Text = Convert.ToString(rm.costo);
           

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            TimeSpan horaApertura = new TimeSpan(8, 0, 0);
            TimeSpan horaCierre = new TimeSpan(23, 0, 0);
            int numeroCancha = Convert.ToInt32(buscar_idCacha());
            DateTime fecha1 = DateTime.Parse(textFecha.Text);
            TimeSpan horaInicio1 = TimeSpan.Parse(texthoraInicio.Text);
            TimeSpan horaFinal1 = TimeSpan.Parse(texthoraFinal.Text);
            //verificar que las  validaciones 
            int idJuego = reserva.getIdJuegoReservado(fecha1, horaInicio1, horaFinal1, numeroCancha);
            //txtHoraFinal.Text = Convert.ToString(idJuego);
            int idReserva1 = reserva.getIdJuegoReservadoPorCliente(fecha1, horaInicio1, horaFinal1, numeroCancha);
            if (idJuego >= 1 || idReserva1 >= 1)
            {
                MessageBox.Show("La fecha y hora no está disponible ");
            }
            else if (horaInicio1 < horaApertura || horaFinal1 < horaApertura)
            {
                MessageBox.Show("La hora de apertura de las canchas es 08:00 AM");
            }
            else if (horaFinal1 > horaCierre || horaInicio1 > horaCierre)
            {
                MessageBox.Show("La hora de cierre de las canchas es 11:00 PM");
            }
            else
            {
                //actualizar reserva
                int? idReserva = buscar_id();
                DateTime fecha = DateTime.Parse(textFecha.Text);
                TimeSpan horaInicio = TimeSpan.Parse(texthoraInicio.Text);
                TimeSpan horaFinal = TimeSpan.Parse(texthoraFinal.Text);
                decimal costo = decimal.Parse(textBox4.Text);

                reserva.updateReserva(idReserva, fecha, horaInicio, horaFinal, costo);
                cargarDatos();
                textFecha.Text = "";
                texthoraInicio.Text = "";
                texthoraFinal.Text = "";
                textBox4.Text = "";
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int? idReserva = buscar_id();
            reserva.deleteReserva(idReserva);
            cargarDatos();
        }
    }
}
