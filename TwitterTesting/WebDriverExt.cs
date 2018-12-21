using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTesting
{
    public static class WebDriverExt
    {
        public static WebDriverWait GetWait(this IWebDriver driver, int timeoutInSec)
            => new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSec));
    }
}
