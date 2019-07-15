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

        public HomePage ClickSignIn()
        {
            Browser.Driver.FindElement(By.CssSelector("a.login")).Click();
          //  SignIn.Click();
            return this;
        }

        public HomePage OpenHomePage()
        {
          //Browser.Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["TestUrl"]);//
            Browser.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
          //  Browser.Driver.Manage().Window.Maximize();
            return this;
        }

        //public void SearchItem(Table table)
        //{
        //    IWebElement SearchTextBox = Browser.Driver.FindElement(By.Id("search_query_top"));

        //    IWebElement SearchButton = Browser.Driver.FindElement(By.CssSelector("#searchbox > button"));

        //    dynamic t = table.CreateDynamicInstance();

        //    SearchTextBox.SendKeys(t.SearchString.ToString());
        //    SearchButton.Click();
        //}


        public void SearchItem(string searchString)
        {
            IWebElement SearchTextBox = Browser.Driver.FindElement(By.Id("search_query_top"));

            IWebElement SearchButton = Browser.Driver.FindElement(By.CssSelector("#searchbox > button"));

            SearchTextBox.SendKeys(searchString);
            SearchButton.Click();
        }



    }
}
