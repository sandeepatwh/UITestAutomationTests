using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;


using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class SearchPage
    {
        private IWebDriver _driver;
        private  IList<IWebElement> TopSellerCount => _driver.FindElements(By.CssSelector("#best-sellers_block_right > div > ul > li"));
        private IWebElement TopSeller => _driver.FindElement(By.ClassName("product_list"));
        private IList<IWebElement> TopSellerProducts => TopSeller.FindElements(By.ClassName("ajax_block_product"));
        

        public SearchPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public int GetTopSellerCount()
        {
            return TopSellerCount.Count;

        }

        public void VerifySearchResult(int resultCount)
        {
            Assert.AreEqual(GetTopSellerCount(), GetBestSellerCount(), "Total number of items are different in 'Top Seller category' and 'Best Seller category'");
            _driver.Quit();
            _driver.Dispose();
        }

        private int GetBestSellerCount()
        {
            return TopSellerProducts.Count;            
        }
    }
}
