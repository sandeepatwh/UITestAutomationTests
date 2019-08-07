using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private IWebElement Email => _driver.FindElement(By.Id("email"));
        private IWebElement Password => _driver.FindElement(By.Id("passwd"));
        private IWebElement SignInButton => _driver.FindElement(By.Id("SubmitLogin"));


        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginToWebSite(string userName, string password)
        {
            Email.Clear();
            Email.SendKeys(userName);
            Password.Clear();
            Password.SendKeys(password);
            SignInButton.Click();
        }
    }
}
