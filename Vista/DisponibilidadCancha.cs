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
    public partial class DisponibilidadCancha : Form
    {
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";
        public string nombreSeleccionado;
        reservaDB reserva = new reservaDB();
        public List<horario> h = new List<horario>();
        public DisponibilidadCancha()
        {
            InitializeComponent();
            //obtener los nombres de las canchas desde que se inicia la aplicación
            getNombreCancha();
        }

        //método para obtener el nombre de las canchas 
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
                    comboBox1.Items.Add(reader["nombre"].ToString());
                }
                connection.Close();
            }
        }
        //obtener los horarios de las canchas reservadas
        public List<modeloReserva> getReservas(DateTime fecha, int idCancha)
        {
            List<modeloReserva> reservas = new List<modeloReserva>();
            //query para obtner daos 
            string query = "exec obtnerHorarios @fecha, @idCancha";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fecha", fecha);
                sql.Parameters.AddWithValue("@idCancha", idCancha);

                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        modeloReserva reserva = new modeloReserva();
                        reserva.horaInicio = reader.GetTimeSpan(0);
                        reserva.horaFinal = reader.GetTimeSpan(1);

                        reservas.Add(reserva);
                    }
                    reader.Close();
                    connection.Close();
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return reservas;
        }
        //método para el llenado de la lista de comparación
        public void llenadoLista()
        {
           
            h.Add(new horario { horaInicio = "08:00", horaFinal = "09:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "09:00", horaFinal = "10:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "10:00", horaFinal = "11:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "11:00", horaFinal = "12:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "12:00", horaFinal = "13:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "13:00", horaFinal = "14:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "14:00", horaFinal = "15:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "15:00", horaFinal = "16:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "16:00", horaFinal = "17:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "17:00", horaFinal = "18:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "18:00", horaFinal = "19:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "19:00", horaFinal = "20:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "20:00", horaFinal = "21:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "21:00", horaFinal = "22:00", status = "Disponible" });
            h.Add(new horario { horaInicio = "22:00", horaFinal = "23:00", status = "Disponible" });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //limpiar la lista de comparación 
            h.Clear();
            //invocar al método para llenado de la lista 
            llenadoLista();

            //obtener el numero de la cancha 
            int numeroCancha = reserva.getNumeroCancha(comboBox1.Text);

            DateTime fecha = dateTimePicker1.Value;
            List<modeloReserva> list = getReservas(fecha, numeroCancha);

            

            dataGridView1.DataSource = getReservas(fecha, numeroCancha);
            //se recorre la lista modelo y la lista obtenida desde la base de datos 
            foreach (horario hr in h)
            {
                foreach (modeloReserva modelo in list)
                {
                    //si se encuentran coincidencias 
                    if (TimeSpan.Parse(hr.horaInicio) == modelo.horaInicio && TimeSpan.Parse(hr.horaFinal) == modelo.horaFinal)
                    {
                        //el dato cambia a no disponible 
                        hr.status = "No Disponible";

                    } else if (TimeSpan.Parse(hr.horaInicio) == modelo.horaInicio || TimeSpan.Parse(hr.horaFinal) == modelo.horaFinal)
                    {
                        //el dato cambia a no disponible 
                        hr.status = "No Disponible";

                    }


                }

            }

            dataGridView1.DataSource = h;


        }

    }
}
