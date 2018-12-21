using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterTesting.PageObjects.MenuBar
{
    class TweetPopUp : AbstractPage
    {
        public TweetPopUp(IWebDriver driver, Log log) : base(driver, Log.GetLog()) { }

        [FindsBy(How = How.XPath, Using = "//*[@id='Tweetstorm-tweet-box-0']//div[@name='tweet']")]
        public IWebElement tweetBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='Tweetstorm-tweet-box-0']//span/button[@type='button']")]
        public IWebElement sendTweetBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='Tweetstorm-tweet-box-0']//input[@type='file']")]
        public IWebElement imageInput;

        public void SimpleTweet(int key)
        {
            tweetBox.SendKeys(key.ToString());
            sendTweetBtn.Click();
            //tweet loading
            try {
                WaitForElement("//span[contains(text(),'Ваш твит отправлен.')]", 15);
            } catch { }
            finally { }
        }

        public void PictureTweet(int key, string picturePath)
        {
            _log.Info("Отравка твита c картинкой");
            tweetBox.SendKeys(key.ToString());
            imageInput.SendKeys(picturePath);
            WaitForElement("//img[@class='ComposerThumbnail-image']", 15);
            sendTweetBtn.Click();
            //tweet loading
            try
            {
                WaitForElement("//span[contains(text(),'Ваш твит отправлен.')]", 20);
            }
            catch { _log.Info("Tweet not sended"); }
            finally { }
        }
    }
}
