using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class SearchPage
    {
        private IWebDriver _driver;

        public SearchPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public int GetTopSellerCount()
        {
            return _driver.FindElements(By.CssSelector("#best-sellers_block_right > div > ul > li")).Count;

        }

        internal void VerifySearchResult(int resultCount)
        {
            Assert.AreEqual(GetTopSellerCount(), GetBestSellerCount(), "Total number of items are different in 'Top Seller category' and 'Best Seller category'");
            _driver.Quit();
            _driver.Dispose();
        }

        private int GetBestSellerCount()
        {
            var TotalItemsOnLeftSideBar = _driver.FindElement(By.ClassName("product_list"));

            return TotalItemsOnLeftSideBar.FindElements(By.ClassName("ajax_block_product")).Count;            
        }
    }
}
