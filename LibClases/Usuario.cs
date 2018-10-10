using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LibClases
{
    public class Usuario
    {
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        private string cuenta;
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        private string contraseña;

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="cuenta">Identificador del usuario</param>
        public Usuario(string cuenta)
        {
            this.cuenta = cuenta;
            try
            {
                DB db = DB.getDB();
                this.contraseña = db.cargaUsuario(cuenta).Contraseña;
            }catch(KeyNotFoundException ex)
            {
                contraseña = null;
            }
        }

        /// <summary>
        /// Crea un usuario nuevo
        /// </summary>
        /// <param name="cuenta">Cuenta del usuario</param>
        /// <param name="contraseña">Nueva contraseña</param>
        public Usuario(string cuenta, string contraseña)
        {
            this.cuenta = cuenta;
            this.contraseña = Encriptar(contraseña);
        }

        /// <summary>
        /// Getter de la cuenta
        /// </summary>
        public string Cuenta
        {
            get { return this.cuenta; }
        }

        public string Contraseña
        {
            get { return this.contraseña; }
        }

        /// <summary>
        /// Comprueba si la contraseña es igual a la pasada
        /// </summary>
        /// <param name="contraseña">Cadena con la contraseña pasada</param>
        /// <returns>Verdad si la contraseña es la misma, falso si no</returns>
        public bool comprobar(string contraseña)
        {
            if (contraseña == null)
                return false;
            return contraseña == this.contraseña;
        }

        /// <summary>
        /// Encriptar contraseña
        /// </summary>
        /// <author>
        /// Pedro Renedo Fernández
        /// </author>
        /// <param name="password">Contraseña a encriptar</param>
        /// <returns>Cadena con la contraseña encriptada</returns>
        public static string Encriptar(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256 mySHA256 = SHA256.Create();
            bytes = mySHA256.ComputeHash(bytes);
            return Encoding.ASCII.GetString(bytes);
        }
		
		/// <summary>
        /// Sobreescribir método Equals
        /// </summary>
        /// <param name="obj">Objeto a comparar con nosostros</param>
        /// <returns>True si tenemos la misma cuenta</returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Usuario) && ((Usuario)obj).Cuenta == this.Cuenta;
        }
    }
}
