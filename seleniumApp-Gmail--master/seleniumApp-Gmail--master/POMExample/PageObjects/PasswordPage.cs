using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using POMExample.BusinessObjects;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;

namespace POMExample.PageObjects
{
    class PasswordPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
       
        public PasswordPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@type='password']")]
        private IWebElement _passwordFieldElement;

        [FindsBy(How = How.XPath, Using = "//div[@id='passwordNext']")]
        private IWebElement _nextButtElement;

        public ChooseGmilPage GoToMidPage(string password)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_nextButtElement));
            _wait.Until(ExpectedConditions.ElementToBeClickable(_passwordFieldElement));

            ElementIsExist elementIsExist = new ElementIsExist();
            if (elementIsExist.IsElementPresent(By.XPath(".//*[@type='password']"),_driver ) && elementIsExist.IsElementPresent(By.XPath("//div[@id='passwordNext']"), _driver))
            {
                _passwordFieldElement.SendKeys(password);
                System.Threading.Thread.Sleep(1000);
                _driver.SwitchTo().DefaultContent();
                _nextButtElement.Click();
                return new ChooseGmilPage(_driver);
            }

            return null;
        }        
    }
}