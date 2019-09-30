using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;

namespace POMExample.PageObjects
{
    class ChooseGmilPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ChooseGmilPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@data-pid, '23')]")]
        private IWebElement _gmailElement;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'gb_B')]")]
        private IWebElement _dashboardElement;

        public GmailPage GoToGmailPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_dashboardElement));
            System.Threading.Thread.Sleep(1000);

            _dashboardElement.Click();

            _wait.Until(ExpectedConditions.ElementToBeClickable(_gmailElement));
            System.Threading.Thread.Sleep(1000);

            _gmailElement.Click();
            System.Threading.Thread.Sleep(1000);

            var handler = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(handler);

            return new GmailPage(_driver);
        }
    }
}