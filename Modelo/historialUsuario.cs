using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class historialUsuario
    {
        public string usuario { get; set; }

        public int idVisita { get; set; }
        public int idUsuario { get; set; }
        public DateTime fecha { get; set; }
        public string nombreModulo { get; set; }
        public TimeSpan hora { get; set; }
    }
}
