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
    public partial class ReservaArbitro : Form
    {
        //instancia de las clases 
        reservaDB reserva = new reservaDB();
        reservaArbitro ra = new reservaArbitro();
        //ruta de conexión a la base de datos 
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";
        public string nombreSeleccionado;
        public ReservaArbitro()
        {
            InitializeComponent();
            //cargar componentes con los nombres y datos 
            getNombreArbitro();
            cargarDatos();
        }

        //método para cargar los datos en el datagridview
        public void cargarDatos()
        {
            dataGridView1.DataSource = reserva.getReservas();
        }

        //método para obtener los nombres de los arbitros 
        private void getNombreArbitro()
        {

            string query = "exec obtenerNombreArbitro";
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

        //método para obtener el apellido de los arbitros 
        private void getApellidoArbitro(string nombre)
        {

            string query = "exec obtenerApellidoArbitro @nombre";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre", nombre);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["apellidos"].ToString());
                }
                connection.Close();
            }
        }

        //método para extraer datos del datagridview 
        private int? idReserva()
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

        private void button1_Click(object sender, EventArgs e)
        {
            //se obtine la hora de apertura y cierre del negocio 
            TimeSpan horaApertura = new TimeSpan(8, 0, 0);
            TimeSpan horaCierre = new TimeSpan(23, 0, 0);
            //obtención de los datos mediantes los textbox 
            DateTime fecha = DateTime.Parse(textFecha.Text);
            TimeSpan horaInicio = TimeSpan.Parse(textHoraInicio.Text);
            TimeSpan horaFinal = TimeSpan.Parse(textHoraFinal.Text);
            //guardar los datos obtenidos de la base de datos en variables 
            int dpi = reserva.getDPIArbitro(comboBox1.Text, comboBox2.Text);
            int idJuego = reserva.getJuegosArbitroPorTorneo(fecha,horaInicio, horaFinal, dpi);
            int idReservaCliente = reserva.getJuegosArbitroReservaCliente(dpi, fecha, horaInicio, horaFinal);
            //validaciones de que se cumpla con todos los casos para poder alquilar una cancha
            if(idJuego >=1 || idReservaCliente >=1)
            {
                MessageBox.Show("El arbitro no esta disponible en esa fecha y hora");
            }
            else if (horaInicio < horaApertura || horaFinal < horaApertura)
            {
                MessageBox.Show("La hora de apertura de las canchas es 08:00 AM");
            }
            else if (horaFinal > horaCierre || horaInicio > horaCierre)
            {
                MessageBox.Show("La hora de cierre de las canchas es 11:00 PM");
            }
            else
            {
                //obtener datos y enviarlos a reservar la cancha 
                ra.idReservaCancha = Convert.ToInt32(idReserva());
                ra.DPI = dpi;
                ra.fecha = DateTime.Parse(textFecha.Text);
                ra.horaInicio = TimeSpan.Parse(textHoraInicio.Text);
                ra.horaFinal = TimeSpan.Parse(textHoraFinal.Text);
                ra.monto = decimal.Parse(textMonto.Text);
                reserva.addReservaArbitro(ra);
                cargarDatos();
                //limpiar los textbox 
                textFecha.Text = "";
                textHoraInicio.Text = "";
                textHoraFinal.Text = "";
                comboBox1.Text = "";
                comboBox1.Text = "";
                textMonto.Text = "";
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seleccionar los datos del combobox
            comboBox2.Items.Clear();
            nombreSeleccionado = comboBox1.Text;
            getApellidoArbitro(nombreSeleccionado);
            nombreSeleccionado = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modificarReservaArbitro m = new modificarReservaArbitro();
            m.Show();
        }
    }
}
