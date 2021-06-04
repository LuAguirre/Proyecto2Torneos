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
    public partial class Clientes : Form
    {
        //instanciar las clases 
        ClienteDB clienteDB = new ClienteDB();
        Cliente cliente = new Cliente();
        public Clientes()
        {
            InitializeComponent();
            cargarClientes();  
        }
        //Cargar datos de la base de datos en el datagridview 
        public void cargarClientes()
        {
            listadodeClientes.DataSource = clienteDB.getCliente();
        }

        private long? getDPI()
        {
            try
            {
                return long.Parse(
                    listadodeClientes.Rows[listadodeClientes.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            //obtener los datos y añadirlos a la base de datos 
            cliente.DPI = long.Parse(textDPI.Text);
            cliente.nombre = textNombre.Text;
            cliente.apellido = textApellido.Text;
            cliente.correo = textCorreo.Text;
            cliente.telefono = textTelefono.Text;
            clienteDB.addCliente(cliente);
            cargarClientes();
            textDPI.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textNombre.Text = "";
            textCorreo.Text = "";
            textTelefono.Text = "";

        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            //devolver a los textbox los datos seleccionados 
            long? dpi = getDPI();
            cliente = clienteDB.getClienteByDPI(dpi);
            textNombre.Text = cliente.nombre;
            textApellido.Text = cliente.apellido;
            textCorreo.Text = cliente.correo;
            textTelefono.Text = cliente.telefono;
            cargarClientes();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            //modificar datos 
            long? dpi = getDPI();
            string nombre = textNombre.Text;
            string apellido = textApellido.Text;
            string telefono = textTelefono.Text;
            string correo = textCorreo.Text;
            clienteDB.actualizarCliente(dpi, nombre, apellido, telefono, correo);
            cargarClientes();
            textDPI.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textNombre.Text = "";
            textCorreo.Text = "";
            textTelefono.Text = "";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            long? dpi = getDPI();
            clienteDB.deleteCliente(dpi);
            cargarClientes();
        }
    }
}
