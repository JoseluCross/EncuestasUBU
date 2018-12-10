using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClases;

namespace LibClasesTest
{
    [TestClass]
    public class UsuarioTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            DB.getTestDB(new Usuario("Dios", "QuienComoDios"));
        }

        [TestMethod]
        public void TestConstructorUsuarioExiste()
        {
            Usuario u = new Usuario("Dios");
            Assert.IsNotNull(u.Contraseña);
        }

        [TestMethod]
        public void TestConstructorUsuarioNoExiste()
        {
            Usuario u = new Usuario("user");
            Assert.IsNull(u.Contraseña);
        }

        [TestMethod]
        public void TestComprobarContraseñaCorrecto()
        {
            Usuario u = new Usuario("Dios");
            string pass = Usuario.Encriptar("QuienComoDios");
            Assert.IsTrue(u.comprobar(pass));
        }

        [TestMethod]
        public void TestComprobarContraseñaIncorrecto()
        {
            Usuario u = new Usuario("Dios");
            string pass = Usuario.Encriptar("DiosComoQuien");
            Assert.IsFalse(u.comprobar(pass));
        }
    }
}
