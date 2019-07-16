using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UiAutomationFramework.Helper
{
    public class WebDriverExtensions
    {

        public static IWebElement WaitForElementToBePresent(IWebDriver _driver, IWebElement element)
        {
            return new WebDriverWait(_driver, TimeSpan.FromMilliseconds(20000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                            .ElementToBeClickable(element));
        }


    }
}
