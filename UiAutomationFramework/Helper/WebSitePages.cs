using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UiAutomationFramework.Helper
{
   public class WebSitePages
    {
        public static T Page<T>()
        {
            var page = Activator.CreateInstance<T>();

           // PageFactory.InitElements(Browser.Driver, page);

            return page;
        }
    }
}
