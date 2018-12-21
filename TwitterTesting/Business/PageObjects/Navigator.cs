using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTesting.PageObjects
{
    class Navigator : AbstractPage
    {
        public Navigator(IWebDriver driver, Log _log) : base(driver, _log) { }

        public void OpenProfile(string profileID)
        {
            _driver.Navigate().GoToUrl("https://twitter.com/@" + profileID);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }
    }
}
