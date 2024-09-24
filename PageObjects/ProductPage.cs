using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework1.PageObjects
{
    internal class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) {}

        public IWebElement DropDownItems => Driver.FindElement(By.CssSelector(".product_sort_container"));       
        public IWebElement ItemOne => Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-backpack"));        
        public IWebElement ItemTwo => Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bike-light"));
        public IWebElement ItemThree => Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement ItemFour => Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-fleece-jacket"));
        public IWebElement ItemFive => Driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-onesie"));
        public IWebElement ItemSix => Driver.FindElement(By.CssSelector("#add-to-cart-test\\.allthethings\\(\\)-t-shirt-\\(red\\)"));
        public IWebElement TitleFromItemPage => Driver.FindElement(By.CssSelector(".title"));
        public IWebElement ErrorLoginTitle => Driver.FindElement(By.CssSelector(".error-message-container.error"));
        public IWebElement ShopingCartIconItems => Driver.FindElement(By.CssSelector(".shopping_cart_badge"));
        public IList<IWebElement> sortItems => Driver.FindElements(By.CssSelector(".inventory_item_price"));
        public IList<IWebElement> ItemsName => Driver.FindElements(By.CssSelector(".inventory_item_name"));
        public IWebElement FirstItemPrice => Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.pricebar > div"));
        public IWebElement SecondItemPrice => Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(2) > div.inventory_item_description > div.pricebar > div"));
        public IWebElement ThirdItemPrice => Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(3) > div.inventory_item_description > div.pricebar > div"));
        public IWebElement FourthItemPrice => Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(4) > div.inventory_item_description > div.pricebar > div"));
        public IWebElement FifthtemPrice => Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(5) > div.inventory_item_description > div.pricebar > div"));
        public IWebElement SixthtItemPrice => Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(6) > div.inventory_item_description > div.pricebar > div"));

        public void ListItems(string sortDropDown)
        {
            //DropDown menu
            if (!(string.IsNullOrEmpty(sortDropDown)))
            {
                SelectElement dropDownList = new SelectElement(DropDownItems);
                dropDownList.SelectByValue(sortDropDown);
            }
            
                switch (sortDropDown)
                {
                    case "lohi":   //Sort by price low to high
                        foreach (var item in sortItems)
                        {
                            Console.WriteLine("item price " + item.Text);
                        }
                        break;
                    case "hilo":    //Sort by price high to low
                        foreach (var item in sortItems)
                        {
                            Console.WriteLine("item price " + item.Text);
                        }
                        break;
                    case "az":     //Sort by name a to z
                        foreach (var item in ItemsName)
                        {
                            Console.WriteLine("item name " + item.Text); ;
                        }
                        break;
                    case "za":     //Sort by name z to a
                        foreach (var item in ItemsName)
                        {
                            Console.WriteLine("item name " + item.Text); ;
                        }
                        break;
                    default:
                        Console.WriteLine("No sort selecting");
                         foreach (var item in ItemsName)
                         {
                             Console.WriteLine("item name " + item.Text); ;
                         }
                    break;
                }
            
        }

        public void AddProduct(string itemSelect)
        {
            Console.WriteLine("You select item: " + itemSelect);
            switch (itemSelect)
            {
                case "Sauce Labs Backpack":
                    Console.WriteLine("Price is: " + FirstItemPrice.Text);
                    Click(ItemOne);
                    break;
                case "Sauce Labs Bike Light":
                    Console.WriteLine("Price is: " + SecondItemPrice.Text); ;
                    Click(ItemTwo);
                    break;
                case "Sauce Labs Bolt T-Shirt":
                    Console.WriteLine("Price is: " + ThirdItemPrice.Text);
                    Click(ItemThree);
                    break;
                case "Sauce Labs Fleece Jacket":
                    Console.WriteLine("Price is: " + FourthItemPrice.Text);
                    Click(ItemFour);
                    break;
                case "Sauce Labs Onesie":
                    Console.WriteLine("Price is: " + FifthtemPrice.Text);
                    Click(ItemFive);
                    break;
                case "T-Shirt (Red)":
                    Console.WriteLine("Price is: " + SixthtItemPrice.Text);
                    Click(ItemSix);
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

        public string CheckLoginOk()  
        {
            try
            {
                TitleFromItemPage.Text.Equals("Products");
                return TitleFromItemPage.Text;
            }
            catch
            {
                return ErrorLoginTitle.Text;
            }
        }
    }
}
