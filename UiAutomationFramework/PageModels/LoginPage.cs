using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UiAutomationFramework.Helper;

namespace UiAutomationFramework.PageModels
{
    public class LoginPage
    {


        //[FindsBy(How = How.Id, Using = "email")]
        //private IWebElement Email { get; set; }

        //[FindsBy(How = How.Id, Using = "passwd")]
        //private IWebElement Password { get; set; }

        //[FindsBy(How = How.Id, Using = "SubmitLogin")]
        //private IWebElement SignInButton { get; set; } 
         
        


        public void LoginToWebSite(Table table)
        {
            IWebElement Email = Browser.Driver.FindElement(By.Id("email"));
            IWebElement Password = Browser.Driver.FindElement(By.Id("passwd"));
            IWebElement SignInButton = Browser.Driver.FindElement(By.Id("SubmitLogin"));

            dynamic t = table.CreateDynamicInstance();
            Email.Clear();
            Email.SendKeys(t.Email.ToString());
            Password.Clear();
            Password.SendKeys(t.Password.ToString());
            SignInButton.Click();
        }


    }
}
