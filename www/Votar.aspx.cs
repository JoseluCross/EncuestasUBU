using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace www
{
    public partial class Votar : System.Web.UI.Page
    {
        private DB db;
        private Encuesta enc;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DB)Application["db"];
            if (db is null)
            {
                db = DB.getDB();
                Application["db"] = db;
            }

            try
            {
                string title = Request.QueryString["m"];
                enc = db.cargaEncuesta(title);
            }
            catch (Exception)
            {
                Response.Redirect("ElegirEncuesta.aspx");
            }
            L_Titulo.Text = enc.Titulo;
            L_Descripcion.Text = enc.Descripcion;
        }

        protected void B_Atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ElegirEncuesta.aspx");
        }

        protected void IB_ENFADADO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Comentario.aspx?tv=0&m="+enc.Titulo);
        }

        protected void IB_NEUTRAL_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Comentario.aspx?tv=1&m=" + enc.Titulo);
        }

        protected void IB_SATISFECHO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Comentario.aspx?tv=2&m=" + enc.Titulo);
        }

        protected void IB_CONTENTO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Comentario.aspx?tv=3&m=" + enc.Titulo);
        }
    }
}