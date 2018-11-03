using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace www
{
    public partial class AñadirModificar : System.Web.UI.Page
    {
        private DB db;
        private string aux;
        private Encuesta enc;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DB)Application["db"];
            if (db is null)
            {
                db = DB.getDB();
                Application["db"] = db;
            }

            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            aux = Request.QueryString["m"];
            CheckBox vis = (CheckBox)FindControl("CBV");
            if (aux != null)
            {
                TextBox titulo = (TextBox)FindControl("TT");
                TextBox foto = (TextBox)FindControl("TF");
                TextBox desc = (TextBox)FindControl("TD");
                try
                {
                    Encuesta enc = db.cargaEncuesta(aux);
                    titulo.Text = enc.Titulo;
                    titulo.ReadOnly = true;
                    vis.Visible = false;

                    if(foto.Text == "")
                        foto.Text = enc.RutaFoto;
                    if(desc.Text == "")
                        desc.Text = enc.Descripcion;
                    this.enc = new Encuesta(enc.Titulo, enc.Descripcion, enc.RutaFoto, enc.Visible);
                }catch(Exception ex)
                {
                    Response.Redirect("Encuestas.aspx");
                }
            }
            else
            {
                if (db.limiteVisible())
                {
                    vis.Visible = false;
                }
                this.enc = new Encuesta(null, null, null, false);
            }

        }

        protected void ACC_Click(object sender, EventArgs e)
        {
            Label ce = (Label)FindControl("CE");
            ce.Visible = false;
            TextBox titulo = (TextBox)FindControl("TT");
            TextBox foto = (TextBox)FindControl("TF");
            TextBox desc = (TextBox)FindControl("TD");
            CheckBox vis = (CheckBox)FindControl("CBV");
            if (aux == null)
            {
                List<Encuesta> lenc = db.cargaEncuestas();
                foreach (Encuesta ec in lenc)
                {
                    if(ec.Titulo == titulo.Text)
                    {
                        ce.Visible = true;
                        break;
                    }
                }
                enc.Titulo = titulo.Text;
                if (vis.Checked)
                {
                    this.enc.cambiarVisibilidad();
                }
            }
            this.enc.Descripcion = desc.Text;
            this.enc.RutaFoto = foto.Text;
            if (!ce.Visible)
            {
                db.insertaEncuesta(this.enc);
                if (aux == null)
                {
                    Response.Redirect("Menu.aspx");
                }
                else
                {
                    Response.Redirect("Encuestas.aspx");
                }
            }
        }

        protected void BC_Click(object sender, EventArgs e)
        {
            if (aux == null)
            {
                Response.Redirect("Menu.aspx");
            }
            else
            {
                Response.Redirect("Encuestas.aspx");
            }
            
        }

        protected void BCS_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}