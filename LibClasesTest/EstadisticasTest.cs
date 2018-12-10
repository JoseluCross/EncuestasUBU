using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibClases;

namespace LibClases.Test
{
    [TestClass]
    public class EstadisticasTest
    {

        private const String SUPERRUTA = "C:\\Users\\YOSHI\\Desktop\\EncuestasUBU\\LibClasesTest\\testCsv";

        private DB db;

        public EstadisticasTest()
        {
            db = DB.getDB();
            db.load();
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
            String aux1;
            int aux2;

            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\3-numeroRespuestas.csv"))
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
        public void respuestasPorAniosTest()
        {
            Estadistica est = new Estadistica(db);
            DataTable res = est.respuestasPorAnios();
            DataTable real = new DataTable();
            real.Columns.Add("Año", typeof(string));
            real.Columns.Add("NRespuestas", typeof(int));

            int aux1, aux2;

            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\4-respuestasPorAnios.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    aux1 =Int32.Parse( values[0]);
                    aux2 = Int32.Parse(values[1]);
                    real.Rows.Add(new object[] { aux1, aux2 });
                }
            }
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

            int aux1, aux2;

            using (var reader = new System.IO.StreamReader(SUPERRUTA + "\\5-respuestasPorMeses.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    aux1 = Int32.Parse(values[0]);
                    aux2 = Int32.Parse(values[1]);
                    real.Rows.Add(new object[] { aux1, aux2 });
                }
            }
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
    }
}
