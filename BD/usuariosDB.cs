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
    public class usuariosDB
    {
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";

        public void addUsuario(usuariosModelo usuario)
        {
            //query de insercion 
            string query = "exec insertarUsuario1 @rol, @nombre, @apellido, @usuario, @contraseña, @dpi, @telefono, @direccion, @correo, @statusUsuario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //valores del proceso almacenado 
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@rol", usuario.rol);
                sql.Parameters.AddWithValue("@nombre", usuario.nombre);
                sql.Parameters.AddWithValue("@apellido", usuario.apellido);
                sql.Parameters.AddWithValue("@usuario", usuario.usuario);
                sql.Parameters.AddWithValue("@contraseña", usuario.contraseña);
                sql.Parameters.AddWithValue("@dpi", usuario.dpi);
                sql.Parameters.AddWithValue("@telefono", usuario.telefono);
                sql.Parameters.AddWithValue("@direccion", usuario.direccion);
                sql.Parameters.AddWithValue("@correo", usuario.correo);
                sql.Parameters.AddWithValue("@statusUsuario", usuario.status);
                try
                {
                    //Abrir conexion 
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Usuario agregado correctamente!");
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el usuario a la base de datos" + ex.Message);
                }
            }
        }

        public List<usuariosModelo> getUsurio()
        {
            List<usuariosModelo> listaUsuarios = new List<usuariosModelo>();
            //query para obtner daos 
            string query = "exec obtenerUsuarios";
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
                        usuariosModelo usuario = new usuariosModelo();
                        usuario.idUsuario= reader.GetInt32(0);
                        usuario.rol = reader.GetString(1);
                        usuario.nombre = reader.GetString(2);
                        usuario.apellido = reader.GetString(3);
                        usuario.usuario = reader.GetString(4);
                        usuario.contraseña = reader.GetString(5);
                        usuario.dpi = reader.GetInt64(6);
                        usuario.telefono = reader.GetString(7);
                        usuario.direccion = reader.GetString(8);
                        usuario.correo = reader.GetString(9);
                        usuario.status = reader.GetString(10);
                        listaUsuarios.Add(usuario);
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
            return listaUsuarios;
        }

        public void actualizarUsuario(int? idUsuario, string nombre, string apellido, string usuario, string contraseña, string rol, long dpi, string telefono, string direccion, string correo, string status)
        {
            //query para actualizar datos 
            string query = "exec actualizarUsuarios @idUsuario, @rol, @nombre, @apellido, @usuario, @contraseña, @dpi, " +
                "@telefono, @direccion, @correo, @statusUsuario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //añadir valor a los procesos almacenados 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contraseña", contraseña);
                command.Parameters.AddWithValue("@rol", rol);
                command.Parameters.AddWithValue("@dpi", dpi);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@statusUsuario", status);

                try
                {
                    //abrir conexion
                    connection.Open();
                    command.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    MessageBox.Show("Datos del usuario actualizados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del usuario en la base de datos" + ex.Message);
                }
            }
        }

        

        public usuariosModelo getUsuarioById(int? idUsuario)
        {
            usuariosModelo usuario = new usuariosModelo();
            //query de obtención de datos mediante dpi
            string query = "exec obtenerUsuarioById @idUsuario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                //añadir valor al proceso almacenado
                sql.Parameters.AddWithValue("@idUsuario", idUsuario);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    //lectura de datos 
                    usuario.idUsuario = reader.GetInt32(0);
                    usuario.rol = reader.GetString(1);
                    usuario.nombre = reader.GetString(2);
                    usuario.apellido = reader.GetString(3);
                    usuario.usuario = reader.GetString(4);
                    usuario.contraseña = reader.GetString(5);
                    usuario.dpi = reader.GetInt64(6);
                    usuario.telefono = reader.GetString(7);
                    usuario.direccion = reader.GetString(8);
                    usuario.correo = reader.GetString(9);
                    usuario.status = reader.GetString(10);


                }
                //informar sobre algun problema
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el usurio solicitado. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return usuario;
        }

        public int getIdUsuario(string usuario, string contraseña)
        {
            string query = "exec obtenerIdUsuario @usuario, @contraseña";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@usuario", usuario);
                sql.Parameters.AddWithValue("@contraseña", contraseña);



                connection.Open();
                int idUsuario = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return idUsuario;


            }

        }


    }
}
