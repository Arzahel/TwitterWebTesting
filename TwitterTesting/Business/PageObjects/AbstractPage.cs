using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TwitterTesting.PageObjects
{
    class AbstractPage
    {
        protected IWebDriver _driver;
        protected Log _log;

        public AbstractPage(IWebDriver driver, Log log)
        {
            _driver = driver;
            _log = log;
            PageFactory.InitElements(driver, this);
        }
        
        public virtual void VerifyPageOpened()
        {

        }

        public virtual void WaitForElement(string elXPath, int waitTimeInSec)
        {
            _driver.GetWait(waitTimeInSec).Until(ElemSearch(elXPath));
        }

        Func<IWebDriver, IWebElement> ElemSearch(string xpath) =>
            wd => wd.FindElement(By.XPath(xpath));
    }
}
