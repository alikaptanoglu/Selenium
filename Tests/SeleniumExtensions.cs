using System;
using OpenQA.Selenium;

namespace Tests
{
	public static class SeleniumExtensions
	{
		public static void ClearAndSetText(this IWebElement element, string text)
		{
			element.Clear ();
			element.SendKeys (text);
		}
	}
}