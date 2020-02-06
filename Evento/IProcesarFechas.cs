using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public interface IProcesarFechas
    {
        int Meses { get; set; }
        int Dias { get; set; }
        int Horas { get; set; }
        int Minutos { get; set; }

        void RecorrerListaEventos();
    }
}
