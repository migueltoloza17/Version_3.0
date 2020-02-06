using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public interface IProcesarFechaTipo
    {
        int iTipovalor { get; set; }
        int iTipoTiempo { get; set; }
        string cTipoEvento { get; set; }       
    }
}
