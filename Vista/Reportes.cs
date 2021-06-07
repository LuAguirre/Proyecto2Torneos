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
    public partial class Reportes : Form
    {
        historialDB historial = new historialDB();
        HistorialModelo hm = new HistorialModelo();
        public int idUsuarioL;
        public DateTime fechaHora = DateTime.Now;
        public Reportes(int idUsuario)
        {
            InitializeComponent();
            idUsuarioL = idUsuario;
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            //obtención de datos para el historial 
            string nombreModulo = "Tabla Posiciones";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);

            tablapos ts = new tablapos();
            ts.Show();
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            //obtención de datos para el historial 
            string nombreModulo = "Tarjetas por equipo";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
            Tarjetas tt = new Tarjetas();
            tt.Show();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            //obtención de datos para el historial 
            ReporteCanchas reporteCanchas = new ReporteCanchas();
            reporteCanchas.Show();
            string nombreModulo = "Estadística uso de cancha";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            //obtención de datos para el historial 
            string nombreModulo = "Planilla árbitro";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
            ReportePlanillaArbitro reportePlanillaArbitro = new ReportePlanillaArbitro();
            reportePlanillaArbitro.Show();
        }

        private void Reportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            //obtención de datos para el historial 
            string nombreModulo = "Estadísticas del equipo";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
            ReporteEstadisticasEquipo reporteEstadisticasEquipo = new ReporteEstadisticasEquipo();
            reporteEstadisticasEquipo.Show();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            HistorialUsuarios historial1 = new HistorialUsuarios();
            historial1.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Historial Usuarios";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);

        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            IngresosAlquilerCancha cancha = new IngresosAlquilerCancha();
            cancha.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Ingresos alquiler de cancha";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            IngresosPorAlquilerArbitro arbitro = new IngresosPorAlquilerArbitro();
            arbitro.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Ingresos alquiler por arbitro";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisponibilidadCancha disponibilidad = new DisponibilidadCancha();
            disponibilidad.Show();
            //obtención de datos para el historial 
            string nombreModulo = "Disponibilidad Cancha";
            var hora = DateTime.Now.TimeOfDay.ToString();
            hm.idUsuario = idUsuarioL;
            hm.fecha = fechaHora;
            hm.nombreModulo = nombreModulo;
            hm.hora = TimeSpan.Parse(hora);
            historial.addHistorial(hm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewListEquipos l = new ViewListEquipos();
            l.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reporte_Arbitrosss a = new Reporte_Arbitrosss();
            a.Show();
        }
    }
}
