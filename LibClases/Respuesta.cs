using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibClases
{
    public class Respuesta
    {
        /// <summary>
        /// Encuesta a la que pertenece la respuesta
        /// </summary>
        private Encuesta enc;
        /// <summary>
        /// Voto dado
        /// </summary>
        private Voto voto;
        /// <summary>
        /// Mensaje 
        /// </summary>
        private string mensaje;

        /// <summary>
        /// Crea una respuesta
        /// </summary>
        /// <param name="enc">Encuesta de la respuesta</param>
        /// <param name="voto">Voto dado</param>
        /// <param name="mensaje">Mensaje dado</param>
        public Respuesta(Encuesta enc, Voto voto, string mensaje)
        {
            this.enc = enc;
            this.voto = voto;
            this.mensaje = mensaje;
            ///TODO: Almacenar en la base de datos.
        }

        /// <summary>
        /// Getter del voto 
        /// </summary>
        public Voto Voto
        {
            get { return this.voto; }
        }

        /// <summary>
        /// Getter del mensaje
        /// </summary>
        public string Mensaje
        {
            get { return this.mensaje; }
        }

        /// <summary>
        /// Getter de la encuesta
        /// </summary>
        public Encuesta Encuesta
        {
            get { return this.enc; }
        }
		
		/// <summary>
        /// Sobreescribir método Equals
        /// </summary>
        /// <param name="obj">Objeto a comparar con nosostros</param>
        /// <returns>True si tenemos los mismos atributos</returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Respuesta) && ((Respuesta)obj).Encuesta == this.Encuesta && ((Respuesta)obj).Voto == this.Voto && ((Respuesta)obj).Mensaje == this.Mensaje;
        }
    }
}
