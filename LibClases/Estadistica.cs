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
        private static Dictionary<Voto, int> puntos = new Dictionary<Voto, int>();

        public Estadistica(DB db)
        {
            this.db = db;
            puntos[Voto.CONTENTO] = 3;
            puntos[Voto.SATISFECHO] = 2;
            puntos[Voto.NEUTRAL] = 1;
            puntos[Voto.ENFADADO] = 0;
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
                    añadirCondicionado(res, año);
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
                    añadirCondicionado(res, mes);
                }
            }

            real = añadirDiccionario(real, res);
            return real;
        }        

        public DataTable respuestasPorSemanas()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Dia", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            Dictionary<int, int> res = new Dictionary<int, int>();

            foreach (Encuesta enc in db.cargaEncuestas())
            {
                foreach (Respuesta resp in db.cargaRespuestas(enc.Titulo))
                {
                    int dia = resp.Fecha.Day;
                    añadirCondicionado(res, dia);
                }
            }
            real = añadirDiccionario(real, res);
            return real;
        }

        public DataTable respuestasPorHoras()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Hora", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            Dictionary<int, int> res = new Dictionary<int, int>();

            foreach (Encuesta enc in db.cargaEncuestas())
            {
                foreach (Respuesta resp in db.cargaRespuestas(enc.Titulo))
                {
                    int hora = resp.Fecha.Hour;
                    añadirCondicionado(res, hora);
                }
            }

            real = añadirDiccionario(real, res);
            return real;
        }

        private void añadirCondicionado<T>(Dictionary<T,int> res, T val)
        {
            if (res.ContainsKey(val))
            {
                res[val]++;
            }
            else
            {
                res[val] = 1;
            }
        }

        private DataTable añadirDiccionario<T>(DataTable real, Dictionary<T, int> res)
        {
            foreach (T mes in res.Keys)
            {
                real.Rows.Add(new object[] { mes, res[mes] });
                Debug.WriteLine(mes.ToString() + " " + res[mes].ToString());
            }
            return real;
        }

        public DataTable rankingEncuestasPorRespuesta()
        {
            DataTable real = this.numeroRespuestas();

            //real = añadirDiccionario(real, res);

            DataView dw = new DataView(real);
            dw.Sort = "NRespuestas, Titulo DESC";

            return dw.ToTable();
        }

        public DataTable rankingEncuestasPorValoracion()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Valoracion", typeof(int));

            int max = puntos.Values.Max();

            foreach(Encuesta enc in db.cargaEncuestas())
            {
                int temp = -1;
                foreach (Respuesta res in db.cargaRespuestas(enc.Titulo))
                {
                    if (puntos[res.Voto] > temp)
                        temp = puntos[res.Voto];
                    if (temp == max)
                        break;
                }
                real.Rows.Add(new object[] { enc.Titulo, temp });
            }
            

            DataView dw = new DataView(real);
            dw.Sort = "Valoracion, Titulo DESC";
            real = dw.ToTable();
            return real;
        }

        public DataTable mediaPorEncuesta()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Media", typeof(double));

            foreach(Encuesta enc in db.cargaEncuestas()) { 
                List<int> valores = new List<int>();
                foreach(Respuesta res in db.cargaRespuestas(enc.Titulo))
                {
                    valores.Add(puntos[res.Voto]);
                }
                double media = Math.Round(valores.Average(),8);
                real.Rows.Add(new object[] { enc.Titulo, media });
            }

            DataView dw = new DataView(real);
            dw.Sort = "Media, Titulo DESC";
            real = dw.ToTable();

            foreach(DataRow dr in real.Rows)
            {
                Debug.WriteLine(dr[0] + " " + dr[1]);
            }

            return real;
        }

        public double media()
        {
            List<int> valores = new List<int>();
            foreach (Encuesta enc in db.cargaEncuestas())
            {
                foreach (Respuesta res in db.cargaRespuestas(enc.Titulo))
                {
                    valores.Add(puntos[res.Voto]);
                }
            }
            return valores.Average();
        }

        public DataTable medianaPorEncuesta()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Mediana", typeof(double));

            foreach (Encuesta enc in db.cargaEncuestas())
            {
                List<double> valores = new List<double>();
                foreach (Respuesta res in db.cargaRespuestas(enc.Titulo))
                {
                    valores.Add(puntos[res.Voto]);
                }
                double valor = mediana(valores);
                real.Rows.Add(new object[] { enc.Titulo, valor });
            }

            DataView dw = new DataView(real);
            dw.Sort = "Mediana, Titulo DESC";
            real = dw.ToTable();

            foreach (DataRow dr in real.Rows)
            {
                Debug.WriteLine(dr[0] + " " + dr[1]);
            }

            return real;
        }

        public double mediana()
        {
            double med = 0;

            List<double> valores = new List<double>();
            foreach(Encuesta enc in db.cargaEncuestas())
            {
                foreach(Respuesta res in db.cargaRespuestas(enc.Titulo))
                {
                    valores.Add(puntos[res.Voto]);
                }
            }

            med = mediana(valores);

            return med;
        }

        public DataTable desvEstPorEncuesta()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Desviacion", typeof(double));
            DataTable medias = mediaPorEncuesta();
            foreach(DataRow drow in medias.Rows)
            {
                double sum = 0;
                int nres = 0;
                foreach (Respuesta res in db.cargaRespuestas((string)drow[0]))
                {
                    nres++;
                    sum += Math.Pow(puntos[res.Voto] - (double)drow[1], 2);
                }
                real.Rows.Add(new object[] { drow[0], Math.Round(Math.Sqrt(sum / (nres - 1)), 8)  });
            }

            DataView dw = new DataView(real);
            dw.Sort = "Desviacion, Titulo DESC";
            real = dw.ToTable();

            foreach (DataRow dr in real.Rows)
            {
                Debug.WriteLine(dr[0] + " " + dr[1]);
            }

            return real;
        }

        public double desvest()
        {
            double sum = 0;
            int nres = 0;
            double med = media();
            foreach (Encuesta enc in db.cargaEncuestas())
            {
                foreach (Respuesta res in db.cargaRespuestas(enc.Titulo))
                {
                    nres++;
                    sum += Math.Pow(puntos[res.Voto] - med, 2);
                }
            }
            return Math.Round(Math.Sqrt(sum / (nres - 1)), 8);
        }

        private double mediana(List<double> valores)
        {
            valores.Sort();
            int indice = Decimal.ToInt32(Math.Floor(valores.Count / 2m));

            double valor = 0;
            if (valores.Count % 2 != 0)
            {
                valor = valores[indice];
            }
            else
            {
                int superIndice = Decimal.ToInt32(Math.Floor(valores.Count / 2m)) - 1;
                valor = (valores[indice] + valores[superIndice]) / 2d;
            }
            return valor;
        }

        public DataTable numRespRangosPorEncuesta(string v)
        {
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Minimo", typeof(int));
            real.Columns.Add("Maximo", typeof(int));

            Encuesta enc = db.cargaEncuesta(v);

            real = añadirMinMax(real, enc.Titulo);
            return real;

        }

        public DataTable numRespRangos()
        {
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Minimo", typeof(int));
            real.Columns.Add("Maximo", typeof(int));

            foreach(Encuesta enc in db.cargaEncuestas())
            {

                real = añadirMinMax(real, enc.Titulo);
            }
            return real;
        }

        private DataTable añadirMinMax(DataTable real, string ti)
        {
            int min = 4;
            int max = -1;
            int vo = 0;
            foreach (Respuesta res in db.cargaRespuestas(ti))
            {
                vo = puntos[res.Voto];
                if (vo < min)
                {
                    min = vo;
                }
                if (vo > max)
                {
                    max = vo;
                }
                if (min == puntos.Values.Min() && max == puntos.Values.Max())
                {
                    break;
                }
            }
            real.Rows.Add(new object[] { ti, min, max });
            return real;
        }
    }
}
