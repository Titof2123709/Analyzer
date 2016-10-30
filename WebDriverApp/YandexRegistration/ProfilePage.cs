using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverApp.Models;

namespace WebDriverApp.YandexRegistration
{
    public class ProfilePage : BaseControllerPage<FirefoxDriver>
    {
        public static void LoadProfilePage()
        {
            js.ExecuteScript(string.Format("window.open('{0}', '_blank');", "http://randus.ru/"));
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static YandexUserProfile GetFakeProfile()
        {
            YandexUserProfile userProfModel = null;
            try
            {
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@class='form-control']")));
                var FIOElement = driver.FindElement(By.XPath(".//*[@class='form-control']"));
                var FIO = (string)js.ExecuteScript("return document.getElementsByClassName('form-control')[0].value");
                var fio = FIO.Split(' ');
                var login = (string)js.ExecuteScript("return document.getElementsByName('login')[0].value");
                var password = (string)js.ExecuteScript("return document.getElementsByName('pass')[0].value");
                var birthdayGranny = (string)js.ExecuteScript("return document.getElementsByName('date')[0].value");

                userProfModel = new YandexUserProfile()
                {
                    Name = fio[1],
                    Surname = fio[0],
                    Login = login,
                    Password = password,
                    Birthday = birthdayGranny
                };

            }
            catch (Exception ignore)
            {
                //Log
            }

            return userProfModel;
        }

    }
}