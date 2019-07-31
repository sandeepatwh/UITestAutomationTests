using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BoDi;
using TechTalk.SpecFlow;

namespace UiAutomationFramework.Helper
{
    [Binding]
    public class BaseTest
    {
        private readonly IObjectContainer _objectContainer;

        public BaseTest(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            RegisterTestDependencie();
        }

        private void RegisterTestDependencie()
        {
            _objectContainer.RegisterTypeAs<WebPages, IWebPages>();
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
