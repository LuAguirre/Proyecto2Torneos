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
    public partial class MenuOperador : Form
    {
        HistorialModelo hm = new HistorialModelo();
        historialDB historial = new historialDB();

        public int idUsuarioL;
        public MenuOperador(int idUsuario)
        {
            InitializeComponent();
            idUsuarioL = idUsuario;
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

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void MenuOperador_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
    }
}
