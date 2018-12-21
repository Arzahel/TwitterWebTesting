using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using TwitterTesting.PageObjects;
using TwitterTesting.PageObjects.MenuBar;
using OpenQA.Selenium.Interactions;

namespace TwitterTesting
{
    [TestFixture]
    [Author("Deshchenya M. I.")]
    [Category("Web")]
    public class Suite
    {
        static Credentials user1 = new Credentials("Максим дещеня", "maksim.deshenya@mail.ru", "1234567890q", "Vot_Je_Lol");
        static Credentials user2 = new Credentials("Максим Дещеня Двойник", "@b7V2ziygQb3VfqM", "1234567890", "b7V2ziygQb3VfqM");
        IWebDriver driver = new ChromeDriver();
        Log _log;

        [OneTimeSetUp]
        [Description("Open tested website")]
        public void OpenTwitter()
        {
            _log = new Log();
            _log.Info(DateTime.Now.ToString());
            _log.Info("Open Twitter website");
            driver.Navigate().GoToUrl("https://twitter.com");

            LoginPage loginPage = new LoginPage(driver, _log);
            loginPage.LogIn(user1);
            //(driver as IJavaScriptExecutor).ExecuteScript("document.getElementsByClassName('Icon Icon--bird bird-topbar-etched')[0].remove();");
        }

        [OneTimeTearDown]
        [Description("Close tested website")]
        public void CloseBrowser()
        {
            _log.Info("Close browser\r\n");
            driver.Quit();
        }

        [Test]
        [Order(0)]
        [Description("Checks if simple tweet posts without problems")]
        public void TweetTest([Random(100000, 999999, 1)] int key)
        {
            _log.Info("Открытие окна твита");
            MenuBar menuBar = new MenuBar(driver, _log);
            menuBar.OpenTweetPopUp();
            _log.Info("Отправка твита");
            menuBar.TweetPopUp.SimpleTweet(key);

            driver.FindElement(By.XPath("//a[@data-element-term='tweet_stats']")).Click();
            Func<IWebDriver, IWebElement> cond = wd => wd.FindElement(By.XPath(".//p[contains(text(),'" + key.ToString() + "')]"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(wd => cond);
            Assert.That(driver.FindElement(By.XPath("//p[contains(text(),'" + key.ToString() + "')]")).Displayed);
        }

        [Test]
        [Order(1)]
        [Description("Checks if tweet with picture posts without problems")]
        public void TweetPictureTest([Random(100000, 999999, 1)] int key)
        {
            MenuBar menuBar = new MenuBar(driver, _log);
            menuBar.OpenTweetPopUp();
            menuBar.TweetPopUp.PictureTweet(key, @"C:\users\Habito\pictures\TestImage.png");
            driver.FindElement(By.XPath("//a[@data-element-term='tweet_stats']")).Click();

            Func<IWebDriver, IWebElement> cond = wd => wd.FindElement(By.XPath(".//p[contains(text(),'" + key.ToString() + "')]"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(wd => cond);
            Assert.That(driver.FindElement(By.XPath("//p[contains(text(),'" + key.ToString() + "')]")).Displayed);
        }

        [Test]
        [Order(2)]
        [Description("Checks if tweet with picture posts without problems")]
        public void CommentTest([Random(100000, 999999, 1)] int key)
        {
            FirstTweetComment(user1, user2, key);
            driver.FindElement(By.XPath(".//div[@class='js-tweet-text-container']")).Click();
            Assert.That(driver.FindElement(By.XPath(".//p[contains(text(),'" + key.ToString() + "')]")).Displayed);
        }

        [Test]
        [Order(3)]
        [Description("Checks if tweet with picture posts without problems")]
        public void PrivateMailTest([Random(100000, 999999, 1)] int key)
        {
            MenuBar menuBar = new MenuBar(driver, _log);
            menuBar.OpenPrivateMessagesPopUp().SendPrivateMessage(user1, user2, key);
            menuBar.OpenUserDropdown().SignOut();

            LoginPage loginPage = new LoginPage(driver, _log);
            loginPage.LogIn(user2);

            menuBar.OpenPrivateMessagesPopUp();
            //Func<IWebDriver, IWebElement> cond = wd => wd.FindElement(By.XPath("//p[contains(text(), '" + key.ToString() + "')]"));
            driver.GetWait(20).Until(GetTweetSentCondition(key));
            Assert.That(driver.FindElement(By.XPath("//p[contains(text(), '" 
                + key.ToString() + "')]")).Displayed);
        }

        //[Test]
        //[Order(2)]
        //[Description("Checks if tweet with picture posts without problems")]
        //public void TryToOpenFollower()
        //{
        //    driver.Navigate().GoToUrl("https://twitter.com/followers");
        //    driver.GetWait(20).Until(GetTweetSentCondition("//a[@data-original-title='Максим дещеня']"));
        //    driver.FindElement(By.XPath("//a[@data-original-title='Максим дещеня']"));
        //}

        public void FirstTweetComment(Credentials user, Credentials follower, int key)
        {
            _log.Info("Open follower page");
            Navigator goTo = new Navigator(driver, _log);
            goTo.OpenProfile(follower.GetID());
            
            Wall wall = new Wall(driver, _log);
            wall.FirstTweetComment(user, follower, key);
        }

        Func<IWebDriver, IWebElement> GetTweetSentCondition(string xpath) =>
            wd => wd.FindElement(By.XPath(xpath));
        Func<IWebDriver, IWebElement> GetTweetSentCondition(int key) =>
            wd => wd.FindElement(By.XPath("//*[contains(text(), '" + key.ToString() + "')]"));
    }
}
