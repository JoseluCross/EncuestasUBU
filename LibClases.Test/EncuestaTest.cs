using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClases;

namespace LibClasesTest
{
    [TestClass]
    public class EncuestaTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Encuesta enc = new Encuesta("EncTest", "Descripcion", "img1.jpg", true);
            Assert.AreEqual("EncTest", enc.Titulo);
            Assert.AreEqual("Descripcion", enc.Descripcion);
            Assert.AreEqual("img1.jpg", enc.RutaFoto);
            Assert.IsTrue(enc.Visible);
        }

        [TestMethod]
        public void TestCambiarVisibilidad()
        {
            bool visibilidadAnterior = true;
            Encuesta enc = new Encuesta("EncTest", "Descripcion", "img1.jpg", visibilidadAnterior);
            enc.cambiarVisibilidad();
            Assert.AreNotEqual(visibilidadAnterior, enc.Visible);

            visibilidadAnterior = false;
            enc = new Encuesta("EncTest", "Descripcion", "img1.jpg", visibilidadAnterior);
            enc.cambiarVisibilidad();
            Assert.AreNotEqual(visibilidadAnterior, enc.Visible);
        }


    }
}
