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
    public class reportesLourdesDB
    {
        private string connectionstring = "Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;";
        public List<historialUsuario> getHistorialPorFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            List<historialUsuario> historialUsuario = new List<historialUsuario>();
            //query para obtner daos 
            string query = "exec obtenerHistorialPorFecha @fechaInicio, @fechaFinal";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        historialUsuario historial = new historialUsuario();
                        historial.usuario = reader.GetString(0);
                        historial.idVisita = reader.GetInt32(1);
                        historial.idUsuario = reader.GetInt32(2);
                        historial.fecha = reader.GetDateTime(3);
                        historial.nombreModulo = reader.GetString(4);
                        historial.hora = reader.GetTimeSpan(5);
                        historialUsuario.Add(historial);
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
            return historialUsuario;
        }


        public List<historialUsuario> getHistorialPorUsuario(string usuario)
        {
            List<historialUsuario> historialUsuario = new List<historialUsuario>();
            //query para obtner daos 
            string query = "exec obtenerHistorialPorUsuario @usuario";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@usuario", usuario);
                
                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        historialUsuario historial = new historialUsuario();
                        historial.usuario = reader.GetString(0);
                        historial.idVisita = reader.GetInt32(1);
                        historial.idUsuario = reader.GetInt32(2);
                        historial.fecha = reader.GetDateTime(3);
                        historial.nombreModulo = reader.GetString(4);
                        historial.hora = reader.GetTimeSpan(5);
                        historialUsuario.Add(historial);
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
            return historialUsuario;
        }

        public List<gananciasCanchaModelo> getGananciaCancha(DateTime fechaInicial, DateTime fechaFin)
        {
            List<gananciasCanchaModelo> historialUsuario = new List<gananciasCanchaModelo>();
            //query para obtner daos 
            string query = "exec ingresosAlquilerCancha @fechaInicio, @fechaFinal";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicial);
                sql.Parameters.AddWithValue("@fechaFinal", fechaFin);

                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        gananciasCanchaModelo ganancia = new gananciasCanchaModelo();
                        ganancia.nombreCancha = reader.GetString(0);
                        ganancia.ganancia = reader.GetDecimal(1);
                        ganancia.fecha = reader.GetDateTime(2);
                        historialUsuario.Add(ganancia);
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
            return historialUsuario;
        }

        public List<gananciaArbitroModelo> getGananciaArbitro(DateTime fechaInicial, DateTime fechaFin)
        {
            List<gananciaArbitroModelo> historialUsuario = new List<gananciaArbitroModelo>();
            //query para obtner daos 
            string query = "exec ingresosPorAlquierArbitro @fechaInicio, @fechaFinal";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicial);
                sql.Parameters.AddWithValue("@fechaFinal", fechaFin);

                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        gananciaArbitroModelo ganancia = new gananciaArbitroModelo();
                        ganancia.nombre = reader.GetString(0);
                        ganancia.apellido = reader.GetString(1);
                        ganancia.ganancia = reader.GetDecimal(2);
                        ganancia.fecha = reader.GetDateTime(3);
                        historialUsuario.Add(ganancia);
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
            return historialUsuario;
        }

        public List<montoReserva> getTotalesReserva()
        {
            List<montoReserva> listaTotales = new List<montoReserva>();
            //query para obtner daos 
            string query = "exec totalesReserva";
            using (SqlConnection connection = new SqlConnection(connectionstring))
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
                        montoReserva monto = new montoReserva();
                        monto.idReserva = reader.GetInt32(0);
                        monto.nombre = reader.GetString(1);
                        monto.apellido = reader.GetString(2);
                        monto.total = reader.GetDecimal(3);
                        listaTotales.Add(monto);
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
            return listaTotales;
        }
    }
}
