using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClases;
using System.Diagnostics;

namespace LibClases.Test
{
    [TestClass]
    public class EstadisticasTest
    {

        private const String SUPERRUTA = "C:\\Users\\YOSHI\\Desktop\\EncuestasUBU\\LibClasesTest\\testCsv";

        private DB db;

        [TestInitialize]
        public void TestSetup()
        {
            db = DB.getDB();
            db.clear();
            db.load("C:\\Users\\YOSHI\\Desktop\\EncuestasUBU");
        }

        [TestMethod]
        public void estadoEncuestaTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.estadoEncuesta();
            DataTable real = new DataTable();
            real.Columns.Add("Estado", typeof(string));
            real.Columns.Add("NEncuestas", typeof(int));
            String aux1;
            int aux2;

            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\1-estadoEncuesta.csv")) 
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    aux1 = values[0];
                    aux2 = Int32.Parse(values[1]);
                    real.Rows.Add(new object[] { aux1, aux2 });
                }
            }
           Assert.IsTrue(this.comparar(real, res));
        }

        [TestMethod]
        public void numeroEncuestasTest()
        {
            Estadistica est = new Estadistica(db);
            int res = est.numeroEncuestas();
            int real=0;
            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\2-numeroEncuestas.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    real = Int16.Parse(values[0]);
                }
            }
            Assert.AreEqual(res, real);
        }

        [TestMethod]
        public void numeroRespuestas()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.numeroRespuestas();
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));
            
            real = cargaBinaria(SUPERRUTA + "\\3-numeroRespuestas.csv", real, 0);
            
            Assert.IsTrue(this.comparar(real, res));
        }

        [TestMethod]
        public void respuestasPorAniosTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.respuestasPorAnios();
            DataTable real = new DataTable();
            real.Columns.Add("Año", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            real = cargaBinaria(SUPERRUTA + "\\4-respuestasPorAnios.csv", real, 0);

            Assert.IsTrue(this.comparar(real, res));
        }

        [TestMethod]
        public void respuestasPorMesesTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.respuestasPorMeses();
            DataTable real = new DataTable();
            real.Columns.Add("Mes", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            real = cargaBinaria(SUPERRUTA + "\\5-respuestasPorMeses.csv", real, 0);

            Assert.IsTrue(this.comparar(real, res));
        }

        [TestMethod]
        public void respuestasPorSemanasTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.respuestasPorSemanas();
            DataTable real = new DataTable();
            real.Columns.Add("Dia", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            real = cargaBinaria(SUPERRUTA + "\\6-respuestasPorSemanas.csv",real, 0);

            Assert.IsTrue(this.comparar(real, res));
        }

        [TestMethod]
        public void respuestasPorHorasTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.respuestasPorHoras();
            DataTable real = new DataTable();
            real.Columns.Add("Hora", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            real = cargaBinaria(SUPERRUTA + "\\7-respuestasPorHoras.csv", real, 0);

            Assert.IsTrue(this.comparar(real, res));
        }

        [TestMethod]
        public void rankingEncuestasPorRespuestaTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.rankingEncuestasPorRespuesta();
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            real = cargaBinaria(SUPERRUTA + "\\8-rankingEncuestasPorRespuestas.csv", real, 0);
            DataView dw = new DataView(real);
            dw.Sort = "NRespuestas, Titulo DESC";
            real = dw.ToTable();
            
            Assert.IsTrue(this.compararExacto(real, res));   
        }

        [TestMethod]
        public void rankingEncuestaPorValoracion()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.rankingEncuestasPorValoracion();
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Valoracion", typeof(int));

            real = cargaBinaria(SUPERRUTA + "\\9-rankingEncuestasPorValoracion.csv", real, 0);

            DataView dw = new DataView(real);
            dw.Sort = "Valoracion, Titulo DESC";
            real = dw.ToTable();

            Assert.IsTrue(this.compararExacto(real, res));
        }

        [TestMethod]
        public void mediaPorEncuestaTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.mediaPorEncuesta();
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Media", typeof(double));

            real = cargaBinaria(SUPERRUTA + "\\10-mediaPorEncuesta.csv", real, 1);

            DataView dw = new DataView(real);
            dw.Sort = "Media, Titulo DESC";
            real = dw.ToTable();

            foreach (DataRow dr in real.Rows)
            {
                Debug.WriteLine(dr[0] + " " + dr[1]);
            }

            Assert.IsTrue(this.compararExacto(real, res));
        }

        [TestMethod]
        public void mediaTest()
        {
            Estadistica est = new Estadistica(db);
            double media = est.media();
            double real = 0;

            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\11-media.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    real = Double.Parse(values[0].Replace('.',','));
                }
            }

            Assert.AreEqual(media, real);
        }

        [TestMethod]
        public void medianaPorEncuestaTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.medianaPorEncuesta();
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Mediana", typeof(double));

            real = cargaBinaria(SUPERRUTA + "\\12-medianaPorEncuesta.csv", real, 1);

            DataView dw = new DataView(real);
            dw.Sort = "Mediana, Titulo DESC";
            real = dw.ToTable();

            Assert.IsTrue(this.compararExacto(real, res));
        }

        [TestMethod]
        public void mediana()
        {
            Estadistica est = new Estadistica(db);
            double mediana = est.mediana();
            double real = 0;

            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\13-mediana.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    real = Double.Parse(values[0].Replace('.', ','));
                }
            }

            Assert.AreEqual(mediana, real);
        }

        [TestMethod]
        public void desvEstPorEncuestaTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.desvEstPorEncuesta();
            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Desviacion", typeof(double));

            real = cargaBinaria(SUPERRUTA + "\\14-desvEstPorEncuesta.csv", real, 1);

            DataView dw = new DataView(real);
            dw.Sort = "Desviacion, Titulo DESC";
            real = dw.ToTable();

            Assert.IsTrue(this.compararExacto(real, res));
        }

        [TestMethod]
        public void desvestTest()
        {
            Estadistica est = new Estadistica(db);
            double real = 0;
            double res = est.desvest();

            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\15-desvest.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    real = Math.Round(Double.Parse(values[0].Replace('.', ',')),8);
                }
            }

            Assert.AreEqual(real, res);

        }

        [TestMethod]
        public void numRespRangosPorEncuestaTest()
        {
            Estadistica est = new Estadistica(db);
         
            String[] aux = { "teclado", "agua" };
            foreach (String s in aux)
            {

                DataTable real = new DataTable();
                real.Columns.Add("Titulo", typeof(string));
                real.Columns.Add("Minimo", typeof(int));
                real.Columns.Add("Maximo", typeof(int));

                using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\16-numRespRangosPorEncuesta-" + s + ".csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        real.Rows.Add(new object[] { values[0], Int32.Parse(values[1]), Int32.Parse(values[2]) });
                    }
                }

                DataTable res = est.numRespRangosPorEncuesta((string)real.Rows[0][0]);

                Assert.IsTrue(this.comparar(real, res));
            }
        }

        [TestMethod]
        public void numRespRangosTest()
        {
            Estadistica est = new Estadistica(db);

            DataTable real = new DataTable();
            real.Columns.Add("Titulo", typeof(string));
            real.Columns.Add("Minimo", typeof(int));
            real.Columns.Add("Maximo", typeof(int));

            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\17-numRespRangos.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    real.Rows.Add(new object[] { values[0], Int32.Parse(values[1]), Int32.Parse(values[2]) });
                }
            }

            DataTable res = est.numRespRangos();

            Assert.IsTrue(this.comparar(real, res));
        }

        private bool comparar(DataTable real, DataTable res)
        {
            if(real.Rows.Count != res.Rows.Count)
            {
                return false;
            }
            bool flag = false;
            bool flag2 = true;
            for (int i = 0; i < res.Rows.Count; i++)
            {
                flag = false;
                for (int j = 0; j < real.Rows.Count; j++)
                {
                    flag2 = true;
                    for(int w= 0; w < real.Columns.Count; w++)
                    {

                        if (!Equals(real.Rows[j][w], res.Rows[i][w]))
                        {
                            flag2 = false;
                            break;
                        }

                    }
                    if (flag2)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    return false;
                }
            }
            return true;
        }

        private bool compararExacto(DataTable real, DataTable res)
        {
            if(real.Rows.Count != res.Rows.Count)
            {
                return false;
            }
            for(int i = 0; i < real.Rows.Count; i++)
            {
                for (int j = 0; j < real.Columns.Count; j++)
                {
                    if (!Equals(real.Rows[i][j],res.Rows[i][j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Carga un datatable de un csv en las pruebas de respuestas por fecha
        /// </summary>
        /// <param name="route">Ruta del CSV</param>
        /// <param name="real">DataTable original sin datos</param>
        /// <param name="mode">Modo del segundo dato, siendo 0 si es entero y 1 si es double</param>
        /// <returns>Datatable con los datos</returns>
        private DataTable cargaBinaria(string route, DataTable real, int mode)
        {

            string aux1;
            object aux2 = 0;

            using (var reader = new System.IO.StreamReader(route))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    aux1 = values[0];
                    switch (mode)
                    {
                        case 0:
                            aux2 = Int32.Parse(values[1]);
                            break;
                        case 1:
                            aux2 = Math.Round(Double.Parse(values[1].Replace('.',',')),8);
                            break;
                    }
                    real.Rows.Add(new object[] { aux1, aux2 });
                }
            }
            return real;
        }
    }
}
