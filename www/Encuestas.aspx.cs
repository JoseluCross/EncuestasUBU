using LibClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class Encuestas : System.Web.UI.Page
    {
        private DB db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DB)Application["db"];
            if (db is null)
            {
                db = DB.getDB();
                Application["db"] = db;
            }

            List<Encuesta> enc = db.cargaEncuestas();
            int i = 1;
            foreach(Encuesta en in enc)
            {
                TableRow tr = new TableRow();
                TableCell n = new TableCell();
                n.Text = i.ToString();
                TableCell titulo = new TableCell();
                titulo.Text = en.Titulo;
                TableCell visibilidad = new TableCell();

                Button v = new Button();
                Button ed = new Button();
                ed.Text = "✏";
                Button b = new Button();
                b.Text = "🗑";
                Button es = new Button();
                es.Text = "📈";
                if (en.Visible)
                {
                    v.Text = "👁";
                }
                else
                {
                    v.Text = "❌";
                }
                visibilidad.Controls.Add(v);

                TableCell editar = new TableCell();
                editar.Controls.Add(ed);
                TableCell estadistica = new TableCell();
                estadistica.Controls.Add(es);
                TableCell borrar = new TableCell();
                borrar.Controls.Add(b);

                tr.Controls.Add(n);
                tr.Controls.Add(titulo);
                tr.Controls.Add(visibilidad);
                tr.Controls.Add(editar);
                tr.Controls.Add(estadistica);
                tr.Controls.Add(borrar);

                v.ID = "BTN_V_" + i;
                v.Click += new EventHandler(V_Click);
                es.ID = "BTN_ES_" + i;
                es.Click += new EventHandler(ES_Click);
                ed.ID = "BTN_ED_" + i;
                ed.Click += new EventHandler(ED_Click);
                b.ID = "BTN_B_" + i;

                

                T_Encuestas.Controls.Add(tr);
                i++;
            }
        }

        protected void V_Click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            int i = getIdentifier(b.ID);

            string title = T_Encuestas.Rows[i].Cells[1].Text;
            
            Encuesta enc = db.cargaEncuesta(title);
            if (db.limiteVisible() && !enc.Visible)
            {
                LBL_Error.Text = "Limite de visibles alcanzados";
            }
            else
            {
                enc.cambiarVisibilidad();
                if (enc.Visible)
                {
                    b.Text = "👁";
                }
                else
                {
                    b.Text = "❌";
                }
                db.insertaEncuesta(enc);
            }

        }

        protected void ES_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int i = getIdentifier(b.ID);

            string title = T_Encuestas.Rows[i].Cells[1].Text;

            Response.Redirect("Estadisticas.aspx?m=" + title);
        }

        protected void ED_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int i = getIdentifier(b.ID);

            string title = T_Encuestas.Rows[i].Cells[1].Text;

            Response.Redirect("AñadirModificar.aspx?m="+title);
        }

        protected void B_Click(object sender, EventArgs e)
        {

        }

        private int getIdentifier(string ID)
        {
            return Int32.Parse(ID.Split('_')[2]);
        }
    }

    

}