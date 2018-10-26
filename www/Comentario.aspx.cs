﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace www
{
    public partial class Comentario : System.Web.UI.Page
    {
        private DB db;
        private Respuesta res;
        private Encuesta enc;
        private string aux;
        private int v;
        private bool flag = false;
        private Voto vot;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DB)Application["db"];
            if (db is null)
            {
                db = DB.getDB();
                Application["db"] = db;
            }
            aux = Request.QueryString["m"];
            v = Int32.Parse(Request.QueryString["tv"]);
            enc = db.cargaEncuesta(aux);
            Label titulo = (Label)FindControl("Titulo");
            Image imagen = (Image)FindControl("IV");
            
            titulo.Text = enc.Titulo;
            switch (v)
            {
                case 0:
                    vot = LibClases.Voto.ENFADADO;
                    flag = true;
                    imagen.ImageUrl="images/voto/ENFADADO.png";
                    break;
                case 1:
                    vot = LibClases.Voto.NEUTRAL;
                    imagen.ImageUrl = "images/voto/NEUTRAL.png";
                    break;
                case 2:
                    vot = LibClases.Voto.SATISFECHO;
                    imagen.ImageUrl = "images/voto/SATISFECHO.png";
                    break;
                case 3:
                    vot = LibClases.Voto.CONTENTO;
                    imagen.ImageUrl = "images/voto/CONTENTO.png";
                    break;
            }
        }

        protected void BCS_Click(object sender, EventArgs e)
        {
            Response.Redirect("Voto.aspx?m=" + aux);
        }

        protected void BC_Click(object sender, EventArgs e)
        {
            Response.Redirect("ElegirEncuesta.aspx");
        }

        protected void BE_Click(object sender, EventArgs e)
        {
            Label l = (Label)FindControl("LE");
            l.Visible = false;
            TextBox com = (TextBox)FindControl("TAC");
            string texto = com.Text;
            res = new Respuesta(db.cargaEncuesta(aux), vot, texto);
            if (flag)
            {
                if (texto.Length == 0)
                {
                    l.Visible = true;
                }
                else
                {
                    db.insertaRespuesta(res);
                    Response.Redirect("ElegirEncuesta.aspx");
                }
            }
            else
            {
                db.insertaRespuesta(res);
                Response.Redirect("ElegirEncuesta.aspx");
            }
        }
    }
}