using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using POMExample.BusinessObjects;

namespace POMExample.PageObjects
{
    class LogInPage
    {

        private IWebDriver _driver;

        public LogInPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@type='email']")]
        private IWebElement _emailFieldElement;

        [FindsBy(How = How.XPath, Using = "//span[. = 'Next']")]
        private IWebElement _nextButtElement;

        public void GoToPage()
        {
            _driver.Url =
                "https://accounts.google.com/ServiceLogin/signinchooser?hl=en-gb&flowName=GlifWebSignIn&flowEntry=AddSession";
        }

        public PasswordPage GoToPasswordPage(string email)
        {
            EmailValidation emailValidation = new EmailValidation();
            ElementIsExist elementIsExist = new ElementIsExist();

            if (emailValidation.IsValidEmail(email))
            {
                if (elementIsExist.IsElementPresent(By.XPath("//span[. = 'Next']"),_driver))
                {
                    _emailFieldElement.SendKeys(email);
                    _nextButtElement.Click();
                    return new PasswordPage(_driver);
                }

                return null;
            }

            return null;

        }
    }
}

