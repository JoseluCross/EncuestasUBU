using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibClases
{
    public class Encuesta
    {
        /// <summary>
        /// Título de la encuesta y clave de la misma
        /// </summary>
        private string titulo;
        /// <summary>
        /// Descripción de la encuesta
        /// </summary>
        private string descripcion;
        /// <summary>
        /// Ruta de la Foto para mostrarla en el HTML
        /// </summary>
        private string rutaFoto;
        /// <summary>
        /// Encuesta visible o no visible
        /// </summary>
        private bool visible;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="descripcion"></param>
        /// <param name="rutaFoto"></param>
        /// <param name="visible"></param>
        public Encuesta(string titulo, string descripcion, string rutaFoto, bool visible = false)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.rutaFoto = rutaFoto;
            this.visible = visible;
        }

        /// <summary>
        /// Cambiar visilidad a la encuesta a la contraria que tenía
        /// </summary>
        public void cambiarVisibilidad()
        {
            this.visible = !visible;
        }

        /// <summary>
        /// Getter y setter del título
        /// </summary>
        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        /// <summary>
        /// Getter y setter de la descripción
        /// </summary>
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        /// <summary>
        /// Getter y setter de la ruta de la foto
        /// </summary>
        public string RutaFoto
        {
            get { return this.rutaFoto; }
            set { this.rutaFoto = value; }
        }

        /// <summary>
        /// Getter de la visibilidad
        /// </summary>
        public bool Visible
        {
            get { return this.visible; }
        }
		
		/// <summary>
        /// Sobreescribir método Equals
        /// </summary>
        /// <param name="obj">Objeto a comparar con nosostros</param>
        /// <returns>True si tenemos el mismo titulo</returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Encuesta) && ((Encuesta)obj).Titulo == this.Titulo;
        }

        /// <summary>
        /// HashCode de la encuesta
        /// </summary>
        /// <returns>Hash</returns>
        public override int GetHashCode()
        {
            return titulo.GetHashCode();
        }
    }
}
