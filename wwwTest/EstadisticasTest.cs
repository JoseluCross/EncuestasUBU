using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using LibClases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class EstadisticasTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        private void acceder()
        {
            driver.Navigate().GoToUrl(baseURL + "/Login.aspx");
            driver.FindElement(By.Id("TB_Cuenta")).Clear();
            driver.FindElement(By.Id("TB_Cuenta")).SendKeys("Dios");
            driver.FindElement(By.Id("TB_Pass")).Clear();
            driver.FindElement(By.Id("TB_Pass")).SendKeys("QuienComoDios");
            driver.FindElement(By.Id("B_Acceder")).Click();

            driver.FindElement(By.Id("BE")).Click();
        }

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

        private string getEncAtt(By by, string field = "TT")
        {
            driver.FindElement(by).Click();
            string title = driver.FindElement(By.Id(field)).GetAttribute("value");
            driver.FindElement(By.Id("BC")).Click();
            return title;
        }

        private int firstVisible()
        {
            int index = 1;
            while (IsElementPresent(By.Id("BTN_V_" + index.ToString())))
            {
                if (driver.FindElement(By.Id("BTN_V_" + index.ToString())).GetAttribute("value")== "👁")
                {
                    return index;
                }
                index++;
            }
            driver.FindElement(By.Id("BTN_V_1")).Click();
            return 1;

        }

        [TestMethod]
        public void TheVotosCorrectosTest()
        {
            acceder();
            int fv = firstVisible();
            string tt = getEncAtt(By.Id("BTN_ED_" + fv.ToString()));
            driver.FindElement(By.Id("BTN_ES_" + fv.ToString())).Click();
            string me;
            me = driver.FindElement(By.Id("PME")).Text;

            driver.Navigate().GoToUrl(baseURL + "/ElegirEncuesta.aspx");
            driver.FindElement(By.Id(tt)).Click();
            driver.FindElement(By.Id("IB_ENFADADO")).Click();
            driver.FindElement(By.Id("TAC")).Clear();
            driver.FindElement(By.Id("TAC")).SendKeys("Hola, soy Selenium y estoy muy muy enfadado");
            driver.FindElement(By.Id("BE")).Click();

            acceder();
            driver.FindElement(By.Id("BTN_ES_" + fv.ToString())).Click();
            Assert.AreNotEqual(me, driver.FindElement(By.Id("PME")).Text);
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
