using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Evento.Tests
{
    [TestClass()]
    public class ProcesarFechasUTests
    {
        [TestMethod()]
        public void ProcesarFechas_TieneUnRegistro_ListaUnEvento()
        {
            var DOCIProcesarFechas = new Mock<IProcesarFechas>();
            List<EventoFecha> lstEvento = new List<EventoFecha>();
            List<IProcesarFechaTipo> lst = new List<IProcesarFechaTipo>();
            var DOCILeerArchivo = new Mock<IProcesarFechaTipo>();

            lstEvento.Add(new EventoFecha { cEvento = "evento 1", dtFechaEvento = DateTime.Now });
            lstEvento.Add(new EventoFecha { cEvento = "evento 2", dtFechaEvento = DateTime.Now });

            var SUT = new ProcesarFechas(lstEvento, lst, DOCILeerArchivo.Object);

            SUT.RecorrerListaEventos();

            Assert.AreEqual(2, lst.Count);
        }


        [TestMethod()]//SPIE
        public void ProcesarFechas_InvocaDependencia_UnaVez()
        {
            //arrange
            var DOCIProcesarFechas = new Mock<IProcesarFechas>();
            List<EventoFecha> lstEvento = new List<EventoFecha>();
            List<IProcesarFechaTipo> lst = new List<IProcesarFechaTipo>();
            lstEvento.Add(new EventoFecha { cEvento = "evento 1", dtFechaEvento = DateTime.Now });
            var DOCILeerArchivo = new Mock<IProcesarFechaTipo>();
            //act
            var SUT = new ProcesarFechas(lstEvento, lst, DOCILeerArchivo.Object);
            //assert
            DOCIProcesarFechas.Verify(a => a.RecorrerListaEventos(), Times.AtMostOnce);
        }


        [TestMethod()]
        public void ProcesarFechas_RegistroCorrecto_EventoAsignado()
        {
            var DOCIProcesarFechas = new Mock<IProcesarFechas>();
            List<EventoFecha> lstEvento = new List<EventoFecha>();
            List<IProcesarFechaTipo> lst = new List<IProcesarFechaTipo>();
            var DOCILeerArchivo = new Mock<IProcesarFechaTipo>();

            lstEvento.Add(new EventoFecha { cEvento = "evento 1", dtFechaEvento = DateTime.Now });
            lstEvento.Add(new EventoFecha { cEvento = "evento 2", dtFechaEvento = DateTime.Now });

            var SUT = new ProcesarFechas(lstEvento, lst, DOCILeerArchivo.Object);

            SUT.RecorrerListaEventos();

            Assert.AreEqual("evento 1", lst[0].cTipoEvento);
        }
    }
}