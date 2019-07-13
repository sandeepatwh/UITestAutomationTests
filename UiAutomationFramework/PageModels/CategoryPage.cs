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
        public Actions actions { get => new Actions(Browser.Driver); }

        public void AddSingleItemToTheCart()
        {
            var element = Browser.Driver.FindElement(By.CssSelector("ul.product_list.grid.row"));
            actions.MoveToElement(element).Perform();
            
            WebDriverExtensions.WaitForElementToBePresent(Browser.Driver.FindElement(By.CssSelector("div.product-container")));

            IList<IWebElement> productContainers = Browser.Driver.FindElements(By.CssSelector("div.product-container"));
            foreach (var product in productContainers)
            {
                IWebElement ele = product.FindElement(By.ClassName("product_img_link"));
                ((IJavaScriptExecutor)Browser.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", ele);
                if (ele.GetAttribute("title") == "Printed Summer Dress")
                {
                    string url = ele.GetAttribute("href");
                    Browser.Driver.Navigate().GoToUrl(url);
                    break;
                }
            }

            AddItemToCart();

            IWebElement ProceedToCheckOut = WebDriverExtensions.WaitForElementToBePresent(Browser.Driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a/span")));
            ProceedToCheckOut.Click();
        }


        public void AddItemToCart()
        {
            Browser.Driver.FindElement(By.XPath("//*[@id='add_to_cart']/button")).Click();          
        }

    }
}
