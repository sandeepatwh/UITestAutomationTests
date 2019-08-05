using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.Steps
{
    [Binding]
    public sealed class ItemPurchaseSD
    {
        private readonly IWebPages _pages;
        public ItemPurchaseSD(IWebPages pages) => _pages = pages;
        
        [Given(@"User navigates to login screen")]
        public void GivenUsernavigatesToLoginScreen()
        {
            _pages.HomePage.OpenHomePage().ClickSignIn();
        }

        [Given(@"User logins with following credentials")]
        public void GivenUserLoginsWithFollowingCredentials(Table table)
        {
            _pages.LoginPage.LoginToWebSite(table);
        }
        
        [When(@"User searches the website with (.*) criteria")]
        public void WhenUserSearchesTheWebsiteWithCriteria(string searchString)
        {
            _pages.HomePage.SearchItem(searchString);
        }

        [Then(@"Number of items appear as (.*) in Top Seller and Best Seller section")]
        public void ThenNumberOfItemsAppearAsInTopSellerAndBestSellerSection(int resultCount)
        {
            _pages.SearchPage.VerifySearchResult(resultCount);
        }
        
        [When(@"User select the category")]
        public void WhenUserSelectTheCategory()
        {
            _pages.MyAccountPage.GoToWomenSetion();
        }

        [When(@"User finishes adding single item in the cart")]
        public void WhenUserFinishesAddingSingleItemInTheCart()
        {
            _pages.CategoryPage.AddSingleItemToTheCart();
            _pages.OrderPage.GoToShoppingCart();
            _pages.OrderPage.ProceedCheckoutFromOrderSummaryPage();
            _pages.OrderPage.ProceedToCheckoutPageFromAddressPage();
            _pages.OrderPage.ProceedToCheckOutFromShippingPage();
        }
        
        [When(@"User places the order")]
        public void WhenUserPlacesTheOrder()
        {
            _pages.OrderPage.PayByBankWire();
            _pages.OrderPage.ConfirmOrder();
        }

        [Then(@"Order is successfuly placed")]
        public void ThenOrderIsSuccessfulyPlaced()
        {
            Assert.AreEqual("Your order on My Store is complete.", _pages.OrderPage.ReturnOrderConfirmationMessage());
        }
        
    }
}
