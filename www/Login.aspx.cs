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
            bool res;
            Label lbl = (Label)FindControl("L_Error");
            Usuario u = null;
            try
            {
                u = db.cargaUsuario(cuenta.Text);
                res = u.comprobar(Usuario.Encriptar(pass.Text));
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch(KeyNotFoundException ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                res = false;
            }
            
            if (!res)
            {
                lbl.Text = "Credenciales incorrectas";
            }
            else
            {
                Session["usuario"] = u;
                Response.Redirect("Menu.aspx");
            }
        }

        protected void B_Atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ElegirEncuesta.aspx");
        }
    }
}