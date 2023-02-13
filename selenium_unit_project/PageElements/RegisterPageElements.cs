using OpenQA.Selenium;

namespace AppGreatSelenium.PageElements
{
    internal class RegisterPageElements
    {
        public static IWebDriver _driver;
        public RegisterPageElements(IWebDriver driver)
        {
            _driver = driver;
        }

        internal static IWebElement _btn_close
        { 
            get => _driver.FindElement(By.CssSelector("button" +
            "[class='pushcrew-chrome-style-notification-btn pushcrew-btn-close']"));
        }

        //Used in public void FirstStep()
        internal static IWebElement _inputTxt_FirstName
        {   get => _driver.FindElement(By.Name("FirstName"));   }
        internal static IWebElement _inputTxt_LastName
        {   get => _driver.FindElement(By.Name("LastName"));    }
        internal static IWebElement _inputTxt_Email
        {   get => _driver.FindElement(By.Name("Email"));   }
        internal static IWebElement _inputTxt_PhoneCountryCode
        {   get => _driver.FindElement(By.Name("PhoneCountryCode"));   }
        internal static IWebElement _inputTxt_Phone
        {   get => _driver.FindElement(By.Name("Phone"));   }
        internal static IWebElement _inputBtn_BtnNext    
        {   get => _driver.FindElement(By.Name("BtnNext")); }


        //Used in public void SecondStep() & SelectBroker()
        internal static IWebElement _select_Country
        { get => _driver.FindElement(By.Name("Country")); }      
        internal static IWebElement _inputTxt_Address
        { get => _driver.FindElement(By.Name("Address")); }
        internal static IWebElement _inputTxt_City
        { get => _driver.FindElement(By.Name("City")); }
        internal static IWebElement _inputTxt_PostalCode
        { get => _driver.FindElement(By.Name("ZipCode"));}
        internal static IWebElement _inputBtn_BtnNext2
        { get => _driver.FindElement(By.Name("BtnNext2"));  }


        //Used in public void SelectBroker()
        internal static IWebElement _radioBtn_Fortrade
        { get => _driver.FindElement(By.XPath("//span[contains(.,'Fortrade Mauritius')]")); }
        internal static IWebElement _inputBtn_RegNext
        { get => _driver.FindElement(By.Name("BtnRegNext")); }


        //Used in public void ThirdStep()
        internal static IWebElement _select_Currency
        { get => _driver.FindElement(By.Name("Currency")); }
        internal static IWebElement eye
        {
            get => _driver.FindElement(By.CssSelector("span[style='display: none;']" +
                "[class='FullUserRegistrationWidget-passwordToggle hidePassword']"));
        }
        internal static IWebElement _inputTxt_Password
        { get => _driver.FindElement(By.CssSelector("input[type='text'][placeholder='*Password'][name='Password']")); }
        internal static IWebElement _inputTxt_DateOfBirthDay
        { get => _driver.FindElement(By.Name("DateOfBirthDay")); }
        internal static IWebElement _inputTxt_DayOfMonth
        { get =>  _driver.FindElement(By.Name("DateOfBirthMonth")); }
        internal static IWebElement _inputTxt_DateOfBirth
        { get => _driver.FindElement(By.Name("DateOfBirth")); }
        internal static IWebElement _inputBtn_BtnStep4Next
        { get => _driver.FindElement(By.Name("BtnStep4Next")); }


        //Used in public void ForthStep()
        internal static IWebElement _select_EmploymentStatus
        { get => _driver.FindElement(By.Name("EmploymentStatus")); }
        internal static IWebElement _select_EstimatedAnnualIncome
        { get => _driver.FindElement(By.Name("EstimatedAnnualIncome")); }
        internal static IWebElement _select_SourceofFunds
        { get => _driver.FindElement(By.Name("SourceofFunds")); }
        internal static IWebElement _select_ValueOfSavingAndInvestments
        { get => _driver.FindElement(By.Name("ValueOfSavingAndInvestments")); }
        internal static IWebElement _select_InvestmentObjectives
        { get => _driver.FindElement(By.Name("InvestmentObjectives")); }
        internal static IWebElement _inputBtn_BtnStep5Next
        { get => _driver.FindElement(By.Name("BtnStep5Next")); }


        //Used in public void FifthStep()
        internal static IWebElement _select_KnowledgeOfTrading
        { get => _driver.FindElement(By.Name("KnowledgeOfTrading")); }
        internal static IWebElement _select_TradingExperience
        { get => _driver.FindElement(By.Name("TradingExperience")); }
        internal static IWebElement _select_FrequencyOfTrades
        { get => _driver.FindElement(By.Name("FrequencyOfTrades")); }
        internal static IWebElement _select_OtherTradingExperience
        { get => _driver.FindElement(By.Name("OtherTradingExperience")); }
        internal static IWebElement _select_FrequencyOtherTradingExperience
        { get => _driver.FindElement(By.Name("FrequencyOtherTradingExperience")); }
        internal static IWebElement _select_BtnStep7Next
        { get => _driver.FindElement(By.Name("BtnStep7Next")); }


        //Used in public void SixthStep()
        internal static IWebElement _chckBox_IhaveReadRiskWarning
        { get => _driver.FindElement(By.CssSelector("label[class='checkboxItem FinancailQCheckbox']")); }
        internal static IWebElement _chckBox_IacceptTermsAgreement
        { get => _driver.FindElement(By.CssSelector("input[name='TermsAgreement'][type='checkbox'][tabindex='0'][data-lcerrorcode='1013']")); }
        internal static IWebElement _btn_Send
        { get => _driver.FindElement(By.Name("Send")); }

        //Used in public void CompleteRegistration()
        internal static IWebElement _label_Email
        { get => _driver.FindElement(By.Id("loginUserEmail")); }
        internal static IWebElement _label_tempPassword
        { get => _driver.FindElement(By.Id("tempPassword")); }
        internal static IWebElement btn_continue
        { get => _driver.FindElement(By.Id("startTradingButton")); }
        internal static IWebElement lable_RealAccount
        { get => _driver.FindElement(By.CssSelector(".ascWelcomeTable:nth-child(2) tbody .ascUserDataText")); }
        internal static IWebElement lable_Logout
        { get => _driver.FindElement(By.CssSelector(".headerLogout")); }
    }
}
