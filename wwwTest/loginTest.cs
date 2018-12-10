using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
/**
namespace SeleniumTests2
{
    [TestClass]
    public class Login
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
        public void TheAccesoContraseACorrectaTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/ElegirEncuesta.aspx");
            driver.FindElement(By.Id("BA")).Click();
            driver.FindElement(By.Id("TB_Cuenta")).Clear();
            driver.FindElement(By.Id("TB_Cuenta")).SendKeys("Dios");
            driver.FindElement(By.Id("TB_Pass")).Clear();
            driver.FindElement(By.Id("TB_Pass")).SendKeys("QuienComoDios");
            driver.FindElement(By.Id("B_Acceder")).Click();
            
            Assert.AreEqual("Cerrar Sesión", driver.FindElement(By.Id("BCS")).GetAttribute("value"));
            
            driver.FindElement(By.Id("BCS")).Click();
            Assert.AreEqual("", driver.FindElement(By.Id("B_Acceder")).Text);
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
*/