using Administracion_Torneos.BD;
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
    public partial class HistorialUsuarios : Form
    {
        //invocación de la clase reportes 
        reportesLourdesDB reportes = new reportesLourdesDB();
        //ruta de conexión a base de datos 
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";

        public HistorialUsuarios()
        {
            InitializeComponent();
            //Cargar los nombres de usuarios 
            getUsuarios();
            //marcar como no visibles los parametros de busqueda 
            comboBox1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
        }

        private void HistorialUsuarios_Load(object sender, EventArgs e)
        {

        }
        //método para obtener los usuarios del sistema 
        private void getUsuarios()
        {

            string query = "exec obtenerUsuariosDeSistema";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["usuario"].ToString());
                }
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //activar el radiobutton 
            if (radioButton1.Checked == true)
            {
                //mostrar los datos ocultos 
                DateTime fechaInicio = dateTimePicker1.Value;
                DateTime fechaFinal = dateTimePicker2.Value;
                //mostrar los datos de la base de datos por medio del datagridview 
                dataGridView1.DataSource = reportes.getHistorialPorFecha(fechaInicio, fechaFinal);
            }
            else if(radioButton2.Checked == true)
            {
                string usuario = comboBox1.Text;
                //mostrar los datos de la base de datos por medio del datagridview 
                dataGridView1.DataSource = reportes.getHistorialPorUsuario(usuario);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;
            //mostrar los componentes ocultos al activar el radiobutton 
            if(rd.Checked == true)
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;
            //mostrar los componentes ocultos al activar el radiobutton 
            if (rd.Checked == true)
            {
                comboBox1.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;
            }

        }
    }
}
