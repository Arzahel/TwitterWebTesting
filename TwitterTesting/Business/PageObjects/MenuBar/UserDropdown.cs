using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTesting.PageObjects
{
    class UserDropdown : AbstractPage
    {
        public UserDropdown(IWebDriver driver, Log log) : base(driver, Log.GetLog()) { }

        [FindsBy(How = How.ClassName, Using = "js-signout-button")]
        public IWebElement signoutButton;

        public void SignOut() {
            Log.GetLog().Info("Logout");
            signoutButton.Click();
        }
    }
}
