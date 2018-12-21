using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTesting.PageObjects
{
    class LoginPage : AbstractPage
    {
        private IWebDriver driver;
        private Log _log = Log.GetLog();

        public LoginPage(IWebDriver driver, Log log) : base(driver, log) { }

        [FindsBy(How = How.ClassName, Using = "StaticLoggedOutHomePage-input")]
        public IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'js-username-field')]")]
        public IWebElement usernameField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'js-password-field')]")]
        public IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement submitButton;

        public void LogIn(Credentials user)
        {
            _log.Info("Trying to log in");
            loginButton.Click();
            usernameField.SendKeys(user.GetLogin());
            passwordField.SendKeys(user.GetPassword());
            submitButton.Click();
        }
    }
}
