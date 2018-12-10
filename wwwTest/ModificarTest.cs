using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using LibClases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
/**
namespace SeleniumTests
{
    [TestClass]
    public class ModificarTest
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

        [TestMethod]
        public void TheModificarAceptadoTest()
        {
            acceder();

            string des = getEncAtt(By.Id("BTN_ED_1"),"TD");

            driver.FindElement(By.Id("BTN_ED_1")).Click();
            driver.FindElement(By.Id("TD")).Clear();
            driver.FindElement(By.Id("TD")).SendKeys(des+"A");
            driver.FindElement(By.Id("ACC")).Click();

            string desB = getEncAtt(By.Id("BTN_ED_1"), "TD");

            Assert.AreNotEqual(des, desB);

            driver.FindElement(By.Id("BCS")).Click();
        }

        [TestMethod]
        public void TheModificarBorrarCampoTest()
        {
            acceder();

            driver.FindElement(By.Id("BTN_ED_1")).Click();
            driver.FindElement(By.Id("TD")).Clear();
            driver.FindElement(By.Id("ACC")).Click();

            Assert.IsTrue(IsElementPresent(By.Id("TD_VAL")));

            driver.FindElement(By.Id("BCS")).Click();
        }

        [TestMethod]
        public void TheModificarCanceladoTest()
        {
            acceder();

            string des = getEncAtt(By.Id("BTN_ED_1"), "TD");

            driver.FindElement(By.Id("BTN_ED_1")).Click();
            driver.FindElement(By.Id("TD")).Clear();
            driver.FindElement(By.Id("TD")).SendKeys(des + "A");
            driver.FindElement(By.Id("BC")).Click();

            string desB = getEncAtt(By.Id("BTN_ED_1"), "TD");

            Assert.AreEqual(des, desB);

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
*/
