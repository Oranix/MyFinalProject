using AutomationFramework1.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAutomationFramework1.PageObjects
{
    internal class CheckoutOverviewPage : BasePage
    {
        public CheckoutOverviewPage(IWebDriver driver) : base(driver) { }
     
        public IWebElement PaymantInfo => Driver.FindElement(By.CssSelector("[data-test='payment-info-label']"));
        public IWebElement PaymantValue => Driver.FindElement(By.CssSelector("[data-test='payment-info-value']"));
        public IWebElement ShippingInfo => Driver.FindElement(By.CssSelector("[data-test='shipping-info-label']"));
        public IWebElement ShippingValue => Driver.FindElement(By.CssSelector("[data-test='shipping-info-value']"));
        public IWebElement PriceTotal => Driver.FindElement(By.CssSelector("[data-test='total-info-label']"));
        public IWebElement ItemTotal => Driver.FindElement(By.CssSelector("[data-test='subtotal-label']"));
        public IWebElement TaxTotal => Driver.FindElement(By.CssSelector("[data-test='tax-label']"));
        public IWebElement Total => Driver.FindElement(By.CssSelector("[data-test='total-label']"));
        public IWebElement FinishBtn => Driver.FindElement(By.CssSelector("#finish"));
        public IWebElement LabelCheck => Driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > span"));
       
        public void ItemOverview()
        {
            PrintInfromation(PaymantInfo);
            PrintInfromation(PaymantValue);
            PrintInfromation(ShippingInfo);
            PrintInfromation(ShippingValue);
            PrintInfromation(PriceTotal);
            PrintInfromation(ItemTotal);
            PrintInfromation(TaxTotal);
            PrintInfromation(Total);
            PrintInfromation(FinishBtn);
        }
        public string IsLabelDisplay()
        {
            return PrintText(LabelCheck);
        }
    }
}
