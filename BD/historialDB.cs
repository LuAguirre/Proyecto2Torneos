using Administracion_Torneos.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.BD
{
    public class historialDB
    {
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";

        public void addHistorial(HistorialModelo historial)
        {
            //query de insercion 
            string query = "exec insertarVisitaHistorial1 @idUsuario, @fechahora, @nombreModulo, @hora";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //valores del proceso almacenado 
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@idUsuario", historial.idUsuario);
                sql.Parameters.AddWithValue("@fechahora", historial.fecha);
                sql.Parameters.AddWithValue("@nombreModulo", historial.nombreModulo);
                sql.Parameters.AddWithValue("@hora", historial.hora);
                

                try
                {
                    //Abrir conexion 
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                   
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el historial" + ex.Message);
                }
            }
        }


    }
}
