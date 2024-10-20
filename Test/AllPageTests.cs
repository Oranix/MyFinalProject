using AutomationFramework1.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnitAutomationFramework1.PageObjects;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace NUnitAutomationFramework1.Test
{
    [AllureNUnit]
    
    internal class AllPageTests : BaseTest
    {
        public string itemSelect1 = "Sauce Labs Fleece Jacket";
        public string itemSelect2 = "Sauce Labs Onesie";
        public string itemSelect3 = "Sauce Labs Bolt T-Shirt";

        [AllureSeverity(SeverityLevel.normal)]
        [Test, Description("Login to the web user")]  //Display in Allure 
        public void TC01_Login()
        {
            LoginPage lp = new LoginPage(driver);
            Assert.That(lp.login("standard_user", "secret_sauce"), Is.EqualTo("LoginPass"));            
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test, Description("Display the product page")]
        public void TC02_Product()
        {
            ShoppingCartPage sp = new ShoppingCartPage(driver);           
            ProductPage pp = new ProductPage(driver);
            pp.productPage(itemSelect1);
            Assert.That(pp.ChecImageDisplayed());
            pp.ReturntoAllProductsPage();
           
            pp.productPage(itemSelect2);
            Assert.That(pp.ChecImageDisplayed());
            pp.ReturntoAllProductsPage();
            
            pp.productPage(itemSelect3);
            Assert.That(pp.ChecImageDisplayed());
            pp.ReturntoAllProductsPage();
            Assert.That(sp.IsLabelDisplay(), Is.EqualTo("Products"));
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test, Description("Select items from the products page")]
        public void TC03_AllProducts()
        {
            AllProductsPage ai = new AllProductsPage(driver);
            ShoppingCartPage sp = new ShoppingCartPage(driver);
            Assert.That(sp.IsLabelDisplay(), Is.EqualTo("Products"));
            ai.ListItems("az");                     // value="az" >Name (A to Z),  value="za" > Name (Z to A), value="lohi" > Price (low to high), value="hilo" > Price (high to low)            
            ai.AddProduct(itemSelect1);
            ai.AddProduct(itemSelect2);
            ai.AddProduct(itemSelect3);
            Assert.That(ai.ProductsAmountInCartShop(), Is.EqualTo("3"));
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test, Description("Items in shop cart")]
        public void TC04_ShoppingCart()
        {
            ShoppingCartPage sp = new ShoppingCartPage(driver);
            sp.ShoppingCart();
            Assert.That(sp.IsLabelDisplay(), Is.EqualTo("Your Cart"));        
            sp.RemoveanItem(itemSelect2);                //Remove an item
            Assert.That(sp.ProductsAmountInCartShop(), Is.EqualTo("2"));
            sp.ProcedToCheckOut("Checkout");            //or Continue shopping         
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test, Description("Enter user information")]
        public void TC05_CheckoutFillInfoPage()
        {
            CheckoutOverviewPage ch = new CheckoutOverviewPage(driver);
            FillInformationPage cp = new FillInformationPage(driver);
            Assert.That(cp.LabelCheck(), Is.EqualTo("Checkout: Your Information"));  //Validate next page is display
            Assert.That(cp.FillUserInformation("Or", "Ant", "111111"), Is.EqualTo("All information entered"));
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test, Description("overview items and prices before send to delivery")]
        public void TC06_CheckoutOverview()
        {
            CheckoutOverviewPage ch = new CheckoutOverviewPage(driver);
            Assert.That(ch.IsLabelDisplay(), Is.EqualTo("Checkout: Overview"));
            ch.ItemOverview();
        }

        [AllureSeverity(SeverityLevel.critical)]
        [Test, Description("Checkout order and return to products page")]
        public void TC07_CheckoutComplete()
        {
            CheckoutCompletePage cp = new CheckoutCompletePage(driver);
            cp.PrintCheckoutFinishLabel();
            Assert.That(cp.IsFinish());       //Validate the finish image is display                     
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test, Description("Login to the web user")]  //Display in Allure 
        public void TC08_Logout()
        {
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.LogoutFromUser();
            Assert.That(logoutPage.checkUsersApproved(), Is.EqualTo("Epic sadface: Username is required"));
        }

    }
}


