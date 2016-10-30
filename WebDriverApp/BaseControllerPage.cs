using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverApp
{
    public abstract class BaseControllerPage<T> where T : IWebDriver, new()
    {
        protected static IWebDriver driver;
        protected static IJavaScriptExecutor js;
        protected static WebDriverWait wait;
        protected static string BaseWindowHandle;

        protected BaseControllerPage()
        {
            driver = DriverInstance<T>.GetDriver;
            js = DriverInstance<T>.GetJavaScriptExecutor;
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
        }

        public static void LoadPage(string url, By waitXPath)
        {
            try
            {
                driver.Url = url;
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(waitXPath));
            }
            catch(TimeoutException)
            {

            }
            catch (NoSuchElementException)
            {

            }
            finally
            {

            }
        }

        public static void LoadPage(IWebElement elem, By waitXPath)
        {
            try
            {
                elem.Click();
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(waitXPath));
            }
            catch (TimeoutException)
            {

            }
            catch (NoSuchElementException)
            {

            }
            finally
            {

            }
        }

        public static void GoToPage(IWebElement button)
        {
            try
            {
                button.Click();
            }
            catch (NoSuchElementException)
            {

            }
            finally
            {

            }
        }
    }
}
