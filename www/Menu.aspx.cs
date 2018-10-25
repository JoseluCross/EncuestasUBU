using LibClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class Menu : System.Web.UI.Page
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

        }

        protected void BA_Click(object sender, EventArgs e)
        {
            Response.Redirect("AñadirModificar.aspx");
        }

        protected void BE_Click(object sender, EventArgs e)
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