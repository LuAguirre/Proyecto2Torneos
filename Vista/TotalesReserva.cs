﻿using Administracion_Torneos.BD;
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
    public partial class TotalesReserva : Form
    {
        public TotalesReserva()
        {
            InitializeComponent();
            dataGridView1.DataSource = reportes.getTotalesReserva();
        }

        reportesLourdesDB reportes = new reportesLourdesDB();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
