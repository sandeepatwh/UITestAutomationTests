using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using UiAutomationFramework.Helper;
using How = SeleniumExtras.PageObjects.How;

namespace UiAutomationFramework.PageModels
{
    public class HomePage
    {
        IWebDriver _driver;

        private IWebElement SignIn => _driver.FindElement(By.CssSelector("a.login"));
        private IWebElement SearchTextBox => _driver.FindElement(By.Id("search_query_top"));
        private IWebElement SearchButton => _driver.FindElement(By.CssSelector("#searchbox > button"));

        private AppSettings _appSettings;
        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
            _appSettings = new AppSettings();
        }
        

        public HomePage ClickSignIn()
        {
            SignIn.Click();
            return this;
        }

        public HomePage OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_appSettings.BaseUrl);
            _driver.Manage().Window.Maximize();
            return this;
        }
        

        public void SearchItem(string searchString)
        {
            SearchTextBox.SendKeys(searchString);
            SearchButton.Click();
        }



    }
}
