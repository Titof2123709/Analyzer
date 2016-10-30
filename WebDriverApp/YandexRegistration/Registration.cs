using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverApp.Models;

namespace WebDriverApp.YandexRegistration
{
    public class Registration: BaseControllerPage<FirefoxDriver>
    {
        public void Register()
        {
            //  driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0,1,0));
            try
            {
                LoginPage.LoginPageRedirectToRegistration();
                BaseWindowHandle = driver.CurrentWindowHandle;
                ProfilePage.LoadProfilePage();
                var userProfileModel = ProfilePage.GetFakeProfile();
                driver.SwitchTo().Window(BaseWindowHandle);
                var doNotHaveTelephoneLink = driver.FindElement(By.XPath(".//*[@class='human-confirmation-switch human-confirmation-via-captcha']"));
                doNotHaveTelephoneLink.Click();
                DropDownFieldChoise("Дата рождения бабушки");
                FillYandexProfile(userProfileModel);

                var newLogin = CheckLoginFree();
                if(newLogin != null)
                {
                    userProfileModel.Login = newLogin;
                }
                AllTabClosing(BaseWindowHandle);

                //((IJavaScriptExecutor)driver).ExecuteScript("var script = document.createElement('script'); script.type = 'text/javascript'; script.src = 'https://passport.yandex.ru/test.js'; window.document.head.appendChild(script)");

                // var login = (string)js.ExecuteScript("document.getElementById('nb - 5').addEventListener('click',function() {return true; }); ");

                for (;;)
                {
                    Task.Delay(2000); 
                    try
                    {
                        var someSuccess = driver.FindElement(By.XPath(".//*[@id='ID']"));
                        break;
                    }
                    catch(NoSuchElementException)
                    { }
                }

                new WebDriverWait(driver, new TimeSpan(24, 0, 0)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='nb-5']")));
                //var registrationSubmitButton = driver.FindElement(By.XPath(".//*[@id='nb-5']"));
                //registrationSubmitButton.Click();
                
            }
            catch (Exception ex)
            {
            }
        }

        public static void FillYandexProfile(YandexUserProfile yandexUserProfile)
        {
            IWebElement fieldName = null;
            IWebElement fieldSurname = null;
            IWebElement fieldLogin = null;
            IWebElement fieldPassword = null;
            IWebElement fieldPasswordConfirm = null;
            IWebElement fieldControllAnswer = null;

            try
            {
                fieldName = driver.FindElement(By.XPath(".//*[@id='firstname']"));
                fieldSurname = driver.FindElement(By.XPath(".//*[@id='lastname']"));
                fieldLogin = driver.FindElement(By.XPath(".//*[@id='login']"));
                fieldPassword = driver.FindElement(By.XPath(".//*[@id='password']"));
                fieldPasswordConfirm = driver.FindElement(By.XPath(".//*[@id='password_confirm']"));
                fieldControllAnswer = driver.FindElement(By.XPath(".//*[@id='hint_answer']"));

                fieldName.SendKeys(yandexUserProfile.Name);
                fieldSurname.SendKeys(yandexUserProfile.Surname);
                fieldLogin.SendKeys(yandexUserProfile.Login);
                fieldPassword.SendKeys(yandexUserProfile.Password);
                fieldPasswordConfirm.SendKeys(yandexUserProfile.Password);
                fieldControllAnswer.SendKeys(yandexUserProfile.Birthday);
            }
            catch (Exception ignore)
            {
                //Log
            }
        }

        public static string CheckLoginFree()
        {
            string newLogin = null;
            try
            {
                Task.Delay(2000);
               //  wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@class='login__ok control__valid']")));
                driver.FindElement(By.XPath(".//*[@class='login__ok control__valid']"));
            }
            //catch (TimeoutException)
            //{
            //}           
            catch (NoSuchElementException)
            {
                try
                {
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@class='login__suggestedLogin']")));
                }
                catch(TimeoutException)
                {
                    var registrationSubmitButton = driver.FindElement(By.XPath(".//*[@id='nb-5']"));
                    registrationSubmitButton.Click();
                }

                for (;;)
                {
                    try
                    {
                        var suggestedLogin = driver.FindElement(By.XPath(".//*[@class='login__suggestedLogin']"));
                        newLogin = suggestedLogin.Text;
                        break;
                    }
                    catch (StaleElementReferenceException)
                    {

                    }
                    catch (Exception ex)
                    {

                    }
                }
                var fieldLogin = driver.FindElement(By.XPath(".//*[@id='login']"));
                fieldLogin.Clear();
                fieldLogin.SendKeys(newLogin);
            }
            catch (Exception ignore)
            {
                //Log
            }

            return newLogin;
        }

        public static void DropDownFieldChoise(string fieldChoise)
        {
            if(string.IsNullOrEmpty(fieldChoise))
            {
                fieldChoise = "Дата рождения бабушки";
            }
            js.ExecuteScript("document.getElementsByName('hint_question_id')[1].setAttribute('class', '');");
            var dropDownSecretQuestion = driver.FindElements(By.Name("hint_question_id"))[1];
            var selectElement = new SelectElement(dropDownSecretQuestion);
            selectElement.SelectByText(fieldChoise);
        }

        public static void AllTabClosing(string baseWindowHandle)
        {
            foreach (var handle in driver.WindowHandles)
            {
                if (handle != baseWindowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    driver.Close();
                }
            }
            driver.SwitchTo().Window(baseWindowHandle);
        }

    }
}
