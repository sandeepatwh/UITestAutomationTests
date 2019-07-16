using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class CategoryPage
    {
        private IWebDriver _driver;

        public CategoryPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public Actions actions { get => new Actions(_driver); }

        public void AddSingleItemToTheCart()
        {
            var element = _driver.FindElement(By.CssSelector("ul.product_list.grid.row"));
            actions.MoveToElement(element).Perform();
            
            WebDriverExtensions.WaitForElementToBePresent(_driver, _driver.FindElement(By.CssSelector("div.product-container")));

            IList<IWebElement> productContainers = _driver.FindElements(By.CssSelector("div.product-container"));
            foreach (var product in productContainers)
            {
                IWebElement ele = product.FindElement(By.ClassName("product_img_link"));
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", ele);
                if (ele.GetAttribute("title") == "Printed Summer Dress")
                {
                    string url = ele.GetAttribute("href");
                    _driver.Navigate().GoToUrl(url);
                    break;
                }
            }

            AddItemToCart();

            IWebElement ProceedToCheckOut = WebDriverExtensions.WaitForElementToBePresent(_driver, _driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a/span")));
            ProceedToCheckOut.Click();
        }


        public void AddItemToCart()
        {
            _driver.FindElement(By.XPath("//*[@id='add_to_cart']/button")).Click();          
        }

    }
}
