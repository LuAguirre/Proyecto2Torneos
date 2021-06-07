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
    public partial class ViewListEquipos : Form
    {
        public string query = "select * from EQUIPO";
        public ViewListEquipos()
        {
            InitializeComponent();
            GetIngresos(query);
        }

        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";


        private void GetIngresos(string query)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //Adaptador para almacenar consulta

                    SqlDataAdapter sqll = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    //Cargar tabla con la informacion de la consulta
                    sqll.Fill(data);
                    //Cargar datos en lista
                    listEquipos.DataSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo realizar la consulta");
                }
            }
        }

        private void ViewListEquipos_Load(object sender, EventArgs e)
        {

        }
    }
}
