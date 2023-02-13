using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AppGreatSelenium.Pages;
using AppGreatSelenium.NonPageObjects;

namespace AppGreatSelenium.Tests
{
    internal class RegisterLoginTest
    {
        private IWebDriver _driver;
        private User _user = new User();

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
        }


        [Test, Order(1)]
        public void Register_Positive_01()
        {
            RegisterPage registerPage = new RegisterPage(_driver, _user);
            registerPage.LoadPage();
            _user.Country = registerPage.FirstStep();
            registerPage.SecondStep();
            registerPage.SelectBroker();
            registerPage.ThirdStep();
            registerPage.ForthStep();
            registerPage.FifthStep();
            registerPage.SixthStep();
            registerPage.CompleteRegistration();
            ShowUserDetails();
        }
        private void ShowUserDetails()
        {
            Console.WriteLine("_user.Email: " + _user.Email);
            Console.WriteLine("_user.Password: " + _user.Password);
            Console.WriteLine("_user.RealAccount: " + _user.RealAccount);
        }

        [Test, Order(2)]
        public void LoggingWithRealAccount_Positive_01()
        {
            LoginPage loginPage = new LoginPage(_driver, _user);
            loginPage.LoadPage();
            Assert.Positive(_user.RealAccount.Length);
            loginPage.DoLoginAndLogout(_user.RealAccount);
        }

        [Test, Order(3)]
        public void LoggingWithEmail_Positive_01()
        {
            LoginPage loginPage = new LoginPage(_driver, _user);
            loginPage.LoadPage();
            Assert.Positive(_user.Email.Length);
            loginPage.DoLoginAndLogout(_user.Email);
        }


        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
