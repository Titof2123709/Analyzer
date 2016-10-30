using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverApp.YandexRegistration
{
    public class LoginPage : BaseControllerPage<FirefoxDriver>
    {
        public static void LoginPageRedirectToRegistration()
        {
            LoadPage("https://mail.yandex.ru/", By.XPath(".//*[@class=' nb-button _nb-normal-button new-auth-form-button']"));
            var registrationLinkButton = driver.FindElement(By.XPath(".//*[@class=' nb-button _nb-normal-button new-auth-form-button']"));
        //    registrationLinkButton.Click();
            LoadPage(registrationLinkButton, By.XPath(".//*[@id='firstname']"));
        }

    }
}
