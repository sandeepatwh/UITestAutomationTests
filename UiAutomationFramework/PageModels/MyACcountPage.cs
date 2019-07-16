using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class MyAccountPage
    {
        private IWebDriver _driver;

        public MyAccountPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void GoToWomenSetion()
        {
            IList<IWebElement> categories = _driver.FindElements(By.CssSelector("a.sf-with-ul"));
            IWebElement womenCategory = categories[0];
            womenCategory.Click();
        }

    }
}
