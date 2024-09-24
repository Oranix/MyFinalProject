using AutomationFramework1.PageObjects;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAutomationFramework1.PageObjects
{
    internal class CheckoutCompletePage :BasePage
    {
        public CheckoutCompletePage(IWebDriver driver) : base(driver) { }

        public IWebElement FinishLabel => Driver.FindElement(By.CssSelector(".complete-header"));
        public IWebElement IsImageDisplayed => Driver.FindElement(By.CssSelector(".pony_express"));
        public IWebElement BacktoProductsButton => Driver.FindElement(By.CssSelector("#back-to-products"));

        public void PrintCheckoutFinishLabel()
        {
            PrintText(FinishLabel);
            Thread.Sleep(2000);
            Click(BacktoProductsButton);
        }

        [AllureStep("Check If image displays")]      //Step description 
        public bool IsFinish()
        {
            return IsImageDisplayed.Displayed ? true : false;
        }
    }
}
