using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Vista
{
    public partial class MenucontrolAdministrador : Form
    {
        public int idUsuarioL;
        public int id;
        historialDB historial = new historialDB();
        HistorialModelo hm = new HistorialModelo();
        public MenucontrolAdministrador(int idUsuario)
        {
            InitializeComponent(); 
            //obtención de datos para el historial 
            idUsuarioL = idUsuario;
            string nombreModulo = "Menu Administrador";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);

        }
        

        public DateTime fechaHora = DateTime.Now;
       

        private void btnTorneo_Click(object sender, EventArgs e)
        {
            
            TorneoCRUD t = new TorneoCRUD();
            t.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Torneo";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);

        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            
            ViewEquipo vq = new ViewEquipo();
            vq.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Equipo";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            
            ViewEntrenador ve = new ViewEntrenador();
            ve.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Entrenador";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnArbitros_Click(object sender, EventArgs e)
        {
            
            VistaArbitro vA = new VistaArbitro(idUsuarioL);
            vA.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Arbitros";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnAmonestaciones_Click(object sender, EventArgs e)
        {
            
            Amonestacion ar = new Amonestacion();
            ar.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Amonestaciones";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnPagoAmonestaciones_Click(object sender, EventArgs e)
        {
            
            ViewPagoAmonestacion viewPagoAmonestacion = new ViewPagoAmonestacion();
            viewPagoAmonestacion.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Pago Amonestaciones";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            
            jugadorescrud jrs = new jugadorescrud();
            jrs.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Jugadores";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            
            Canchas c = new Canchas();
            c.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Canchas";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
           
            Reportes reportes = new Reportes(idUsuarioL);
            reportes.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Reportes";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Clientes";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReservaCanchas reserva = new ReservaCanchas();
            reserva.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Reserva Canchas";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void buttonUsuarios_Click(object sender, EventArgs e)
        {
            VistaUsuarios usuarios = new VistaUsuarios();
            usuarios.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Usuarios";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void MenucontrolAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void MenucontrolAdministrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
    }
}
