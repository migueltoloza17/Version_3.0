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
    public class ProcesarTests
    {
        [TestMethod()]
        public void Procesar_ArvhivoTieneUnRegistro_ListaUnEvento()
        {
            var DOCILeerArchivo = new Mock<ILeerArchivo>();
            string[] aCadena = new string[] { "evento1,04/02/2020", "evento1,05/02/2020" };
            DOCILeerArchivo.Setup(doc => doc.ObtenerArchivo(It.IsAny<string>())).Returns(aCadena);

            var SUT = new Procesar("test", ",", DOCILeerArchivo.Object);

            List<EventoFecha> lstEventoFecha = SUT.ObtenerEventos();

            Assert.AreEqual(2, lstEventoFecha.Count);
        }

        [TestMethod()]//SPIE
        public void Procesar_InvocaDependencia_UnaVez()
        {
            //arrange
            var DOCILeerArchivo = new Mock<ILeerArchivo>();
            string[] aCadena = new string[] { "evento1,04/02/2020" };
            DOCILeerArchivo.Setup(doc => doc.ObtenerArchivo(It.IsAny<string>())).Returns(aCadena);
            var SUT = new Procesar("test", ",", DOCILeerArchivo.Object);

            //act
            List<EventoFecha> lstEventos = SUT.ObtenerEventos();

            //assert
            DOCILeerArchivo.Verify(a => a.ObtenerArchivo(It.IsAny<string>()), Times.Once);
        }      

    }
}