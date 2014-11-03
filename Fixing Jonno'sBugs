using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
//using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CSharp
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        //[SetUp]
        [TestInitialize]
        public void SetupTest()
        {
            //driver = new FirefoxDriver();
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            //baseURL = "https://www.google.com.au/";
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
        public void TheCSharpTest()
        {
            /*
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("gbqfq")).Clear();
            driver.FindElement(By.Id("gbqfq")).SendKeys("search");
             */
            driver.Navigate().GoToUrl("http://www.australianunity.com.au/health-insurance/overseas-visitor-cover/compare-overseas-visitors-cover-products/non-working-visitors-cover-products");
            driver.FindElement(By.Id("main_1_rptProductDetails_ctl00_pdProductDetails_btnBuyNow")).Click();
            driver.FindElement(By.Id("main_1_rbPayFreqMonth")).Click();
         
            new SelectElement(driver.FindElement(By.Id("ddlMyDOBDays"))).SelectByText("01");
            driver.FindElement(By.CssSelector("#ddlMyDOBDays > option[value=\"01\"]")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlMyDOBMonths"))).SelectByText("Jan");
            driver.FindElement(By.CssSelector("#ddlMyDOBMonths > option[value=\"Jan\"]")).Click();
            Assert.AreEqual("$97.45", driver.FindElement(By.Id("main_1_premiumamount")).Text);

            Assert.AreEqual("Budget Overseas Visitors Cover", driver.FindElement(By.Id("main_1_rptHealthcoverTypes_ctl00_Label2")).Text);

            
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
