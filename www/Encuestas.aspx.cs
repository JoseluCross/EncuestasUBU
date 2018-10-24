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
            Table t = (Table)FindControl("T_Encuestas");
            int i = 0;
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
                es.ID = "BTN_ES_" + i;
                ed.ID = "BTN_ED_" + i;
                b.ID = "BTN_B_" + i;

                

                t.Controls.Add(tr);
                i++;
            }
        }

        protected void V_Click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            int i = getIdentifier(b.ID);

            Table t = (Table)FindControl("T_Encuestas");
            string title = t.Rows[i].Cells[1].Text;

            Encuesta enc = db.cargaEncuesta(title);
            if(!db.limiteVisible())
                enc.cambiarVisibilidad();

        }

        protected void ES_Click(object sender, EventArgs e)
        {

        }

        protected void ED_Click(object sender, EventArgs e)
        {

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