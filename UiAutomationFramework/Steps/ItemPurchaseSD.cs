﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public sealed class ItemPurchaseSD : BaseTest
    {
        private readonly ScenarioContext context;
        HomePage _home;
        LoginPage _login;
        MyACcountPage _account;
        CategoryPage _category;
        OrderPage _order;


        public ItemPurchaseSD(ScenarioContext injectedContext)
        {
            context = injectedContext;
            _home = new HomePage();
            _login = new LoginPage();
            _account = new MyACcountPage();
            _category = new CategoryPage();
        }

        [Given(@"User navidates to login screen")]
        public void GivenUserNavidatesToLoginScreen()
        {
            _home.OpenHomePage().ClickSignIn();
        }


        [Given(@"User logins with following credentials")]
        public void GivenUserLoginsWithFollowingCredentials(Table table)
        {
            _login.LoginToWebSite(table);
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
            _order = new OrderPage(Browser.Driver);
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
        }
    }
}