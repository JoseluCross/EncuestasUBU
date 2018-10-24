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
            Label titulo = (Label)FindControl("Titulo");
            enc = db.cargaEncuesta(aux);
            resp = db.cargaRespuestas(aux);
            titulo.Text = enc.Titulo;
            Label me = (Label)FindControl("PE");
            Label e = (Label)FindControl("PME");
            Label c = (Label)FindControl("PC");
            Label mc = (Label)FindControl("PMC");
            foreach (Respuesta r in resp)
            {
                switch (r.Voto)
                {
                    case Voto.ENFADADO:
                        this.me++;
                        break;
                }
            }
        }
    }
}