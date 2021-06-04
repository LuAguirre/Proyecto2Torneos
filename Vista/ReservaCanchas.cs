using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Vista
{
    public partial class ReservaCanchas : Form
    {
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";
        public string nombreSeleccionado;

        reservaDB reserva = new reservaDB();
        reservaModelo rm = new reservaModelo();

        public ReservaCanchas()
        {
            InitializeComponent();
            getNombreCancha();
            getNombreCliente();
        }

        //método para obtener el nombre de la cancha 
        private void getNombreCancha()
        {

            string query = "exec obtenerNombreCancha";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    txtNombreCancha.Items.Add(reader["nombre"].ToString());
                }
                connection.Close();
            }
        }

        //método para obtener el nombre del cliente 
        private void getNombreCliente()
        {

            string query = "exec nombreClientes";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    txtNombreCliente.Items.Add(reader["nombre"].ToString());
                }
                connection.Close();
            }
        }

        
        //método para obtener el apellido del cliente 
        private void getApellidoCliente(string nombre)
        {

            string query = "exec apellidoCliente @nombre";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre", nombre);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    txtApellidoCliente.Items.Add(reader["apellido"].ToString());
                }
                connection.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //establecer hora de apertura y cierre del negocio 
            TimeSpan horaApertura = new TimeSpan(8, 0, 0);
            TimeSpan horaCierre = new TimeSpan(23, 0, 0);
            
            int numeroCancha = reserva.getNumeroCancha(txtNombreCancha.Text);
            long dpi = reserva.getDPICliente(txtNombreCliente.Text, txtApellidoCliente.Text);
            DateTime fecha = fechaReserva.Value;
            TimeSpan horaInicio = TimeSpan.Parse(textHI.Text);
            TimeSpan horaFinal = TimeSpan.Parse(textBox2.Text);
            //decimal monto = Convert.ToDecimal(textBox1.Text);
            int idJuego = reserva.getIdJuegoReservado(fecha, horaInicio, horaFinal, numeroCancha);
            //txtHoraFinal.Text = Convert.ToString(idJuego);
            int idReserva = reserva.getIdJuegoReservadoPorCliente(fecha, horaInicio, horaFinal, numeroCancha);
            //verificar que se cumplan las restricciones para reservar cancha
            if(idJuego >= 1 || idReserva >= 1)
            {
                MessageBox.Show("La fecha y hora no está disponible ");
            }
            else if (horaInicio < horaApertura || horaFinal < horaApertura)
            {
                MessageBox.Show("La hora de apertura de las canchas es 08:00 AM");
            }
            else if(horaFinal > horaCierre || horaInicio > horaCierre)
            {
                MessageBox.Show("La hora de cierre de las canchas es 11:00 PM");
            }
            else
            {
                //reservar cancha 
                rm.idCancha = numeroCancha;
                rm.DPI = dpi;
                rm.fecha = fecha;
                rm.horaInicio = TimeSpan.Parse(textBox2.Text);
                rm.horaFinal = TimeSpan.Parse(textHI.Text);
                
                rm.costo = decimal.Parse(textBox1.Text);
                reserva.addReservaCancha(rm);
                //limpiar los textbox
                textBox1.Text = "";
                textBox2.Text = "";
                txtApellidoCliente.Text = "";
                txtNombreCancha.Text = "";
                txtNombreCliente.Text = "";
                textHI.Text = "";
            }



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtApellidoCliente.Items.Clear();
            nombreSeleccionado = txtNombreCliente.Text;
            getApellidoCliente(nombreSeleccionado);
            nombreSeleccionado = "";
        }

        private void radioReservasTorneo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;

            if(rd.Checked)
            {
                dataGridView1.DataSource = reserva.getReservasPorTorneo();
            }
            else
            {
                dataGridView1.DataSource = reserva.getReservas();
            }

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ModificarReserva m = new ModificarReserva();
            m.Show();
        }

        private void buttonEliminarReserva_Click(object sender, EventArgs e)
        {
            ReservaArbitro ra = new ReservaArbitro();
            ra.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TotalesReserva totales = new TotalesReserva();
            totales.Show();
        }
    }
}
