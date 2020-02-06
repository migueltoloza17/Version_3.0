using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public interface ILeerArchivo
    {
        string cRuta { get; set; }
        string[] ObtenerArchivo(string cRuta);
    }
}
