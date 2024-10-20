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
    internal class AllProductsPage : BasePage
    {
        public AllProductsPage(IWebDriver driver) : base(driver) {}

        public IWebElement DropDownItems => Driver.FindElement(By.CssSelector(".product_sort_container"));            
        public IWebElement TitleFromItemPage => Driver.FindElement(By.CssSelector(".title"));
        public IWebElement ErrorLoginTitle => Driver.FindElement(By.CssSelector(".error-message-container.error"));
        public IWebElement ShopingCartIconItems => Driver.FindElement(By.CssSelector(".shopping_cart_badge"));
        public IWebElement ReturnToAllProductsPage => Driver.FindElement(By.CssSelector("#back-to-products"));
        public IList<IWebElement> sortItems => Driver.FindElements(By.CssSelector(".inventory_item_price"));
        public IList<IWebElement> ItemsName => Driver.FindElements(By.CssSelector(".inventory_item_name"));
        public IList<IWebElement> Products => Driver.FindElements(By.CssSelector(".inventory_item_name "));    
        public IWebElement AddToCartBtn => Driver.FindElement(By.CssSelector("#add-to-cart"));

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
                            Console.WriteLine("item price " + PrintText(item));
                        }
                        break;
                    case "hilo":    //Sort by price high to low
                        foreach (var item in sortItems)
                        {
                            Console.WriteLine("item price " + PrintText(item));
                        }
                        break;
                    case "az":     //Sort by name a to z
                        foreach (var item in ItemsName)
                        {
                            Console.WriteLine("item name " + PrintText(item)); 
                        }
                        break;
                    case "za":     //Sort by name z to a
                        foreach (var item in ItemsName)
                        {
                            Console.WriteLine("item name " + PrintText(item)); 
                        }
                        break;
                    default:
                        Console.WriteLine("No sort selecting");
                         foreach (var item in ItemsName)
                         {
                             Console.WriteLine("item name " + PrintText(item)); 
                         }
                    break;
                }            
        }

        public void AddProduct(string itemSelect)
        {            
            foreach (var item in Products)
            {
                if (itemSelect.Equals(item.Text))
                {
                   Click(item);
                   Click(AddToCartBtn);
                   Click(ReturnToAllProductsPage); 
                   break;
                }
            }
        }

        public string ProductsAmountInCartShop()   
        {
            try
            {
                return PrintText(ShopingCartIconItems);
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
                return PrintText(TitleFromItemPage);
            }
            catch
            {
                return PrintText(ErrorLoginTitle);
            }
        }
    }
}
