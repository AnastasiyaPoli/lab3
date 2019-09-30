using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;


namespace POMExample.PageObjects
{
    class GmailPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
      
        public GmailPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@gh='cm']")]
        private IWebElement _сomposeButtElement;

        [FindsBy(How = How.XPath, Using = "//textarea")]
        private IWebElement _toFieldElement;

        [FindsBy(How = How.XPath, Using = "//input[@name = 'subjectbox']")]
        private IWebElement _toSubjectFieldElement;

        [FindsBy(How = How.XPath, Using = "//div[@role = 'textbox']")]
        private IWebElement _toTextFieldElement;

        [FindsBy(How = How.XPath, Using = "//div[@id = ':q7']")]
        private IWebElement _sendButtElement;

        [FindsBy(How = How.XPath, Using = "//img[@class = 'Ha']")]
        private IWebElement _closeSendButtElement;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'aim'][4]")]
        private IWebElement _sendedPartElement;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'aim'][5]")]
        private IWebElement _draftPartElement;

        [FindsBy(How = How.XPath, Using = "//span[@email = 'test@mail.com']")]
        private IWebElement _findedElement;

        public void ToCompose()
        {
            _wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            _wait.Until(ExpectedConditions.ElementToBeClickable(_сomposeButtElement));
            _сomposeButtElement.Click();
        }

        public void FillFields(string to, string subject, string text)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_toFieldElement));
            _toFieldElement.SendKeys(to);
            _wait.Until(ExpectedConditions.ElementToBeClickable(_toSubjectFieldElement));
            _toSubjectFieldElement.SendKeys(subject);
            _wait.Until(ExpectedConditions.ElementToBeClickable(_toTextFieldElement));
            _toTextFieldElement.SendKeys(text);
        }

        public void SendMessage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_sendButtElement));
            _sendButtElement.Click();
            System.Threading.Thread.Sleep(6666);
        }

        public void OpenSended()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_sendedPartElement));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _sendedPartElement.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public void CloseSend()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_closeSendButtElement));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _closeSendButtElement.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public void OpenDraft()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_draftPartElement));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _draftPartElement.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[7]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/table[1]/tr[1]/td[1]/div[2]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/div[3]")]
        private IWebElement _txtElement;
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[7]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[2]/div[3]")]
        private IWebElement _delElement;
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[7]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]")]
        private IWebElement _backElement;

        public void CheckAndDeleteSended(string from, string text)
        {
            System.Threading.Thread.Sleep(3222);
            string temp = "//span[@email = '" + from + "']";
           
            ReadOnlyCollection<IWebElement> a = _driver.FindElements(By.XPath(temp));
          
            for (int i = 0; i < a.Count(); i++)
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                _wait.Until(ExpectedConditions.ElementToBeClickable(a[i]));
                
                a[i].Click();
                System.Threading.Thread.Sleep(2048);
              
                if (_txtElement.Text == text)
                {
                    _wait.Until(ExpectedConditions.ElementToBeClickable(_delElement));
                    _delElement.Click();
                    System.Threading.Thread.Sleep(2048);
                    break;
                }
                else
                {
                    _wait.Until(ExpectedConditions.ElementToBeClickable(_backElement));
                    _backElement.Click();
                    System.Threading.Thread.Sleep(2048);
                }
            }
            System.Threading.Thread.Sleep(2048);
        }
        
    }
}
