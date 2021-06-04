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
    public class reservaDB
    {
        private string connectionString = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";


        public int getNumeroCancha(string nombreCancha)
        {
            string query = "exec obtenerIdCancha @nombre  ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre", nombreCancha);
                


                connection.Open();
                int numeroCancha = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return numeroCancha;


            }

        }

        


        public long getDPICliente(string nombre, string apellido)
        {
            string query = "exec obtenerDPICliente @nombre, @apellido";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre", nombre);
                sql.Parameters.AddWithValue("@apellido", apellido);



                connection.Open();
                long DPI = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return DPI;


            }

        }

        public int getIdJuegoReservado(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinal, int idCancha)
        {
            string query = "exec obtenerJuegoReservado2 @fecha, @horaInicio, @horaFinal, @idCancha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fecha", fecha);
                sql.Parameters.AddWithValue("@horaInicio", horaInicio);
                sql.Parameters.AddWithValue("@horaFinal", horaFinal);
                sql.Parameters.AddWithValue("@idCancha", idCancha);



                connection.Open();
                int idJuego = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return idJuego;


            }

        }

        public int getIdJuegoReservadoPorCliente(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinal, int idCancha)
        {
            string query = "exec reservaCanchaPorCliente @fecha, @horaInicio, @horaFinal, @idCancha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fecha", fecha);
                sql.Parameters.AddWithValue("@horaInicio", horaInicio);
                sql.Parameters.AddWithValue("@horaFinal", horaFinal);
                sql.Parameters.AddWithValue("@idCancha", idCancha);



                connection.Open();
                int idJuego = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return idJuego;


            }

        }

        public void addReservaCancha(reservaModelo reserva)
        {
            //query de insercion 
            string query = "exec crearReservacion @idCancha, @DPI, @fecha, @horaInicio, @horaFinal, @montoo ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //valores del proceso almacenado 
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@idCancha", reserva.idCancha);
                sql.Parameters.AddWithValue("@DPI", reserva.DPI);
                sql.Parameters.AddWithValue("@fecha", reserva.fecha);
                sql.Parameters.AddWithValue("@horaInicio", reserva.horaInicio);
                sql.Parameters.AddWithValue("@horaFinal", reserva.horaFinal);
                sql.Parameters.AddWithValue("@montoo", reserva.costo);

                try
                {
                    //Abrir conexion 
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Cancha reservada correctamente!");
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al reservar una cancha" + ex.Message);
                }
            }
        }

        public List<reservaModelo> getReservas()
        {
            List<reservaModelo> listaDeReservaciones = new List<reservaModelo>();
            //query para obtner daos 
            string query = "select * from reservaCancha";
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
                        reservaModelo reserva = new reservaModelo();
                        reserva.idReservaCancha = reader.GetInt32(0);
                        reserva.idCancha = reader.GetInt32(1);
                        reserva.DPI = reader.GetInt64(2);
                        reserva.fecha = reader.GetDateTime(3);
                        reserva.horaInicio = reader.GetTimeSpan(4);
                        reserva.horaFinal = reader.GetTimeSpan(5);
                        reserva.costo = reader.GetDecimal(6);
                        listaDeReservaciones.Add(reserva);
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
            return listaDeReservaciones;
        }

        public List<modeloReservaTorneo> getReservasPorTorneo()
        {
            List<modeloReservaTorneo> listaDeReservaciones = new List<modeloReservaTorneo>();
            //query para obtner daos 
            string query = "exec verReservacionesPorTorneo  ";
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
                        modeloReservaTorneo reserva = new modeloReservaTorneo();
                        reserva.idCancha = reader.GetInt32(0);
                        reserva.idJuego = reader.GetInt32(1);
                        reserva.fecha = reader.GetDateTime(2);
                        reserva.horaInicio = reader.GetTimeSpan(3);
                        reserva.horaFinal = reader.GetTimeSpan(4);
                        listaDeReservaciones.Add(reserva);
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
            return listaDeReservaciones;
        }

         
        public reservaModelo getReservaById(int? id)
        {
            reservaModelo reserva = new reservaModelo();
            //query de obtención de datos mediante dpi
            string query = "exec buscarReservaPorId @idReserva";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                //añadir valor al proceso almacenado
                sql.Parameters.AddWithValue("@idReserva", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    //lectura de datos 
                    reserva.idReservaCancha = reader.GetInt32(0);
                    reserva.idCancha = reader.GetInt32(1);
                    reserva.DPI = reader.GetInt64(2);
                    reserva.fecha = reader.GetDateTime(3);
                    reserva.horaInicio = reader.GetTimeSpan(4);
                    reserva.horaFinal = reader.GetTimeSpan(5);
                    reserva.costo = reader.GetDecimal(6);
                }
                //informar sobre algun problema
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el entrenador solicitado. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return reserva;
        }

        public void deleteReserva(int? idReserva)
        {
            //query de eliminacion para la base de datos 
            string query = "exec eliminarReserva @idReserva";
            //crear la coneccion para la base de datos 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                //enviar y valor valor del parametro mediante el valor del proceso almacenado
                command.Parameters.AddWithValue("@idReserva", idReserva);
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
                    MessageBox.Show("Error al eliminar el entrenador en la base de datos" + ex.Message);
                }
            }
        }

        public void updateReserva(int? idReserva, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinal, decimal costo)
        {
            //query para actualizar datos 
            string query = "exec actualizarReserva @idReserva, @fecha, @horaInicio, @horaFinal, @costo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //añadir valor a los procesos almacenados 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReserva", idReserva);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@horaInicio", horaInicio);
                command.Parameters.AddWithValue("@horaFinal", horaFinal);
                command.Parameters.AddWithValue("@costo", costo);
                
                try
                {
                    //abrir conexion
                    connection.Open();
                    command.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    MessageBox.Show("Datos de la reserva actualizados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos de la reserva" + ex.Message);
                }
            }
        }

        public int getDPIArbitro(string nombre, string apellido)
        {
            string query = "exec obtenerDPIArbitro @nombre, @apellido";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre", nombre);
                sql.Parameters.AddWithValue("@apellido", apellido);



                connection.Open();
                int DPI = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return DPI;


            }

        }

        public int getJuegosArbitroPorTorneo(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinal, int dpi)
        {
            string query = "exec obetenerHorariosArbitrosPorTorneos @fecha, @horaInicio, @horaFinal, @DPIArbitro";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fecha", fecha);
                sql.Parameters.AddWithValue("@horaInicio", horaInicio);
                sql.Parameters.AddWithValue("@horaFinal", horaFinal);
                sql.Parameters.AddWithValue("@DPIArbitro", dpi);



                connection.Open();
                int numeroCancha = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return numeroCancha;


            }

        }

        public int getJuegosArbitroReservaCliente(int dpiArbitro ,DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinal)
        {
            string query = "exec obtenerReservacionesArbitroPorCliente @dpiArbitro, @fecha, @horaInicio, @horaFinal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@dpiArbitro", dpiArbitro);
                sql.Parameters.AddWithValue("@fecha", fecha);
                sql.Parameters.AddWithValue("@horaInicio", horaInicio);
                sql.Parameters.AddWithValue("@horaFinal", horaFinal);
                



                connection.Open();
                int reservaArbitro = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return reservaArbitro;


            }

        }


        public void addReservaArbitro(reservaArbitro reserva)
        {
            //query de insercion 
            string query = "exec crearReservaArbitro @idReservaCancha, @dpiArbitro, @fecha, @horaInicio, @horaFinal, @monto";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //valores del proceso almacenado 
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@idReservaCancha", reserva.idReservaCancha);
                sql.Parameters.AddWithValue("@dpiArbitro", reserva.DPI);
                sql.Parameters.AddWithValue("@fecha", reserva.fecha);
                sql.Parameters.AddWithValue("@horaInicio", reserva.horaInicio);
                sql.Parameters.AddWithValue("@horaFinal", reserva.horaFinal);
                sql.Parameters.AddWithValue("@monto", reserva.monto);

                try
                {
                    //Abrir conexion 
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Arbitro reservado correctamente!");
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al reservar un arbitro" + ex.Message);
                }
            }
        }

        public List<reservaArbitro> getReservasArbitro()
        {
            List<reservaArbitro> listaDeReservaciones = new List<reservaArbitro>();
            //query para obtner daos 
            string query = "exec obtenerReservasArbitro ";
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
                        reservaArbitro reserva = new reservaArbitro();
                        reserva.idReserva = reader.GetInt32(0);
                        reserva.idReservaCancha = reader.GetInt32(1);
                        reserva.DPI = reader.GetInt32(2);
                        reserva.fecha = reader.GetDateTime(3);
                        reserva.horaInicio = reader.GetTimeSpan(4);
                        reserva.horaFinal = reader.GetTimeSpan(5);
                        reserva.monto = reader.GetDecimal(6);
                        listaDeReservaciones.Add(reserva);
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
            return listaDeReservaciones;
        }

        public reservaArbitro getReservaArbitroById(int? id)
        {
            reservaArbitro reserva = new reservaArbitro();
            //query de obtención de datos mediante dpi
            string query = "exec obtenerReservaArbitroPorID @idReserva";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                //añadir valor al proceso almacenado
                sql.Parameters.AddWithValue("@idReserva", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    //lectura de datos 
                    reserva.idReserva = reader.GetInt32(0);
                    reserva.idReservaCancha = reader.GetInt32(1);
                    reserva.DPI = reader.GetInt32(2);
                    reserva.fecha = reader.GetDateTime(3);
                    reserva.horaInicio = reader.GetTimeSpan(4);
                    reserva.horaFinal = reader.GetTimeSpan(5);
                    reserva.monto = reader.GetDecimal(6);
                }
                //informar sobre algun problema
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el entrenador solicitado. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return reserva;
        }

        public void updateReservaArbitro(int? idReserva, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinal, decimal costo, int dpiArbitro)
        {
            //query para actualizar datos 
            string query = "exec actualizarReservaArbitro @idReserva, @dpiArbitro, @fecha, @horaInicio, @horaFinal, @monto";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //añadir valor a los procesos almacenados 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReserva", idReserva);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@horaInicio", horaInicio);
                command.Parameters.AddWithValue("@horaFinal", horaFinal);
                command.Parameters.AddWithValue("@monto", costo);
                command.Parameters.AddWithValue("@dpiArbitro", dpiArbitro);

                try
                {
                    //abrir conexion
                    connection.Open();
                    command.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    MessageBox.Show("Datos de la reserva actualizados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos de la reserva" + ex.Message);
                }
            }
        }

        public void deleteReservaArbitro(int? idReserva)
        {
            //query de eliminacion para la base de datos 
            string query = "exec eliminarReservaArbitro @idReserva";
            //crear la coneccion para la base de datos 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                //enviar y valor valor del parametro mediante el valor del proceso almacenado
                command.Parameters.AddWithValue("@idReserva", idReserva);
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
                    MessageBox.Show("Error al eliminar el entrenador en la base de datos" + ex.Message);
                }
            }
        }


    }
}
