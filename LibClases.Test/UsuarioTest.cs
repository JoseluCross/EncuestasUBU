using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClases;

namespace LibClasesTest
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Usuario u = new Usuario("Chuismi Pringao");
        }
    }
}
