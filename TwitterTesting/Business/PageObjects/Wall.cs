using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTesting.PageObjects
{
    class Wall : AbstractPage
    {
        public Wall(IWebDriver driver, Log log) : base(driver, Log.GetLog()) { }

        [FindsBy(How = How.Id, Using = "tweet-box-global")]
        public IWebElement tweetBox;

        [FindsBy(How = How.XPath, Using = "//div[@id='global-tweet-dialog']//button[contains(@class, 'tweet-action')]")]
        public IWebElement replyButton;

        public void FirstTweetComment(Credentials user, Credentials follower, int key)
        {
            _log.Info("Trying to add comment to the first tweet on the wall");

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.XPath(".//button[@data-modal='ProfileTweet-reply']")).Click();
            tweetBox.SendKeys(key.ToString());
            replyButton.Click();
            
            _driver.GetWait(20).Until(GetTweetSentCondition(follower.GetID()));
        }

        Func<IWebDriver, IWebElement> GetTweetSentCondition(string id) =>
            wd => wd.FindElement(By.XPath($".//span[contains(text(),'Ваш твит пользователю @{id} отправлен!')]"));
        Func<IWebDriver, IWebElement> GetTweetSentCondition(int key) =>
            wd => wd.FindElement(By.XPath("//*[contains(text(), '" + key.ToString() + "')]"));
    }
}
