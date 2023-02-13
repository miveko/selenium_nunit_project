using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AppGreatSelenium.PageElements;
using AppGreatSelenium.NonPageObjects;
using static AppGreatSelenium.PageElements.RegisterPageElements;

namespace AppGreatSelenium.Pages
{
    internal class RegisterPage
    {
        private IWebDriver _driver;
        private User _user;

        public RegisterPage(IWebDriver driver, User user)
        {
            _driver = driver;
            _user = user;
            new RegisterPageElements(_driver);
        }
        public void LoadPage()
        {
            _driver.Url = "https://www.fortrade.com/create-user/?tg=skip&tag1=break&G_GEO=9075129";
            //_driver.Manage().Window.Maximize();
        }

        public String FirstStep()
        {            
            _inputTxt_FirstName.Clear();
            _inputTxt_FirstName.SendKeys(_user.FirstName);
            _inputTxt_LastName.Clear();
            _inputTxt_LastName.SendKeys(_user.LastName);
            _inputTxt_Email.Clear();
            _inputTxt_Email.SendKeys(_user.Email);
            Dictionary<String, Object> phoneData = DataPicker.GetRandomObject("PhoneNumbers");
            _inputTxt_PhoneCountryCode.Clear();
            _inputTxt_PhoneCountryCode.SendKeys((string)phoneData["CountryPhoneCode"]);
            _inputTxt_Phone.Clear();
            phoneData["Phone"] += DataPicker.GenerateRandomString(8, "0123456789");
            _inputTxt_Phone.SendKeys((string)phoneData["Phone"]);
            _inputBtn_BtnNext.Click();
            return (string)phoneData["Country"];
        }

        public void SecondStep()
        {
            SelectElement select = new SelectElement(_select_Country);
            for (int i = 0; i < select.Options.Count; i++)
            {
                if (select.Options.ElementAt(i).Text.Equals(_user.Country))
                {
                    select.SelectByIndex(i);
                    break;
                }
            }

            Console.WriteLine("_user.Country: " + _user.Country);
            Dictionary<String, Object> addressData = DataPicker.GetRandomObject("ResAddresses_" + _user.Country);
            _inputTxt_Address.Clear();
            _inputTxt_Address.SendKeys((string)addressData["Address"]);
            _inputTxt_City.Clear();
            _inputTxt_City.SendKeys((string)addressData["City"]);
            _inputTxt_PostalCode.Clear();
            _inputTxt_PostalCode.SendKeys((string)addressData["Postal Code"]);
            
            if (_driver.FindElements(By.Id("vwo-engage-alert-box-title")).Count != 0)                
                _btn_close.Click(); //Closing the notification promt pop-up if appeard 
        

            _inputBtn_BtnNext2.Click();
        }

        public void SelectBroker()
        {
            if(!_user.Country.Equals("United Kingdom"))
            {                
                _radioBtn_Fortrade.Click();
                _inputBtn_RegNext.Click();
            }
        }

        public void ThirdStep()
        {
            Dictionary<String, Object> currencyData = DataPicker.GetRandomObject("Currencies");
            SelectElement select = new SelectElement(_select_Currency);
            for (int i = 0; i < select.Options.Count; i++)
            {
                if (select.Options.ElementAt(i).Text.Equals(currencyData["Currency"]))
                {
                    select.SelectByIndex(i);
                    break;
                }
            }

            eye.Click();
            _inputTxt_Password.SendKeys("KjHkj5s");
            Random rndGen = new Random();
            select = new SelectElement(_inputTxt_DateOfBirthDay);
            select.SelectByIndex(rndGen.Next(1, 29));
            select = new SelectElement(_inputTxt_DayOfMonth);
            select.SelectByIndex(rndGen.Next(1, 13));
            select = new SelectElement(_inputTxt_DateOfBirth);
            select.SelectByIndex(rndGen.Next(1901, 2004) - 1900);
            _inputBtn_BtnStep4Next.Click();
        }
        
        public void ForthStep()
        {
            SelectElement select = new SelectElement(_select_EmploymentStatus);
            select.SelectByText("Employed", true);
            select = new SelectElement(_select_EstimatedAnnualIncome);
            select.SelectByIndex(2);
            try
            {   //Disabled for some coutnries
                select = new SelectElement(_select_SourceofFunds);
                select.SelectByIndex(1);
                select = new SelectElement(_select_ValueOfSavingAndInvestments);
                select.SelectByIndex(1);
                select = new SelectElement(_select_InvestmentObjectives);
                select.SelectByIndex(1);
            } catch (Exception ex)
            {
                Console.WriteLine("Dropdowns disabled");
            }

            _inputBtn_BtnStep5Next.Click();
        }

        public void FifthStep()
        {
            try
            {   //Disabled for some coutnries
                SelectElement select = new SelectElement(_select_KnowledgeOfTrading);
                select.SelectByIndex(1);
                select = new SelectElement(_select_TradingExperience);
                select.SelectByIndex(2);
                select = new SelectElement(_select_FrequencyOfTrades);
                select.SelectByIndex(3);
                select = new SelectElement(_select_OtherTradingExperience);
                select.SelectByIndex(4);
                select = new SelectElement(_select_FrequencyOtherTradingExperience);
                select.SelectByIndex(3);
                _select_BtnStep7Next.Click();
            }
            catch (Exception ex) { }
        }

        public void SixthStep()
        {
            try
            {   //Disabled for some countries
                _chckBox_IhaveReadRiskWarning.Click();  
            } catch (Exception ex) { }

            _chckBox_IacceptTermsAgreement.Submit();
        }

        public void CompleteRegistration()
        {
            List<String> tabs = new List<String>(_driver.WindowHandles);
            while(tabs.Count < 2) {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                tabs = new List<String>(_driver.WindowHandles);
            }

            //Switch to newly opened tab
            _driver.SwitchTo().Window(tabs.ElementAt(1));
            //wait for the credential box to appear
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            By credentialBox = By.CssSelector("div[class='credetialsBox']");
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(credentialBox));
            //Extract Email and password from it (not asked by the assignment
            _user.Email = _label_Email.Text;
            _user.Password = _label_tempPassword.Text;
            btn_continue.Click();
            _driver.Close();
            //switch back to main tab
            _driver.SwitchTo().Window(tabs.ElementAt(0));

            //Extract the Real Account number
            _user.RealAccount = lable_RealAccount.Text;
            Assert.Positive(_user.RealAccount.Length);

            //Asserting the url path and query param
            Assert.True(_driver.Url.EndsWith("/my-account/?regType=r"));
            lable_Logout.Click();
        }        
    }
}
