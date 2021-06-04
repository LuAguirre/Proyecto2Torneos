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
    public class ClienteDB
    {
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";

        public void addCliente(Cliente cliente)
        {
            //query de insercion 
            string query = "exec agregarCliente @DPI, @nombre, @apellido, @telefono, @correo ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //valores del proceso almacenado 
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", cliente.DPI);
                sql.Parameters.AddWithValue("@nombre", cliente.nombre);
                sql.Parameters.AddWithValue("@apellido", cliente.apellido);
                sql.Parameters.AddWithValue("@telefono", cliente.telefono);
                sql.Parameters.AddWithValue("@correo", cliente.correo);
                try
                {
                    //Abrir conexion 
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Cliente agregado correctamente!");
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el cliente a la base de datos" + ex.Message);
                }
            }
        }

        public List<Cliente> getCliente()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            //query para obtner daos 
            string query = "exec obtenerClientes ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        Cliente cliente = new Cliente();
                        cliente.DPI = reader.GetInt64(0);
                        cliente.nombre = reader.GetString(1);
                        cliente.apellido = reader.GetString(2);
                        cliente.telefono = reader.GetString(3);
                        cliente.correo = reader.GetString(4);
                        listaClientes.Add(cliente);
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
            return listaClientes;
        }

        public void actualizarCliente(long? DPI, string nombre, string apellido, string telefono, string correo)
        {
            //query para actualizar datos 
            string query = "exec actualizarCliente @DPI, @nombre, @apellido, @telefono, @correo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //añadir valor a los procesos almacenados 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DPI", DPI);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@correo", correo);
               

                try
                {
                    //abrir conexion
                    connection.Open();
                    command.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    MessageBox.Show("Datos del cliente actualizados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del cliente en la base de datos" + ex.Message);
                }
            }
        }

        public void deleteCliente(long? DPI)
        {
            //query de eliminacion para la base de datos 
            string query = "exec eliminarCliente @DPI";
            //crear la coneccion para la base de datos 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                //enviar y valor valor del parametro mediante el valor del proceso almacenado
                command.Parameters.AddWithValue("@DPI", DPI);
                try
                {
                    //abrir conexion a la base de datos 
                    connection.Open();
                    command.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    //notificar al usuario 
                    MessageBox.Show("Registro eliminado correctamente");
                }
                //caso contrario 
                catch (Exception ex)
                {
                    MessageBox.Show("El usaurio no se puede eliminar ya que cuenta con una reservación de cancha hecha, elimine primero la reservación");
                }
            }
        }

        public Cliente getClienteByDPI(long? dpi)
        {
            Cliente cliente = new Cliente();
            //query de obtención de datos mediante dpi
            string query = "exec obtenerClientePorDPI @DPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                //añadir valor al proceso almacenado
                sql.Parameters.AddWithValue("@DPI", dpi);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    //lectura de datos 
                    cliente.DPI = reader.GetInt64(0);
                    cliente.nombre = reader.GetString(1);
                    cliente.apellido = reader.GetString(2);
                    cliente.telefono = reader.GetString(3);
                    cliente.correo = reader.GetString(4);
                    
                }
                //informar sobre algun problema
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el cliente solicitado. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return cliente;
        }


    }
}
