using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TwitterTesting.PageObjects.MenuBar
{
    class MenuBar : AbstractPage
    {
        public TweetPopUp TweetPopUp;

        public MenuBar(IWebDriver driver, Log log) : base(driver, Log.GetLog()) {
            TweetPopUp = new TweetPopUp(_driver, _log);
        }

        [FindsBy(How = How.Id, Using = "global-new-tweet-button")]
        public IWebElement tweetButton;

        [FindsBy(How = How.ClassName, Using = "dm-nav")]
        public IWebElement messagesButton;

        [FindsBy(How = How.Id, Using = "user-dropdown")]
        public IWebElement userDropdown;

        //webdriwer in singletone
        //threadlocal

        public void OpenTweetPopUp() { tweetButton.Click(); }

        public PrivateMessagesPopUp OpenPrivateMessagesPopUp()
        {
            messagesButton.Click();
            Thread.Sleep(50);
            return new PrivateMessagesPopUp(_driver, Log.GetLog());
        }

        public UserDropdown OpenUserDropdown()
        {
            userDropdown.Click();
            Thread.Sleep(50);
            return new UserDropdown(_driver, Log.GetLog());
        }

        public override void VerifyPageOpened()
        {
            Assert.That(_driver.FindElement(By.ClassName("global-nav-inner")).Displayed);
        }
    }
}
