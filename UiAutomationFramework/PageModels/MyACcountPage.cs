using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;


namespace UiAutomationFramework.PageModels
{
    public class MyAccountPage
    {
        private IWebDriver _driver;

        public MyAccountPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToWomenSetion()
        {
            IList<IWebElement> categories = _driver.FindElements(By.CssSelector("a.sf-with-ul"));
            IWebElement womenCategory = categories[0];
            womenCategory.Click();
        }

    }
}
