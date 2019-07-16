using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class OrderPage
    {
        private readonly IWebDriver _driver;
        private IWebElement _element;

        public Actions actions { get => new Actions(_driver); }

        public OrderPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToShoppingCart()
        {
            _element = _driver.FindElement(By.XPath("//*[@class='shopping_cart']/a"));
            string url = _element.GetAttribute("href");
            _driver.Navigate().GoToUrl(url);
        }

        public void ProceedCheckoutFromOrderSummaryPage()
        {
            _element = _driver.FindElement(By.XPath(
                "//*[@class='cart_navigation clearfix']//a[@class='button btn btn-default standard-checkout button-medium']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", _element);
            WebDriverExtensions.WaitForElementToBePresent(_driver, _element).Click();
        }

        public void ProceedToCheckoutPageFromAddressPage()
        {
            _element = _driver.FindElement(By.Name("processAddress"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", _element);
            WebDriverExtensions.WaitForElementToBePresent(_driver, _element).Click();
        }

        public void ProceedToCheckOutFromShippingPage()
        {
            _element = _driver.FindElement(By.Id("cgv"));
            if (!_element.Selected)
            {
                _element.Click();
            }
            _element = _driver.FindElement(By.Name("processCarrier"));
            WebDriverExtensions.WaitForElementToBePresent(_driver, _element).Click();
        }
             
   
        public void PayByBankWire()
        {
            IWebElement bankWirePayment = _driver.FindElement(By.CssSelector("a.bankwire > span"));
            bankWirePayment.Click();
        }

        public void ConfirmOrder()
        {
            ICollection<IWebElement> buttons = _driver.FindElements(By.CssSelector("#cart_navigation > button > span"));
            foreach (IWebElement button in buttons)
            {
                try
                {
                    if (button.Text.Contains("I confirm my order"))
                    {
                        button.Click();
                    }
                }
                catch (NoSuchElementException)
                {

                }
            }
        }

        public string ReturnOrderConfirmationMessage()
        {
          return  WebDriverExtensions.WaitForElementToBePresent(_driver, _driver.FindElement(By.CssSelector("#center_column > div > p > strong"))).Text;
        }
    }
}
