using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework1.PageObjects
{
    internal class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; set; }
        public void fillText(IWebElement el, string text)  //Clear filed text AND fill area with text 
        {
            el.Clear();
            el.SendKeys(text);
            Thread.Sleep(1000);
        }

        public void Click(IWebElement el)
        {
            Thread.Sleep(2000);
            el.Click();
        }

        public void PrintText(IWebElement el)
        {
            Thread.Sleep(1000);
            Console.WriteLine(el.Text);
        }
        

    }
}
