using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
	[TestFixture]
	public class ThortsAppTestCase
	{
		private IWebDriver driver;
		private StringBuilder verificationErrors;
		private string baseURL;
		private bool acceptNextAlert = true;

		[SetUp]
		public void SetupTest()
		{
			driver = new FirefoxDriver();
			baseURL = "http://thortsapp.wordpress.com/";
			verificationErrors = new StringBuilder();
		}

		[TearDown]
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

		[Test]
		public void TheThortsAppTestCaseTest()
		{
			driver.Navigate().GoToUrl(baseURL + "/");
			driver.FindElement(By.Id("g32-name")).Clear();
			driver.FindElement(By.Id("g32-name")).SendKeys("testing");
			driver.FindElement(By.Id("g32-email")).Clear();
			driver.FindElement(By.Id("g32-email")).SendKeys("jonathanparkeremail@gmail.com");
			driver.FindElement(By.Id("contact-form-comment-g32-comment")).Clear();
			driver.FindElement(By.Id("contact-form-comment-g32-comment")).SendKeys("Testing Selenium.");
			driver.FindElement(By.CssSelector("input.pushbutton-wide")).Click();
			try
			{
				Assert.AreEqual("Message Sent", driver.FindElement(By.CssSelector("#contact-form-32 > h3")).Text);
			}
			catch (AssertionException e)
			{
				verificationErrors.Append(e.Message);
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

