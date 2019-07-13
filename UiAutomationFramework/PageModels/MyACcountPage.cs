using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class MyACcountPage
    {   
        public void GoToWomenSetion()
        {
            IList<IWebElement> categories = Browser.Driver.FindElements(By.CssSelector("a.sf-with-ul"));
            IWebElement womenCategory = categories[0];
            womenCategory.Click();
        }

    }
}
