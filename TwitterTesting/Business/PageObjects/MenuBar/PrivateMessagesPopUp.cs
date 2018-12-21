using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TwitterTesting.PageObjects
{
    class PrivateMessagesPopUp : AbstractPage
    {
        public PrivateMessagesPopUp(IWebDriver driver, Log log) : base(driver, log) { }

        [FindsBy(How = How.CssSelector, Using = ".DMActivity-close:nth-child(3) > .Icon")]
        public IWebElement closeIcon;

        public void SendPrivateMessage(Credentials user, Credentials follower, int key)
        {
            _driver.FindElement(By.XPath("//li[.//*[contains(text(), '" + follower.GetName() + "')]]")).Click();
            _driver.FindElement(By.ClassName("DMComposer-editor")).SendKeys(key.ToString());
            _driver.FindElement(By.ClassName("DMComposer-send")).Click();
            _driver.Navigate().Refresh();
            //closeIcon.Click();
        }
    }
}
