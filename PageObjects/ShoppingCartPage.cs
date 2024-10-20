using AutomationFramework1.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAutomationFramework1.PageObjects
{
    internal class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver) { }

        public IWebElement ShopingCartBtn => Driver.FindElement(By.CssSelector("#shopping_cart_container"));
        public IWebElement CheckOutBtn => Driver.FindElement(By.CssSelector("#checkout"));
        public IWebElement ContinueShoppingBtn => Driver.FindElement(By.CssSelector("#continue-shopping"));
        public IWebElement LabelCheck => Driver.FindElement(By.CssSelector(".title"));
        public IList<IWebElement> ItemsInCartShop => Driver.FindElements(By.CssSelector(".inventory_item_name"));    
        public IWebElement ShopingCartIconItems => Driver.FindElement(By.CssSelector(".shopping_cart_badge"));
        public IWebElement RemoveBtn => Driver.FindElement(By.CssSelector("#remove"));
        public IWebElement ShopingCartLink => Driver.FindElement(By.CssSelector(".shopping_cart_link"));

        public void ShoppingCart()
        {
            Click(ShopingCartBtn);
        }
      
        public void RemoveanItem(string itemRemove)
        {
           foreach(var item in ItemsInCartShop)
            {
                if (itemRemove.Equals(item.Text))
                {
                    Click(item);
                    Click(RemoveBtn);
                    Console.WriteLine(itemRemove + " has removed");
                    Click(ShopingCartLink);
                    break;
                }
            }
        }

        public void ProcedToCheckOut(string checkoutOrContinueShoppingcheck)
        {
            switch (checkoutOrContinueShoppingcheck)
            {

                case "Checkout":
                    Click(CheckOutBtn);
                    break;
                case "Continue Shopping":
                    Click(ContinueShoppingBtn);
                    break;
            }
        }

        public string ProductsAmountInCartShop()
        {
            try
            {
                return ShopingCartIconItems.Text;
            }
            catch
            {
                return "Cart is empty";
            }
        }
        public string IsLabelDisplay()
        {
            return PrintText(LabelCheck);
        }

    }   
}
