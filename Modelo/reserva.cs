using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class reserva
    {
        public int idReservaCancha { get; set; }
        public int idCancha { get; set; }
        public long DPI { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFinal { get; set; }
        public decimal costo { get; set; }
    }
}
