using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UiAutomationFramework.Helper
{
   public class WebDriverExtensions
    {

        public static void WaitForElementByCssIsVisible(string css)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
        }

        public bool method()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromMilliseconds(2000));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("html-name")));
          //  NewMethod().SendKeys("John Doe");
            return true;
        }

        public static IWebElement WaitForElementToBePresent(IWebElement element)
        {
            return new WebDriverWait(Browser.Driver, TimeSpan.FromMilliseconds(20000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                            .ElementToBeClickable(element));
        }


    }
}
