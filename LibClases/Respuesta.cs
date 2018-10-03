using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibClases
{
    class Respuesta
    {
        private Encuesta enc;
        private Voto voto;
        private string mensage;

        public Respuesta(Encuesta enc, Voto voto, string mensage)
        {
            this.enc = enc;
            this.voto = voto;
            this.mensage = mensage;
            ///TODO: Almacenar en la base de datos.
        }

        public Respuesta(Encuesta enc, int index)
        {
            this.enc = enc;
            ///TODO: Cargar encuesta con el índice en la base de datos
        }

        public Voto Voto
        {
            get { return this.voto; }
        }

        public string Mensage
        {
            get { return this.mensage; }
        }
    }
}
