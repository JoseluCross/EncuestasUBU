using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace www
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        private DB db;
        private string aux;
        private Encuesta enc;
        private List<Respuesta> resp;
        private int me = 0;
        private int e = 0;
        private int c = 0;
        private int mc = 0;
        protected void Page_Load(object sender, EventArgs ev)
        {
            db = (DB)Application["db"];
            if (db is null)
            {
                db = DB.getDB();
                Application["db"] = db;
            }
            aux = Request.QueryString["m"];
            Label titulo = (Label)FindControl("Titulo");
            enc = db.cargaEncuesta(aux);
            resp = db.cargaRespuestas(aux);
            titulo.Text = enc.Titulo;
            Label me = (Label)FindControl("PME");
            Label e = (Label)FindControl("PE");
            Label c = (Label)FindControl("PC");
            Label mc = (Label)FindControl("PMC");
            foreach (Respuesta r in resp)
            {
                switch (r.Voto)
                {
                    case Voto.ENFADADO:
                        this.me++;
                        break;
                    case Voto.NEUTRAL:
                        this.e++;
                        break;
                    case Voto.SATISFECHO:
                        this.c++;
                        break;
                    case Voto.CONTENTO:
                        this.mc++;
                        break;
                }
                TableRow tr = new TableRow();
                TableCell n = new TableCell();
                n.Text = r.Mensaje;
                tr.Controls.Add(n);
                TC.Controls.Add(tr);
            }
            me.Text = ": " + this.me.ToString();
            e.Text = ": " + this.e.ToString();
            c.Text = ": " + this.c.ToString();
            mc.Text = ": " + this.mc.ToString();
        }

        protected void BA_Click(object sender, EventArgs e)
        {
            Response.Redirect("Encuestas.aspx");
        }

        protected void BCS_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}