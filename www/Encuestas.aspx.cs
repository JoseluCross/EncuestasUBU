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
            db = DB.getDB();
            List<Encuesta> enc = db.cargaEncuestas();

            int i = 0;
            foreach(Encuesta en in enc)
            {
                TableRow tr = new TableRow();
                TableCell n = new TableCell();
                n.Text = i.ToString();
                TableCell titulo = new TableCell();
                titulo.Text = en.Titulo;
                TableCell visibilidad = new TableCell();
                if (en.Visible)
                {
                    visibilidad.Text = "SI";
                }
                else
                {
                    visibilidad.Text = "NO";
                }

                i++;
            }
        }
    }
}