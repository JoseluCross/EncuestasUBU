using System;
using System.Collections.Generic;
using System.Linq;
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
            this.contraseña = "";
        }

        /// <summary>
        /// Getter de la cuenta
        /// </summary>
        public string Cuenta
        {
            get { return this.cuenta; }
        }

        /// <summary>
        /// Comprueba si la contraseña es igual a la pasada
        /// </summary>
        /// <param name="contraseña">Cadena con la contraseña pasada</param>
        /// <returns>Verdad si la contraseña es la misma, falso si no</returns>
        public bool comprobar(string contraseña)
        {
            return contraseña == this.contraseña;
        }
    }
}
