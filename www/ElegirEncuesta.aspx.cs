using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace www
{
    public partial class ElegirEncuesta : System.Web.UI.Page
    {
        private DB db;
        private List<Encuesta> enc;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DB)Application["db"];
            if (db is null)
            {
                db = DB.getDB();
                //db.load();
                Application["db"] = db;
            }
            enc = db.cargaEncuestasVisibles();
            foreach(Encuesta en in enc)
            {
                TableRow tr = new TableRow();
                TableCell n = new TableCell();
                TableCell m = new TableCell();
                ImageButton ib = new ImageButton();
                ib.ImageUrl = "images/encImg/" + en.RutaFoto;
                Label l = new Label();
                l.Text = en.Titulo;
                ib.ID = en.Titulo;
                ib.Click += new ImageClickEventHandler(IB_Click);
                n.Controls.Add(ib);
                m.Controls.Add(l);
                tr.Controls.Add(n);
                tr.Controls.Add(m);
                TEV.Controls.Add(tr);
            }
        }

        protected void BA_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void IB_Click(object sender, EventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            Response.Redirect("Votar.aspx?m=" + b.ID);
        }
    }
}