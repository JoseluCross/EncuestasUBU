using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace www
{
    public partial class Login : System.Web.UI.Page
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

        protected void B_Acceder_Click(object sender, EventArgs e)
        {
            TextBox cuenta = (TextBox)FindControl("TB_Cuenta");
            TextBox pass = (TextBox)FindControl("TB_Pass");
            Usuario u = db.cargaUsuario(cuenta.Text);
            bool res = u.comprobar(Usuario.Encriptar(pass.Text));
            Label lbl = (Label)FindControl("L_Error");
            if (!res)
            {
                lbl.Text += "Credenciales incorrectas";
            }
            else
            {
                Session["usuario"] = u;
                Response.Redirect("Menu.aspx");
            }
        }
    }
}