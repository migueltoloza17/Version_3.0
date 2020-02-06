using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] aCadenasObjeto;
            List<EventoFecha> lstEventoFecha = new List<EventoFecha>();
            List<IProcesarFechaTipo> lstIvalidarFechas = new List<IProcesarFechaTipo>();
            ILeerArchivo ILeerArchivo = new LeerArchivo();
            IProcesarFechaTipo IProcesar = new ArmarCadena();
            IProcesarCadena IProcesarCadena = new ArmarCadena();
           
            Procesar procesar = new Procesar(@"D:\CURSOS\Dias_Fechas.txt", ",", ILeerArchivo);

            lstEventoFecha = procesar.ObtenerEventos();
            ProcesarFechas validar = new ProcesarFechas(lstEventoFecha, lstIvalidarFechas, IProcesar);
            IProcesarFechas lValidarFecha = validar;
            lValidarFecha.RecorrerListaEventos();

            aCadenasObjeto = IProcesarCadena.ObtenerCadenaMensaje(lstIvalidarFechas);
            Imprimir imp = new Imprimir(aCadenasObjeto);
            imp.ImprimirCadena();
            
        }
    }
}
