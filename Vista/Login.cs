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
    public partial class Login : Form
    {
        public bool botonPresionado;
        public Login()
        {
            InitializeComponent();
             botonPresionado = false;

    }

        SqlConnection connection = new SqlConnection(@"Server=DESKTOP-UVJPA4R;Database=Proyecto_AdministracionTorneosFutbol;Trusted_Connection=True;");
        usuariosDB usuarios = new usuariosDB();
        historialDB historial = new historialDB();
        HistorialModelo hm = new HistorialModelo();

        public void login(string usuario, string contraseña)
        {
            try
            {
                //enviar el usuario y contraseña para el login 
                connection.Open();
                SqlCommand cmd = new SqlCommand("exec obtenerLogin1 @usuario, @contraseña", connection);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count == 1)
                {
                    this.Hide();
                    if(dt.Rows[0][2].ToString() == "Inactivo")
                    {
                        MessageBox.Show("El usuario se encuentra inactivo");
                    }
                    //si se encuentra el rol administrador se da acceso al menu principal 
                   else if(dt.Rows[0][1].ToString() == "Administrador")
                    {
                        string idUsuario = dt.Rows[0][0].ToString();
                        
                        this.Hide();
                        //se envia el id del usuario para poder guardar los datos del historial 
                        MenucontrolAdministrador menu = new MenucontrolAdministrador( Convert.ToInt32(idUsuario));
                        menu.Show();
                    }
                    //si el rol encontrado es el de operador se da acceso al menu de operador 
                    else if(dt.Rows[0][1].ToString() == "Operador")
                    {
                        string idUsuario = dt.Rows[0][0].ToString();
                        this.Hide();
                        //se envia el id del usuario para poder guardar los datos del historial
                        MenuOperador menu = new MenuOperador(Convert.ToInt32(idUsuario));
                        menu.Show();
                        
                    }
                    //si el rol encontrado es reportes se da acceso solo a reportes 
                    
                    else if(dt.Rows[0][1].ToString() == "Reportes ")
                    {
                        string idUsuario = dt.Rows[0][0].ToString();
                        this.Hide();
                        //se envia el id del usuario para poder guardar los datos del historial
                        Reportes reportes = new Reportes(Convert.ToInt32(idUsuario));
                        reportes.Show();
                    }
                    
                }
                else
                {
                    //se informa si hay problemas con el usuario y contraseña 
                    MessageBox.Show("Usuario y/o contraseña incorrectos");
                }
            }
            catch (Exception e)
            {
                //o se informa de algún error
                MessageBox.Show("error" + e);
            }
            finally
            {
                connection.Close();
            }
        }

        

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //asignar nombre al modulo para guardar en el historial 
            string nombreModulo = "Login";
            //obtener la fecha y hora actual del sistema 
            var fecha = DateTime.Now.Date.ToString();
            var hora = DateTime.Now.TimeOfDay.ToString();
            //enviar el usuario y contraseña para dar acceseo 
            login(textBoxUsuario.Text, textBoxContraseña.Text);
            botonPresionado = true;
            if(botonPresionado == true)
            {
             int idUsuario =  usuarios.getIdUsuario(textBoxUsuario.Text, textBoxContraseña.Text);
                //guardar datos en el modelo para guardar el historial 
                hm.idUsuario = idUsuario;
                hm.fecha = DateTime.Parse(fecha);
                hm.nombreModulo = nombreModulo;
                hm.hora = TimeSpan.Parse(hora);
                historial.addHistorial(hm);

            }
        }
    }
}
