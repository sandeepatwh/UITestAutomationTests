using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class CategoryPage
    {
        private IWebDriver _driver;
        private IWebElement ProductListGrid => _driver.FindElement(By.CssSelector("ul.product_list.grid.row"));
        private IWebElement ProductListContainer => _driver.FindElement(By.CssSelector("div.product-container"));
        private IList<IWebElement> productContainers => _driver.FindElements(By.CssSelector("div.product-container"));
        private IWebElement AddToCart => _driver.FindElement(By.XPath("//*[@id='add_to_cart']/button"));
        private IWebElement ProcedToCheckOut => _driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a/span"));
      


        public CategoryPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public Actions actions { get => new Actions(_driver); }

        public void AddSingleItemToTheCart()
        {
            actions.MoveToElement(ProductListGrid).Perform();
            WebDriverExtensions.WaitForElementToBePresent(_driver, ProductListContainer);

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
            IWebElement ProceedToCheckOut = WebDriverExtensions.WaitForElementToBePresent(_driver, ProcedToCheckOut);
            ProceedToCheckOut.Click();
        }


        public void AddItemToCart()
        {
            AddToCart.Click();          
        }

    }
}
