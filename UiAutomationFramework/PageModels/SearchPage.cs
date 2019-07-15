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
        public int GetTopSellerCount()
        {
            return Browser.Driver.FindElements(By.CssSelector("#best-sellers_block_right > div > ul > li")).Count;

        }

        internal void VerifySearchResult(int resultCount)
        {
            Assert.AreEqual(GetTopSellerCount(), GetBestSellerCount(), "Total number of items are different in 'Top Seller category' and 'Best Seller category'");
        }

        private int GetBestSellerCount()
        {
            var TotalItemsOnLeftSideBar = Browser.Driver.FindElement(By.ClassName("product_list"));

            return TotalItemsOnLeftSideBar.FindElements(By.ClassName("ajax_block_product")).Count;            
        }
    }
}
