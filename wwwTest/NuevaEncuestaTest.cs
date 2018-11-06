using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using LibClases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests2
{
    [TestClass]
    public class NuevaEncuestaTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:49433/";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheNuevaEncuestaVisibleTest()
        {
            string title = "ENC6";
            string desc = "Des";
            string foto = "img6.jpg";
            driver.Navigate().GoToUrl(baseURL + "/Login.aspx");
            driver.FindElement(By.Id("TB_Cuenta")).Clear();
            driver.FindElement(By.Id("TB_Cuenta")).SendKeys("Dios");
            driver.FindElement(By.Id("TB_Pass")).Clear();
            driver.FindElement(By.Id("TB_Pass")).SendKeys("QuienComoDios");
            driver.FindElement(By.Id("B_Acceder")).Click();
            driver.FindElement(By.Id("BA")).Click();
            driver.FindElement(By.Id("TT")).Clear();
            driver.FindElement(By.Id("TT")).SendKeys(title);
            driver.FindElement(By.Id("TF")).Clear();
            driver.FindElement(By.Id("TF")).SendKeys(foto);
            driver.FindElement(By.Id("CBV")).Click();
            driver.FindElement(By.Id("TD")).Clear();
            driver.FindElement(By.Id("TD")).SendKeys(desc);
            driver.FindElement(By.Id("ACC")).Click();
            // Thread.Sleep(1000);
            driver.FindElement(By.Id("BE")).Click();

            int index = 0;
            while (true)
            {
                index++;
                try
                {

                    driver.FindElement(By.Id("BTN_V_" + index.ToString()));
                }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                {
                    index--;
                    break;
                }
            }
            Assert.AreEqual("👁", driver.FindElement(By.Id("BTN_V_" + index.ToString())).GetAttribute("value"));
            driver.FindElement(By.Id("BTN_ED_" + index.ToString())).Click();
            Assert.AreEqual(title, driver.FindElement(By.Id("TT")).GetAttribute("value"));
            Assert.AreEqual(desc, driver.FindElement(By.Id("TD")).GetAttribute("value"));
            Assert.AreEqual(foto, driver.FindElement(By.Id("TF")).GetAttribute("value"));
            driver.FindElement(By.Id("BCS")).Click();
        }

        [TestMethod]
        public void TheNuevaEncuestaNoVisibleTest()
        {
            string title = "ENC7";
            string desc = "Des";
            string foto = "img1.jpg";
            driver.Navigate().GoToUrl(baseURL + "/Login.aspx");
            driver.FindElement(By.Id("TB_Cuenta")).Clear();
            driver.FindElement(By.Id("TB_Cuenta")).SendKeys("Dios");
            driver.FindElement(By.Id("TB_Pass")).Clear();
            driver.FindElement(By.Id("TB_Pass")).SendKeys("QuienComoDios");
            driver.FindElement(By.Id("B_Acceder")).Click();
            driver.FindElement(By.Id("BA")).Click();
            driver.FindElement(By.Id("TT")).Clear();
            driver.FindElement(By.Id("TT")).SendKeys(title);
            driver.FindElement(By.Id("TF")).Clear();
            driver.FindElement(By.Id("TF")).SendKeys(foto);
            driver.FindElement(By.Id("TD")).Clear();
            driver.FindElement(By.Id("TD")).SendKeys(desc);
            driver.FindElement(By.Id("ACC")).Click();
            driver.FindElement(By.Id("BE")).Click();

            int index = 0;
            while (true)
            {
                index++;
                try
                {

                    driver.FindElement(By.Id("BTN_V_" + index.ToString()));
                }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                {
                    index--;
                    break;
                }
            }
            Assert.AreEqual("❌", driver.FindElement(By.Id("BTN_V_" + index.ToString())).GetAttribute("value"));
            driver.FindElement(By.Id("BTN_ED_" + index.ToString())).Click();
            Assert.AreEqual(title, driver.FindElement(By.Id("TT")).GetAttribute("value"));
            Assert.AreEqual(desc, driver.FindElement(By.Id("TD")).GetAttribute("value"));
            Assert.AreEqual(foto, driver.FindElement(By.Id("TF")).GetAttribute("value"));
            driver.FindElement(By.Id("BCS")).Click();
        }

        [TestMethod]
        public void TheNuevaEncuestaCancelarTest()
        {
            string title = "ENC8";
            string desc = "Des";
            string foto = "img1.jpg";
            driver.Navigate().GoToUrl(baseURL + "/Login.aspx");
            driver.FindElement(By.Id("TB_Cuenta")).Clear();
            driver.FindElement(By.Id("TB_Cuenta")).SendKeys("Dios");
            driver.FindElement(By.Id("TB_Pass")).Clear();
            driver.FindElement(By.Id("TB_Pass")).SendKeys("QuienComoDios");
            driver.FindElement(By.Id("B_Acceder")).Click();
            driver.FindElement(By.Id("BA")).Click();
            driver.FindElement(By.Id("TT")).Clear();
            driver.FindElement(By.Id("TT")).SendKeys(title);
            driver.FindElement(By.Id("TF")).Clear();
            driver.FindElement(By.Id("TF")).SendKeys(foto);
            driver.FindElement(By.Id("TD")).Clear();
            driver.FindElement(By.Id("TD")).SendKeys(desc);
            driver.FindElement(By.Id("BC")).Click();
            driver.FindElement(By.Id("BE")).Click();

            int index = 0;
            while (true)
            {
                index++;
                try
                {
                    driver.FindElement(By.Id("BTN_ED_" + index.ToString()));
                }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                {
                    index--;
                    break;
                }
            }
            driver.FindElement(By.Id("BTN_ED_" + index.ToString())).Click();
            Assert.AreNotEqual(title, driver.FindElement(By.Id("TT")).GetAttribute("value"));
            driver.FindElement(By.Id("BCS")).Click();
        }

        [TestMethod]
        public void TheNuevaEncuestaTituloRepetidoTest()
        {
            string title = "ENC2";
            string desc = "Des";
            string foto = "img1.jpg";
            driver.Navigate().GoToUrl(baseURL + "/Login.aspx");
            driver.FindElement(By.Id("TB_Cuenta")).Clear();
            driver.FindElement(By.Id("TB_Cuenta")).SendKeys("Dios");
            driver.FindElement(By.Id("TB_Pass")).Clear();
            driver.FindElement(By.Id("TB_Pass")).SendKeys("QuienComoDios");
            driver.FindElement(By.Id("B_Acceder")).Click();
            driver.FindElement(By.Id("BA")).Click();
            driver.FindElement(By.Id("TT")).Clear();
            driver.FindElement(By.Id("TT")).SendKeys(title);
            driver.FindElement(By.Id("TF")).Clear();
            driver.FindElement(By.Id("TF")).SendKeys(foto);
            driver.FindElement(By.Id("TD")).Clear();
            driver.FindElement(By.Id("TD")).SendKeys(desc);
            driver.FindElement(By.Id("ACC")).Click();

            driver.FindElement(By.Id("CE"));
        }

        [TestMethod]
        public void TheNuevaEncuestaCamposObligatoriosTest()
        {
            string title = "";
            string desc = "";
            string foto = "";
            driver.Navigate().GoToUrl(baseURL + "/Login.aspx");
            driver.FindElement(By.Id("TB_Cuenta")).Clear();
            driver.FindElement(By.Id("TB_Cuenta")).SendKeys("Dios");
            driver.FindElement(By.Id("TB_Pass")).Clear();
            driver.FindElement(By.Id("TB_Pass")).SendKeys("QuienComoDios");
            driver.FindElement(By.Id("B_Acceder")).Click();
            driver.FindElement(By.Id("BA")).Click();
            driver.FindElement(By.Id("TT")).Clear();
            driver.FindElement(By.Id("TT")).SendKeys(title);
            driver.FindElement(By.Id("TF")).Clear();
            driver.FindElement(By.Id("TF")).SendKeys(foto);
            driver.FindElement(By.Id("TD")).Clear();
            driver.FindElement(By.Id("TD")).SendKeys(desc);
            driver.FindElement(By.Id("ACC")).Click();

            Assert.IsTrue(IsElementPresent(By.Id("TT_VAL")));
            Assert.IsTrue(IsElementPresent(By.Id("TF_VAL")));
            Assert.IsTrue(IsElementPresent(By.Id("TD_VAL")));
        }

        [TestMethod]
        public void TheNuevaEncuestaLimiteVisiblesTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Login.aspx");
            driver.FindElement(By.Id("TB_Cuenta")).Clear();
            driver.FindElement(By.Id("TB_Cuenta")).SendKeys("Dios");
            driver.FindElement(By.Id("TB_Pass")).Clear();
            driver.FindElement(By.Id("TB_Pass")).SendKeys("QuienComoDios");
            driver.FindElement(By.Id("B_Acceder")).Click();

            driver.FindElement(By.Id("BE")).Click();
            int i = 0;
            while (IsElementPresent(By.Id("BTN_V_" + i.ToString())) &&
                IsElementPresent(By.Id("LBL_Error")))
            {
                IWebElement vb = driver.FindElement(By.Id("BTN_V_" + i.ToString()));
                if (vb.GetAttribute("value") != "👁")
                {
                    vb.Click();
                }
                i++;
            }

            driver.FindElement(By.Id("BA")).Click();
            Assert.IsFalse(IsElementPresent(By.Id("CBV")));

            driver.FindElement(By.Id("BCS")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
