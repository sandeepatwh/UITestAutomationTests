
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UiAutomationFramework.PageModels;

namespace UiAutomationFramework.Helper
{
   public class WebPages : IWebPages
    {
        private readonly IWebDriver _driver;
        public WebPages()
        {
            _driver = Browser.Driver;
        }

        public LoginPage LoginPage
        {
            get => new LoginPage(_driver);
            set => new LoginPage(_driver);
        }

        public HomePage HomePage
        {
            get => new HomePage(_driver);
            set => new LoginPage(_driver);
        }


    }

    public interface IWebPages
    {
        LoginPage LoginPage { get; set; }
        HomePage HomePage { get; set; }

    }
}
