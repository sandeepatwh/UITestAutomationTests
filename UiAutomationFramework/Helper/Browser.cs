using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UiAutomationFramework.Helper
{
    public class Browser
    {
        public static IWebDriver Driver { get; private set; }

        public static void Initialize()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public static void TakeErrorScreenShot(string title)
        {
            var timestamp = DateTime.Now.ToString("dd-MMM-yyyy hh.mm.ss");
            var currentDir = "C:\\Temp";
            const string folderName = "\\UITestErrorScreenshots";
            Directory.CreateDirectory(currentDir + folderName);
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(currentDir + folderName + "\\" + title + " - " + timestamp + ".png", ScreenshotImageFormat.Png);
        }
    }
}
