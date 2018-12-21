using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TwitterWebTesting
{
    class Program
    {

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://twitter.com");
            driver.Navigate().Refresh();

            driver.FindElement(By.XPath(".//*[@id='doc']/div/div/div/div/div/a")).Click();
            driver.FindElement(By.XPath(".//*[@id='page-container']/div/div/form/fieldset/div/input")).SendKeys(user1.GetLogin());
            driver.FindElement(By.XPath(".//input[contains(@class, 'js-password-field')]")).SendKeys(user1.GetPassword());
            driver.FindElement(By.XPath(".//*[@id='page-container']/div/div/form/div/button")).Click();

            driver.Close();
        }
    }
}
