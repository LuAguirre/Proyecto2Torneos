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
    public partial class VistaUsuarios : Form
    {
        usuariosModelo usuario = new usuariosModelo();
        usuariosDB usuariosDB = new usuariosDB();
        public VistaUsuarios()
        {
            InitializeComponent();
            cargarDatos();
        }
        public void cargarDatos()
        {
            dataGridView1.DataSource = usuariosDB.getUsurio();
        }

        private int? getIdUsuario()
        {
            try
            {
                return int.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            usuario.rol = comboBoxRol.Text;
            usuario.nombre = textNombre.Text;
            usuario.apellido = textApellido.Text;
            usuario.usuario = textUsuario.Text;
            usuario.contraseña = textContraseña.Text;
            usuario.dpi = Convert.ToInt64(textDPI.Text);
            usuario.telefono = textTelefono.Text;
            usuario.direccion = textDireccion.Text;
            usuario.correo = textCorreo.Text;
            usuario.status = comboBox1.Text;
            usuariosDB.addUsuario(usuario);
            cargarDatos();
            comboBoxRol.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textUsuario.Text = "";
            textContraseña.Text = "";
            textDPI.Text = "";
            textDireccion.Text = "";
            textCorreo.Text = "";
            textTelefono.Text = "";
            comboBox1.Text = "";

        }

        private void VistaUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            int? idUsuario = getIdUsuario();

            usuario = usuariosDB.getUsuarioById(idUsuario);
            textNombre.Text = usuario.nombre;
            textApellido.Text = usuario.apellido;
            textUsuario.Text = usuario.usuario;
            textContraseña.Text = usuario.contraseña;
            comboBoxRol.Text = usuario.rol;
            textDPI.Text = Convert.ToString(usuario.dpi);
            textTelefono.Text = usuario.telefono;
            textDireccion.Text = usuario.direccion;
            textCorreo.Text = usuario.correo;
            comboBox1.Text = usuario.status;

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            int? idUsuario = getIdUsuario();
            string nombre = textNombre.Text;
            string apellido = textApellido.Text;
            string usuario = textUsuario.Text;
            string contraseña = textContraseña.Text;
            string rol = comboBoxRol.Text;
            long dpi = long.Parse(textDPI.Text);
            string telefono = textTelefono.Text;
            string direccion = textDireccion.Text;
            string correo = textCorreo.Text;
            string status = comboBox1.Text;
            usuariosDB.actualizarUsuario(idUsuario, nombre, apellido, usuario, contraseña,rol, dpi, telefono, direccion, correo, status);
            cargarDatos();
            comboBoxRol.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textUsuario.Text = "";
            textContraseña.Text = "";
            textDPI.Text = "";
            textTelefono.Text = "";
            textDireccion.Text = "";
            textCorreo.Text = "";
            comboBox1.Text = "";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void VistaUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
