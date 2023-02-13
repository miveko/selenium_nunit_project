using NUnit.Framework;
using OpenQA.Selenium;
using AppGreatSelenium.PageElements;
using AppGreatSelenium.NonPageObjects;
using static AppGreatSelenium.PageElements.LoginPageElements;

namespace AppGreatSelenium.Pages
{
    internal class LoginPage
    {
        private IWebDriver _driver;
        private User _user;

        public LoginPage(IWebDriver driver, User user)
        {
            _driver = driver;
            _user = user;
            new LoginPageElements(_driver);
        }
        public void LoadPage()
        {
            _driver.Url = "https://www.fortrade.com/";
        }

        public void DoLoginAndLogout(String realAccountOrEmail)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            try {
                _btn_close.Click(); //Closing the notification pop-up if appeard
            } catch (Exception ex) { }
            
            _btn_Login.Click();
            _inputTxt_AccountName.SendKeys(realAccountOrEmail);
            _inputTxt_Password.SendKeys(_user.Password);
            _btn_LoginSubmit.Click();
            try
            {
                Assert.AreEqual(label_RealAccount.Text, _user.RealAccount);
                _labelBtn_Logout.Click();
            }
            catch (Exception e)
            {   //Elements might have been reloaded
                Assert.AreEqual(label_RealAccount.Text, _user.RealAccount);
                _labelBtn_Logout.Click();
            }
        }
    }
}
