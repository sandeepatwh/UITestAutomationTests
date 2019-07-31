
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
        public WebPages() => _driver = Browser.Driver;
        public LoginPage LoginPage => new LoginPage(_driver);
        public HomePage HomePage => new HomePage(_driver);
        public MyAccountPage MyAccountPage => new MyAccountPage(_driver);
        public CategoryPage CategoryPage => new CategoryPage(_driver);
        public SearchPage SearchPage => new SearchPage(_driver);
        public OrderPage OrderPage => new OrderPage(_driver);
    }

    public interface IWebPages
    {
        LoginPage LoginPage { get; }
        HomePage HomePage { get; }
        MyAccountPage MyAccountPage { get; }
        CategoryPage CategoryPage { get; }
        SearchPage SearchPage { get; }
        OrderPage OrderPage { get; }
    }
}
