using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverApp
{
    public static class DriverInstance<T> where T : IWebDriver,new()
    { 
        private static readonly Lazy<IWebDriver> driver = new Lazy<IWebDriver>(() => new T());
        private static readonly Lazy<IJavaScriptExecutor> js = new Lazy<IJavaScriptExecutor>(() => (IJavaScriptExecutor)(GetDriver));

        static DriverInstance() { }

        public static IWebDriver GetDriver
        {
            get
            {
                return driver.Value;
            }
        }

        public static IJavaScriptExecutor GetJavaScriptExecutor
        {
            get
            {
                return js.Value;
            }
        }

    }
}
