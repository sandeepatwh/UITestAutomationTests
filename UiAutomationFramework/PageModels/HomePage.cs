using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class HomePage
    {
        //[FindsBy(How = How.CssSelector, Using = "a.login")]
        //private IWebElement SignIn { get; set; }

        //  public IWebElement SignInButton => Browser.Driver.FindElement

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }


        IWebDriver _driver;
        public HomePage ClickSignIn()
        {
            _driver.FindElement(By.CssSelector("a.login")).Click();
          //  SignIn.Click();
            return this;
        }

        public HomePage OpenHomePage()
        {
            //Browser.Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["TestUrl"]);//
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            // Browser.Driver.Manage().Window.Maximize();
            return this;
        }



        public void SearchItem(string searchString)
        {
            IWebElement SearchTextBox = _driver.FindElement(By.Id("search_query_top"));

            IWebElement SearchButton = _driver.FindElement(By.CssSelector("#searchbox > button"));

            SearchTextBox.SendKeys(searchString);
            SearchButton.Click();
        }



    }
}
