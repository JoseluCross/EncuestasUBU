using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibClases.Test
{
    /// <summary>
    /// Descripción resumida de DBTest
    /// </summary>
    [TestClass]
    public class DBTest
    {
        /// <summary>
        /// Comprueba que la instancias solicitada es una base de datos son la misma
        /// </summary>
        [TestMethod]
        public void TestSingleton()
        {
            DB db = DB.getDB();
            DB db2 = DB.getDB();
            Assert.AreSame(db,db2);
        }

        /// <summary>
        /// Comprueba que un usuario es cargado correctamente
        /// </summary>
        [TestMethod]
        public void TestCargaUsuarioExistente()
        {
            DB db = DB.getDB();
            Usuario usuario;
            usuario = db.cargaUsuario("Dios");
            Assert.IsNotNull(usuario.Contraseña);
        }

        /// <summary>
        /// Comprueba que ante un usuario que no existe
        /// </summary>
        [TestMethod]
        public void TestCargaUsuarioIncorrecto()
        {
            DB db = DB.getDB();
            Usuario usuario;
            usuario = db.cargaUsuario("NoExisto");
            Assert.IsNull(usuario.Contraseña);
        }

    }
}
