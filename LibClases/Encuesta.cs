using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibClases
{
    class Encuesta
    {
        private string titulo;
        private string descripcion;
        private string rutaFoto;
        private bool visible;

        public Encuesta(string titulo)
        {
            this.titulo = titulo;
            ///TODO: Read from database
        }

        public Encuesta(string titulo, string descripcion, string rutaFoto, bool visible = false)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.rutaFoto = rutaFoto;
            this.visible = visible;
            ///TODO: Almacenar en la base de datos
        }

        public void actualizar()
        {
            ///TODO: Almacenar los cambios en al base de datos.
        }

        public void cambiarVisibilidad()
        {
            this.visible = !visible;
        }

        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        public string RutaFoto
        {
            get { return this.rutaFoto; }
            set { this.rutaFoto = value; }
        }

        public bool Visible
        {
            get { return this.visible; }
        }
    }
}
