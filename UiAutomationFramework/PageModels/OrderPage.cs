using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
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
        private IWebElement GoToShoppingCardLink => _driver.FindElement(By.XPath("//*[@class='shopping_cart']/a"));
        private IWebElement ProceedCheckoutFromOrderSummaryPageLink => _driver.FindElement(By.XPath("//*[@class='cart_navigation clearfix']//a[@class='button btn btn-default standard-checkout button-medium']"));
        private IWebElement ProceedToCheckoutPageFromAddressPageLink => _driver.FindElement(By.Name("processAddress"));
        private IWebElement ProceedToCheckOutFromShippingPageLink => _driver.FindElement(By.Id("cgv"));
        private IWebElement processCarrierLink => _driver.FindElement(By.Name("processCarrier"));
        private IWebElement bankWirePaymentLink => _driver.FindElement(By.CssSelector("a.bankwire > span"));
        private ICollection<IWebElement> buttons => _driver.FindElements(By.CssSelector("#cart_navigation > button > span"));
        private IWebElement OrderConfirmationMessageLink => _driver.FindElement(By.CssSelector("#center_column > div > p > strong"));


        public OrderPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToShoppingCart()
        {
            _driver.Navigate().GoToUrl(GoToShoppingCardLink.GetAttribute("href"));
        }

        public void ProceedCheckoutFromOrderSummaryPage()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", ProceedCheckoutFromOrderSummaryPageLink);
            WebDriverExtensions.WaitForElementToBePresent(_driver, ProceedCheckoutFromOrderSummaryPageLink).Click();
        }

        public void ProceedToCheckoutPageFromAddressPage()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", ProceedToCheckoutPageFromAddressPageLink);
            WebDriverExtensions.WaitForElementToBePresent(_driver, ProceedToCheckoutPageFromAddressPageLink).Click();
        }

        public void ProceedToCheckOutFromShippingPage()
        {
            if (!ProceedToCheckOutFromShippingPageLink.Selected)
            {
                ProceedToCheckOutFromShippingPageLink.Click();
            }
            WebDriverExtensions.WaitForElementToBePresent(_driver, processCarrierLink).Click();
        }

        public void PayByBankWire()
        {
            bankWirePaymentLink.Click();
        }

        public void ConfirmOrder()
        {
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
            return WebDriverExtensions.WaitForElementToBePresent(_driver, OrderConfirmationMessageLink).Text;
        }
    }
}
