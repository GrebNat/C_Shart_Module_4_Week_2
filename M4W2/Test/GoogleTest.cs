using System;
using System.Threading;
using M4W2.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using M4W2.Util;
using static M4W2.Util.Properties;

namespace M4W2.Test
{
    [TestFixture]
    class GoogleTest
    {
        public IWebDriver driver;

        public static Mail[] testMail =
        {
            new Mail("koshka@ru.ru", "Привет! Я Клара!", "For you")
        };

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://google.com");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        [Test, TestCaseSource("testMail")]
        public void VerifyMailSentCorrectly(Mail mail)
        {
            AccountPanel accountPanel = new AccountPanel(driver);

            new MainPage(driver).Login(email, password);
            accountPanel.VerifyLogin();

            accountPanel
                    .NavigateMailPage()
                    .CreateNewMail(mail)
                    .CloseMailDialog()
                    .VerifyMailPresentInDraftFolder(mail)
                    .VerifyMailContentInDraftFolder(mail)
                    .SendMail()
                    .VerifyMailPresentInDraftFolder(mail)
                    .VerifyMailPresentInSentFolder(mail);

            accountPanel.Logoff();
        }

        [TearDown]
        public void teardown()
        {
            driver.Quit();
        }
    }
}
