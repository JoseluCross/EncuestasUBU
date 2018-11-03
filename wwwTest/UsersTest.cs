using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest1
{
    [TestClass]
    public class Users
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
        public void TheObligatorioVacioTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/ElegirEncuesta.aspx");
            driver.FindElement(By.Id("ENC1")).Click();
            driver.FindElement(By.Id("IB_ENFADADO")).Click();
            driver.FindElement(By.Id("BE")).Click();
            Assert.AreEqual("Debes poner un comentario", driver.FindElement(By.Id("LE")).Text);
        }

        [TestMethod]
        public void TheOpcionalRellenoTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/ElegirEncuesta.aspx");
            driver.FindElement(By.Id("ENC1")).Click();
            driver.FindElement(By.Id("IB_CONTENTO")).Click();
            driver.FindElement(By.Id("TAC")).Clear();
            driver.FindElement(By.Id("TAC")).SendKeys("Estoy encantado con la situación de las sillas");
            driver.FindElement(By.Id("BE")).Click();
        }

        [TestMethod]
        public void TheNavegacionTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/ElegirEncuesta.aspx");
            driver.FindElement(By.Id("ENC1")).Click();
            Assert.IsTrue(IsElementPresent(By.Id("L_Titulo")));
            driver.FindElement(By.Id("B_Atras")).Click();
            Assert.IsTrue(IsElementPresent(By.Id("BA")));
            driver.FindElement(By.Id("ENC1")).Click();
            driver.FindElement(By.Id("IB_NEUTRAL")).Click();
            Assert.IsTrue(IsElementPresent(By.Id("Titulo")));
            driver.FindElement(By.Id("BCS")).Click();
            Assert.IsTrue(IsElementPresent(By.Id("L_Titulo")));
            driver.FindElement(By.Id("IB_SATISFECHO")).Click();
            driver.FindElement(By.Id("BC")).Click();
            Assert.IsTrue(IsElementPresent(By.Id("BA")));
        }

        [TestMethod]
        public void TheOpcionalNoRellenoTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/ElegirEncuesta.aspx");
            driver.FindElement(By.Id("ENC1")).Click();
            driver.FindElement(By.Id("IB_NEUTRAL")).Click();
            driver.FindElement(By.Id("BE")).Click();
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

        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
