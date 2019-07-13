using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UiAutomationFramework.Helper
{
    public class BaseTest
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (Browser.Driver == null || ((RemoteWebDriver)Browser.Driver).SessionId == null)
                Browser.Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(1000);
            Browser.Driver.Quit();
            Browser.Driver.Dispose();
        }
    }
}
