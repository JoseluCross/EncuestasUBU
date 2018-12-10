using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace LibClases
{
    public class Estadistica
    {
        private DB db;

        public Estadistica(DB db)
        {
            this.db = db;
        }

        public DataTable estadoEncuesta()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Estado", typeof(string));
            real.Columns.Add("NEncuestas", typeof(int));
            int vis = db.cargaEncuestasVisibles().Count;
            int nvis = db.cargaEncuestas().Count - vis;

            real.Rows.Add(new object[] { "No visible", nvis });
            real.Rows.Add(new object[] { "Visible", vis });

            return real;
        }

        public int numeroEncuestas()
        {
            return db.cargaEncuestas().Count;
        }

        public DataTable numeroRespuestas()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            foreach(Encuesta enc in db.cargaEncuestas())
            {
                real.Rows.Add(new object[] { enc.Titulo, db.cargaRespuestas(enc.Titulo).Count });
                Debug.WriteLine(enc.Titulo + " " + db.cargaRespuestas(enc.Titulo).Count.ToString());
            }

            return real;
        }

        public DataTable respuestasPorAnios()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Año", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            Dictionary<int, int> res = new Dictionary<int, int>();

            foreach (Encuesta enc in db.cargaEncuestas())
            {
                foreach(Respuesta resp in db.cargaRespuestas(enc.Titulo))
                {
                    int año = resp.Fecha.Year;
                    if (res.ContainsKey(año))
                    {
                        res[año]++;
                    }
                    else
                    {
                        res[año] = 1;
                    }
                }
            }
            real = añadirDiccionario(real, res);
            return real;
        }

        public DataTable respuestasPorMeses()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Mes", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            Dictionary<int, int> res = new Dictionary<int, int>();

            foreach (Encuesta enc in db.cargaEncuestas())
            {
                foreach (Respuesta resp in db.cargaRespuestas(enc.Titulo))
                {
                    int mes = resp.Fecha.Month;
                    if (res.ContainsKey(mes))
                    {
                        res[mes]++;
                    }
                    else
                    {
                        res[mes] = 1;
                    }
                }
            }

            real = añadirDiccionario(real, res);
            return real;
        }

        private DataTable añadirDiccionario(DataTable real, Dictionary<int,int> res)
        {
            foreach (int mes in res.Keys)
            {
                real.Rows.Add(new object[] { mes, res[mes] });
                Debug.WriteLine(mes.ToString() + " " + res[mes].ToString());
            }
            return real;
        }
    }
}
