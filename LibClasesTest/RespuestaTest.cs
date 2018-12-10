using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClases;

namespace LibClasesTest
{
    [TestClass]
    public class RespuestaTest
    {
        [TestMethod]
        public void TestSetGet()
        {
            bool visibilidadAnterior = true;
            Encuesta en = new Encuesta("EncTest", "Descripcion", "img1.jpg", visibilidadAnterior);
            Voto vt = Voto.ENFADADO;
            string mn = "Estoy enfadado";
            Respuesta res = new Respuesta(en, vt, mn,DateTime.Now);
            Assert.AreEqual(vt, res.Voto);
            Assert.AreEqual(mn, res.Mensaje);
        }
    }
}
