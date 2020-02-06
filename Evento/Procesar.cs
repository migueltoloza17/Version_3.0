using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public class Procesar : ILeerArchivo
    {
        public string cRuta { get; set; }
        private readonly string cSeparador;
        private ILeerArchivo ILeerArchivo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_cRuta"></param>
        /// <param name="_cSeparador"></param>
        public  Procesar(string _cRuta, string _cSeparador, ILeerArchivo _ILeerArchivo)
        {
            this.cRuta = _cRuta;
            this.cSeparador = _cSeparador;
            this.ILeerArchivo = _ILeerArchivo;
        }

        /// <summary>
        /// Método que se encarga de obtener los archivos en base a una ruta
        /// </summary>
        /// <returns></returns>
        public string[] ObtenerArchivo(string _cRuta)
        {
            return this.ILeerArchivo.ObtenerArchivo(_cRuta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entEvento"></param>
        /// <returns></returns>
        public List<EventoFecha> ObtenerEventos()
        {
            string[] aRegistros;
            List<EventoFecha> lstEventosFecha = new List<EventoFecha>();
            aRegistros = this.ObtenerArchivo(this.cRuta); 

            foreach (string item in aRegistros)
            {
                ValidarRegistro(item);
                AgregarRegistro(lstEventosFecha, item);
            }
            return lstEventosFecha;
        }        

        /// <summary>
        /// Método que se encarga de validar si el registro contiene la cadena 
        /// para separa el evento y fecha
        /// </summary>
        /// <param name="_cRegistro">Registro a validar(cadena)</param>
        private void ValidarRegistro(string _cRegistro)
        {
            if (!_cRegistro.Contains(cSeparador))
                throw new Exception("No se cuenta con el formato correcto");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_lstEventosFecha"></param>
        /// <param name="_item"></param>
        private void AgregarRegistro(List<EventoFecha> _lstEventosFecha, string _item)
        {
            string[] aCampos = ObtenerCampos(_item);
            EventoFecha entEvento = new EventoFecha();
            ObtenerRegistro(entEvento, aCampos);
            _lstEventosFecha.Add(entEvento);
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        private string[] ObtenerCampos(string _item)
        {
            return _item.Split(cSeparador[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entEvento"></param>
        /// <param name="_aCampos"></param>
        private void ObtenerRegistro(EventoFecha _entEvento, string[] _aCampos)
        {
            _entEvento.cEvento = _aCampos[0];
            _entEvento.dtFechaEvento = DateTime.Parse(_aCampos[1]);
        }       
    }
}
