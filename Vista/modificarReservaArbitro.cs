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
    public partial class modificarReservaArbitro : Form
    {
        reservaDB reserva = new reservaDB();
        reservaArbitro ra = new reservaArbitro();
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";
        public string nombreSeleccionado;
        public modificarReservaArbitro()
        {
            InitializeComponent();
            cargarDatos();
            getNombreArbitro();
        }

        //Cargar los datos de la base de datos 
        public void cargarDatos()
        {
            dataGridView1.DataSource = reserva.getReservasArbitro();
        }

        //metodo para obtener el nombre del arbitro 
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
        //método para obtener el apellido del arbitro 

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

        private int? buscar_idReserva()
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
            //regresar al textbox los datos seleccionados 
            int? idReserva = buscar_idReserva();

            reservaArbitro r = reserva.getReservaArbitroById(idReserva);

            textFecha.Text = Convert.ToString(r.fecha);
            textHoraInicio.Text = Convert.ToString(r.horaInicio);
            textFinal.Text = Convert.ToString(r.horaFinal);
            textMonto.Text = Convert.ToString(r.monto);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            nombreSeleccionado = comboBox1.Text;
            getApellidoArbitro(nombreSeleccionado);
            nombreSeleccionado = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan horaApertura = new TimeSpan(8, 0, 0);
            TimeSpan horaCierre = new TimeSpan(23, 0, 0);
            int idReserva = Convert.ToInt32(buscar_idReserva());
            int dpi = reserva.getDPIArbitro(comboBox1.Text, comboBox2.Text);
            DateTime fecha = DateTime.Parse(textFecha.Text);
            TimeSpan horaInicio = TimeSpan.Parse(textHoraInicio.Text);
            TimeSpan horaFinal = TimeSpan.Parse(textFinal.Text);
            decimal monto = decimal.Parse(textMonto.Text);

            int idJuego = reserva.getJuegosArbitroPorTorneo(fecha, horaInicio, horaFinal, dpi);
            int idReservaCliente = reserva.getJuegosArbitroReservaCliente(dpi, fecha, horaInicio, horaFinal);

            if (idJuego >= 1 || idReservaCliente >= 1)
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
                //realizar actualzación 
                reserva.updateReservaArbitro(idReserva, fecha, horaInicio, horaFinal, monto, dpi);
                cargarDatos();
                comboBox1.Text = "";
                comboBox2.Text = "";
                textFecha.Text = "";
                textHoraInicio.Text = "";
                textFinal.Text = "";
                textMonto.Text = "";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idReserva = Convert.ToInt32(buscar_idReserva());
            reserva.deleteReservaArbitro(idReserva);
            cargarDatos();
        }
    }
}
