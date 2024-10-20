using AutomationFramework1.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V126.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAutomationFramework1.PageObjects
{
    internal class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public IList<IWebElement> Products => Driver.FindElements(By.CssSelector(".inventory_item_name "));
        public IWebElement ItemPrice => Driver.FindElement(By.CssSelector(".inventory_details_price"));        
        public IWebElement ItemDescription => Driver.FindElement(By.CssSelector(".inventory_details_desc.large_size"));
        public IWebElement ReturnToAllProductsPage => Driver.FindElement(By.CssSelector("#back-to-products"));
        public IWebElement IsImageDisplayed => Driver.FindElement(By.CssSelector(".inventory_details_img"));

        public void productPage(string product)
        {            
            foreach (var item in Products)
            {
                if (product.Equals(item.Text))
                {
                    Click(item);
                    break;
                }
            }


            PrintInfromation(ItemDescription);
            PrintInfromation(ItemPrice);                     
        }

        public bool ChecImageDisplayed()
        {
            return IsImageDisplayed.Displayed ? true : false;            
        }

        public void ReturntoAllProductsPage()
        {
            Click(ReturnToAllProductsPage);
        }
    }
}
