using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
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
        
        public void LoginToWebSite(Table table)
        {
            dynamic t = table.CreateDynamicInstance();
            Email.Clear();
            Email.SendKeys(t.Email.ToString());
            Password.Clear();
            Password.SendKeys(t.Password.ToString());
            SignInButton.Click();
        }
    }
}
