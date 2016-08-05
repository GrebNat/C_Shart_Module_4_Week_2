using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace M4W2
{
    public class LoginPage
    {
        public IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "Email")] public IWebElement accoutTextField;
        [FindsBy(How = How.Id, Using = "Passwd")] public IWebElement passwordTextField;
        [FindsBy(How = How.Id, Using = "next")] public IWebElement nextButton;
        [FindsBy(How = How.Id, Using = "signIn")] public IWebElement signInButton;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public MailPage Login(string user, string password)
        {
            accoutTextField.Clear();
            accoutTextField.SendKeys(user);

            nextButton.Click();

            Thread.Sleep(2000);
            passwordTextField.Clear();
            passwordTextField.SendKeys(password);

            signInButton.Click();

            return new MailPage(_driver);
        }
    }
}