using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibClases
{
    public class DB
    {
        /// <summary>
        /// Mapa de los usuarios
        /// </summary>
        private Dictionary<String, Usuario> mapaUsuario;

        /// <summary>
        /// Mapa de las encuestas
        /// </summary>
        private Dictionary<String, Encuesta> mapaEncuesta;

        /// <summary>
        /// Mapa de las respuestas
        /// </summary>
        private Dictionary<String, List<Respuesta>> mapaRespuesta;

        /// <summary>
        /// Máximo de encuestas visibles
        /// </summary>
        private const int MAX_VIS = 4;

        /// <summary>
        /// Método que nos devuelve un usuario pasandole la cuenta
        /// </summary>
        /// <param name="cuenta">Identificador del usuario</param>
        /// <returns>Usuario pedido</returns>
        public Usuario cargaUsuario(String cuenta)
        {
            return this.mapaUsuario[cuenta];
        }


        /// <summary>
        /// Método que nos devuelve una encuesta
        /// </summary>
        /// <param name="nombre">Identificador de la encuesta</param>
        /// <returns>Encuesta pedida</returns>
        public Encuesta cargaEncuesta(String nombre)
        {
            return this.mapaEncuesta[nombre];
        }

        /// <summary>
        /// Método que nos devuelve una Respuesta
        /// </summary>
        /// <param name="nombre">Identificador de la Encuesta de la Respuesta requerida</param>
        /// <param name="indice">Índice de la Respuesta</param>
        /// <returns>Respuesta pedida</returns>
        public Respuesta cargaRespuesta(String nombre, int indice)
        {
            return this.mapaRespuesta[nombre][indice];
        }

        /// <summary>
        /// Método que nos devuelve las encuestas de la
        /// </summary>
        /// <returns></returns>
        public List<Encuesta> cargaEncuestas()
        {
            List<Encuesta> salida = new List<Encuesta>();
            foreach (KeyValuePair<String,Encuesta> e in this.mapaEncuesta)
            {
                salida.Add(e.Value);
            }
            return salida;
        }

        /// <summary>
        /// Método que nos devuelve todas las respuestas de una encuesta
        /// </summary>
        /// <param name="nombre">Nombre de la encuesta</param>
        /// <returns>lista de Respuestas</returns>
        public List<Respuesta> cargaRespuestas(String nombre)
        {
            return this.mapaRespuesta[nombre];
        }

        public void borrarEncuesta(String titulo)
        {
            this.mapaEncuesta.Remove(titulo);
            this.mapaRespuesta.Remove(titulo);
        }

        /// <summary>
        /// Método que nos devuelve la lista de encuestas visibles
        /// </summary>
        /// <returns>Las encuestas visibles</returns>
        public List<Encuesta> cargaEncuestasVisibles()
        {
            List<Encuesta> salida = new List<Encuesta>();
            foreach (KeyValuePair<String, Encuesta> e in this.mapaEncuesta)
            {
                if (e.Value.Visible)
                {
                    salida.Add(e.Value);
                }
            }
            return salida;
        }

        /// <summary>
        /// Método que nos idica si se ha llegado al límite de encuestas visible
        /// </summary>
        /// <returns>Boolean, true si se ha llegado al límite</returns>
        public bool limiteVisible()
        {
            List<Encuesta> aux = cargaEncuestasVisibles();
            if(aux.Count == MAX_VIS)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método que inserta en la base de datos una nueva encuesta
        /// </summary>
        /// <param name="en">Encuesta a insertar</param>
        public void insertaEncuesta(Encuesta en)
        {
            if (!this.mapaEncuesta.ContainsKey(en.Titulo))
                this.mapaRespuesta[en.Titulo] = new List<Respuesta>();
            this.mapaEncuesta[en.Titulo] = en;
        }

        /// <summary>
        /// Método que inserta una respuesta de una encuesta
        /// </summary>
        /// <param name="res">Respuesta que se va a insertar</param>
        public void insertaRespuesta(Respuesta res)
        {
            if (this.mapaEncuesta.Keys.Contains(res.Encuesta.Titulo))
                this.mapaRespuesta[res.Encuesta.Titulo].Add(res);
            else
                throw new Exception("Asignar respuesta a encuesta no existente");
        }

        /// <summary>
        /// Constructor que carga datos de forma manual
        /// </summary>
        private DB()
        {
            this.mapaUsuario = new Dictionary<string, Usuario>();
            this.mapaEncuesta = new Dictionary<string, Encuesta>();
            this.mapaRespuesta = new Dictionary<string, List<Respuesta>>();
            Encuesta en = new Encuesta("ENC1", "Esta es la encuesta 1", "img1.jpg", true);
            insertaEncuesta(en);
            en = new Encuesta("ENC2", "Esta es la encuesta 2", "img2.jpg", true);
            insertaEncuesta(en);
            en = new Encuesta("ENC3", "Esta es la encuesta 3", "img3.jpg", true);
            insertaEncuesta(en);
            en = new Encuesta("ENC4", "Esta es la encuesta 4", "img4.jpg", false);
            insertaEncuesta(en);
            en = new Encuesta("ENC5", "Esta es la encuesta 5", "img5.jpg", false);
            insertaEncuesta(en);
            insertaRespuesta(new Respuesta(en, Voto.ENFADADO, "Estoy enfadado"));
            Usuario us = new Usuario("Dios", "QuienComoDios");
            this.mapaUsuario[us.Cuenta] = us;
        }

        /// <summary>
        /// Hace un test vacío
        /// </summary>
        /// <param name="test">Discrimina entre el otro constructor</param>
        private DB(Usuario us)
        {
            this.mapaUsuario = new Dictionary<string, Usuario>();
            this.mapaEncuesta = new Dictionary<string, Encuesta>();
            this.mapaRespuesta = new Dictionary<string, List<Respuesta>>();
            this.mapaUsuario[us.Cuenta] = us;
        }

        /// <summary>
        /// Instancia privada de la base de datos
        /// </summary>
        private static DB instance = new DB();

        /// <summary>
        /// Lectura de la base de datos Singleton
        /// </summary>
        /// <returns></returns>
        public static DB getDB()
        {
            return instance;
        }

        public static DB getTestDB(Usuario us)
        {
            return new DB(us);
        }
    }
}
