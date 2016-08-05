using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace M4W2
{
    public class AccountPanel
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'irinatest9@gmail.com')]")]
        public IWebElement accountTitleLink;
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'Logout')]")]
        public IWebElement logoutButton;
        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'irinatest9@gmail.com')]")]
        public IWebElement accountLable;
        [FindsBy(How = How.XPath, Using = "//div/a[contains(@href, 'mail')][1]")]
        public IWebElement mailLink;

        public AccountPanel(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Logoff()
        {
            accountTitleLink.Click();
            logoutButton.Click();
        }
        public MailPage NavigateMailPage()
        {
            mailLink.Click();
            return  new MailPage(_driver);
        }
        public void VerifyLogin()
        {
            Assert.AreEqual(true, accountLable.Displayed);
        }

    }
}