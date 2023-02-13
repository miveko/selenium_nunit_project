using OpenQA.Selenium;

namespace AppGreatSelenium.PageElements
{
    internal class LoginPageElements
    {
        public static IWebDriver _driver;
        public LoginPageElements(IWebDriver driver)
        {
            _driver = driver;
        }

        internal static IWebElement _btn_close
        {
            get => _driver.FindElement(By.CssSelector("button" +
            "[class='pushcrew-chrome-style-notification-btn pushcrew-btn-close']"));
        }
        internal static IWebElement _btn_Login
        { get => _driver.FindElement(By.CssSelector("div[class='ftBtn secondary-btn headerLoginBtn']")); }
        //{ get => _driver.FindElement(By.CssSelector(".headerLoginBtn")); }
        internal static IWebElement _inputTxt_AccountName
        { get => _driver.FindElement(By.CssSelector("input[type='text'][placeholder='Trading Account/Email'][name='AccountName']")); }
        internal static IWebElement _inputTxt_Password
        { get => _driver.FindElement(By.CssSelector("input[type='password'][placeholder='Password'][name='Password']")); }
        internal static IWebElement _btn_LoginSubmit
        { get => _driver.FindElement(By.CssSelector("input[type='Submit'][name='LoginSubmit']")); }
        internal static IWebElement label_RealAccount
        { get => _driver.FindElement(By.CssSelector(".ascWelcomeTable:nth-child(2) tbody .ascUserDataText")); }
        internal static IWebElement _labelBtn_Logout
        { get => _driver.FindElement(By.CssSelector("span[class='headerLogout logout']")); }                                                    
    }
}
