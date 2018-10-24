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
            db = DB.getDB();
        }
    }
}