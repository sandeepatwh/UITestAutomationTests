using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using UiAutomationFramework.Helper;
using UiAutomationFramework.PageModels;

namespace UiAutomationFramework.Steps
{
    [Binding]
    public sealed class ItemPurchaseSD
    {
        private readonly ScenarioContext context;
        HomePage _home;
        LoginPage _login;
        MyAccountPage _account;
        CategoryPage _category;
        OrderPage _order;
        SearchPage _search;
        IWebDriver _driver = Browser.Driver;
        WebPages _web;

        private readonly IWebPages _pages;

        public ItemPurchaseSD(IWebPages pages)
        {
            _pages = pages;
            //  context = injectedContext;
            _home = new HomePage(_driver);
            _login = new LoginPage(_driver);
            _account = new MyAccountPage(_driver);
            _category = new CategoryPage(_driver);
            _search = new SearchPage(_driver);
            _order = new OrderPage(_driver);
            _web = new WebPages();

        }

        [Given(@"User navidates to login screen")]
        public void GivenUserNavidatesToLoginScreen()
        {
            _pages.HomePage.OpenHomePage().ClickSignIn();
            
          //  _home.OpenHomePage().ClickSignIn();
        }


        [Given(@"User logins with following credentials")]
        public void GivenUserLoginsWithFollowingCredentials(Table table)
        {
            _login.LoginToWebSite(table);
        }



        [When(@"User searches the website with (.*) criteria")]
        public void WhenUserSearchesTheWebsiteWithCriteria(string searchString)
        {
            _home.SearchItem(searchString);
        }

        [Then(@"Number of items appear as (.*) in Top Seller and Best Seller section")]
        public void ThenNumverOfItemsAppearAsInTopSellerAndBestSellerSection(int resultCount)
        {
            _search.VerifySearchResult(resultCount);
        }



        [When(@"User select the category")]
        public void WhenUserSelectTheCategory()
        {
            _account.GoToWomenSetion();
        }

        [When(@"User finishes adding single item in the cart")]
        public void WhenUserFinishesAddingSingleItemInTheCart()
        {
            _category.AddSingleItemToTheCart();

            _order.GoToShoppingCart();
            _order.ProceedCheckoutFromOrderSummaryPage();
            _order.ProceedToCheckoutPageFromAddressPage();
            _order.ProceedToCheckOutFromShippingPage();
        }


        [When(@"User places the order")]
        public void WhenUserPlacesTheOrder()
        {
            _order.PayByBankWire();
            _order.ConfirmOrder();
        }

        [Then(@"Order is successfuly placed")]
        public void ThenOrderIsSuccessfulyPlaced()
        {
            Assert.AreEqual("Your order on My Store is complete.", _order.ReturnOrderConfirmationMessage());
            _driver.Quit();
            _driver.Dispose();
        }





    }
}
