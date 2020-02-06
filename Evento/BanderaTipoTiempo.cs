using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public class BanderaTipoTiempo
    {
        public enum TipoTiempo
        {
            Mes = 1,
            Dia = 2,
            Hora = 3,
            Minuto = 4
        }

        public enum TiempoValor
        {
            Mes = 1,
            Dia = 1,
            Hora = 24
        }

    }
}
