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
        public IWebElement SauceLabsBikeLightDescription => Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div:nth-child(3) > div.cart_item_label > div.inventory_item_desc"));
        public IWebElement SauceLabsBackpackDescription => Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div:nth-child(4) > div.cart_item_label > div.inventory_item_desc"));
        public IWebElement SauceLabsBoltTShirtDescription => Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div:nth-child(5) > div.cart_item_label > div.inventory_item_desc"));
        public IWebElement SauceLabsFleeceJacketDescription => Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div:nth-child(6) > div.cart_item_label > div.inventory_item_desc"));
        public IWebElement SauceLabsOnesieDescription => Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div:nth-child(7) > div.cart_item_label > div.inventory_item_desc"));
        public IWebElement TShirtRedDescription => Driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_list > div:nth-child(8) > div.cart_item_label > div.inventory_item_desc"));   
        public IWebElement SauceLabsBikeLightRemove => Driver.FindElement(By.CssSelector("#remove-sauce-labs-bike-light"));
        public IWebElement SauceLabsBackpackRemove => Driver.FindElement(By.CssSelector("#remove-sauce-labs-backpack"));
        public IWebElement SauceLabsBoltTShirtRemove => Driver.FindElement(By.CssSelector("#remove-sauce-labs-bolt-t-shirt"));
        public IWebElement SauceLabsFleeceJacketRemove => Driver.FindElement(By.CssSelector("#remove-sauce-labs-fleece-jacket"));
        public IWebElement SauceLabsOnesieRemove => Driver.FindElement(By.CssSelector("#remove-sauce-labs-onesie"));
        public IWebElement TShirtRedRemove => Driver.FindElement(By.CssSelector("#remove-test\\.allthethings\\(\\)-t-shirt-\\(red\\)"));
        public IWebElement ShopingCartIconItems => Driver.FindElement(By.CssSelector(".shopping_cart_badge"));


        public void ShoppingCart()
        {
            Click(ShopingCartBtn);
        }
        public void ItemDesc(string itemDescription)
        {
            switch(itemDescription)
            {
                case "Sauce Labs Backpack":
                    Console.WriteLine(SauceLabsBackpackDescription.Text);
                    break;
                case "Sauce Labs Bike Light":
                    Console.WriteLine(SauceLabsBikeLightDescription.Text);
                    break;
                case "Sauce Labs Bolt T-Shirt":
                    Console.WriteLine(SauceLabsBoltTShirtDescription.Text);
                    break;
                case "Sauce Labs Fleece Jacket":
                    Console.WriteLine(SauceLabsFleeceJacketDescription.Text);
                    break;
                case "Sauce Labs Onesie":
                    Console.WriteLine(SauceLabsOnesieDescription.Text);
                    break;
                case "T-Shirt (Red)":
                    Console.WriteLine(TShirtRedDescription.Text);
                break;
                default:
                    Console.WriteLine("No item selection");
                    break;
            }

        }
        public void RemoveanItem(string itemRemove)
        {
            switch (itemRemove)
            {
                case "Sauce Labs Backpack":
                    Click(SauceLabsBackpackRemove);
                    break;
                case "Sauce Labs Bike Light":
                    Click(SauceLabsBikeLightRemove);
                    break;
                case "Sauce Labs Bolt T-Shirt":
                    Click(SauceLabsBoltTShirtRemove);
                    break;
                case "Sauce Labs Fleece Jacket":
                    Click(SauceLabsFleeceJacketRemove);
                    break;
                case "Sauce Labs Onesie":
                    Click(SauceLabsOnesieRemove);
                    break;
                case "T-Shirt (Red)":
                    Click(TShirtRedRemove);
                    break;
                default:
                    Console.WriteLine("No item to remove");
                    break;
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
            return LabelCheck.Text;
        }

    }   
}
