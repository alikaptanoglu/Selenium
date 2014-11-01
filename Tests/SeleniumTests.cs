using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
	[TestFixture]
	public class ThortsAppTestCase
	{
		// comment
		private IWebDriver driver;
		private StringBuilder verificationErrors;
		private string baseURL;

		[TestFixtureSetUp]
		public void SetupTests()
		{
			driver = new FirefoxDriver();
		}

		[TestFixtureTearDown]
		public void TearDownTests()
		{
		}

		[SetUp]
		public void SetupTest()
		{
			//driver = new ChromeDriver ();
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

			// set subject
			driver.FindElement (By.Id ("g32-name")).ClearAndSetText ("testing");
			driver.FindElement (By.Id ("g32-email")).ClearAndSetText("jonathanparkeremail@gmail.com");

			driver.FindElement (By.Id ("contact-form-comment-g32-comment")).ClearAndSetText("Testing Selenium.");
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
	}
}

