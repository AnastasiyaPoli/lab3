using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMExample.PageObjects;
using System;
using System.Configuration;

namespace POMExample
{
    [TestFixture]
    [AllureNUnit]
    public class Lab3Gmail
    {
        private IWebDriver _driver;

        private string uuid;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestCase("anastasiyapolianska@gmail.com", "papa_america13")]
        [AllureTms("I'm a test")]
        [AllureTag("NUnit", "Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureSeverity(Allure.Commons.SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void Test1(params string[] parameters)
        {
            LogInPage logInPage = new LogInPage(driver: _driver);
            logInPage.GoToPage();
            PasswordPage passwordPage = logInPage.GoToPasswordPage(email: parameters[0]);
          
            ChooseGmilPage chooseMailPage = passwordPage.GoToMidPage(password: parameters[1]);

            GmailPage mailPage = chooseMailPage.GoToGmailPage();

            mailPage.ToCompose();
            mailPage.FillFields(to: ConfigurationSettings.AppSettings["toMail"], subject: ConfigurationSettings.AppSettings["toSubject"], text: ConfigurationSettings.AppSettings["toText"]);
            mailPage.SendMessage();
            mailPage.OpenSended();
            mailPage.CheckAndDeleteSended(@from: ConfigurationSettings.AppSettings["toMail"], text: ConfigurationSettings.AppSettings["toText"]);
        }

        [TestCase("anastasiyapolianska@gmail.com", "papa_america13")]
        [AllureTms("I'm a test")]
        [AllureTag("NUnit", "Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureSeverity(Allure.Commons.SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void Test2(params string[] parameters)
        {
            LogInPage logInPage = new LogInPage(driver: _driver);
            logInPage.GoToPage();
            PasswordPage passwordPage = logInPage.GoToPasswordPage(email: parameters[0]);

            ChooseGmilPage chooseMailPage = passwordPage.GoToMidPage(password: parameters[1]);

            GmailPage mailPage = chooseMailPage.GoToGmailPage();

            mailPage.ToCompose();
            mailPage.FillFields(to: ConfigurationSettings.AppSettings["toMail"], subject: ConfigurationSettings.AppSettings["toSubject"], text: ConfigurationSettings.AppSettings["toText"]);
            mailPage.CloseSend();
            mailPage.OpenDraft();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
