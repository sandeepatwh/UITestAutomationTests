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
        public static IWebDriver Driver => GetDriver();
        
        //public static IWebDriver GetDriver()
        //{
        //    if (Driver == null)
        //    {
        //        return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        //    }

        //    else return Driver;
        //}

        public static IWebDriver GetDriver()
        {
            return new ChromeDriver(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName +
                                    "\\UiAutomationFramework\\Drivers");
        }



    }
}
