using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace www
{
    public partial class Comentario : System.Web.UI.Page
    {
        private DB db;
        private Respuesta res;
        private Encuesta enc;
        private string aux;
        private int v;
        private bool flag = false;
        private Voto vot;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DB)Application["db"];
            if (db is null)
            {
                db = DB.getDB();
                Application["db"] = db;
            }
            String aux = Request.QueryString["m"];
            String vAux = Request.QueryString["tv"];
            if (aux == null || vAux == null)
                Response.Redirect("ElegirEncuesta.aspx");

            this.aux = aux;
            v = Int32.Parse(vAux);
            enc = db.cargaEncuesta(aux);
            Label titulo = (Label)FindControl("Titulo");
            Image imagen = (Image)FindControl("IV");
            
            titulo.Text = enc.Titulo;
            switch (v)
            {
                case 0:
                    vot = LibClases.Voto.ENFADADO;
                    flag = true;
                    imagen.ImageUrl="images/voto/ENFADADO.png";
                    break;
                case 1:
                    vot = LibClases.Voto.NEUTRAL;
                    imagen.ImageUrl = "images/voto/NEUTRAL.png";
                    break;
                case 2:
                    vot = LibClases.Voto.SATISFECHO;
                    imagen.ImageUrl = "images/voto/SATISFECHO.png";
                    break;
                case 3:
                    vot = LibClases.Voto.CONTENTO;
                    imagen.ImageUrl = "images/voto/CONTENTO.png";
                    break;
            }
        }

        protected void BCS_Click(object sender, EventArgs e)
        {
            Response.Redirect("Votar.aspx?m=" + aux);
        }

        protected void BC_Click(object sender, EventArgs e)
        {
            Response.Redirect("ElegirEncuesta.aspx");
        }

        protected void BE_Click(object sender, EventArgs e)
        {
            Label l = (Label)FindControl("LE");
            l.Visible = false;
            TextBox com = (TextBox)FindControl("TAC");
            string texto = com.Text;
            res = new Respuesta(db.cargaEncuesta(aux), vot, texto, new DateTime());
            if (flag)
            {
                if (texto.Length == 0)
                {
                    l.Visible = true;
                }
                else
                {
                    db.insertaRespuesta(res);
                    Response.Redirect("ElegirEncuesta.aspx");
                }
            }
            else
            {
                db.insertaRespuesta(res);
                Response.Redirect("ElegirEncuesta.aspx");
            }
        }
    }
}