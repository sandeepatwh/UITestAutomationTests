using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class HomePage
    {
         //[FindsBy(How = How.CssSelector, Using = "a.login")]
        //private IWebElement SignIn { get; set; }

        public HomePage ClickSignIn()
        {
            Browser.Driver.FindElement(By.CssSelector("a.login")).Click();
            return this;
        }

        public HomePage OpenHomePage()
        {
          //Browser.Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["TestUrl"]);//
            Browser.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Browser.Driver.Manage().Window.Maximize();
            return this;
        }



    }
}
