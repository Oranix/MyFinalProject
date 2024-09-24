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
        public string itemSelect1;
        public string itemSelect2;
        public string itemSelect3;

        [AllureSeverity(SeverityLevel.normal)]
        [Test, Description("Login to the web user")]  //Display in Allure 
        public void TC01_LoginPage()
        {
            LoginPage lp = new LoginPage(driver);        
            lp.login("standard_user", "secret_sauce");
            //lp.logout();
            //Assert.That(lp.checkUsersApproved(), Is.EqualTo("Accepted usernames are:"));
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test]
        public void TC02_ProductsPage()
        {            
            ProductPage ai = new ProductPage(driver);
            ShoppingCartPage sp = new ShoppingCartPage(driver);
            Assert.That(sp.IsLabelDisplay(), Is.EqualTo("Products"));
            ai.ListItems("");                                  // value="az" >Name (A to Z),  value="za" > Name (Z to A), value="lohi" > Price (low to high), value="hilo" > Price (high to low)
            itemSelect1 = "Sauce Labs Bike Light";             // add 3 items
            itemSelect2 = "Sauce Labs Backpack";
            itemSelect3 = "Sauce Labs Bolt T-Shirt";
            ai.AddProduct(itemSelect1);                                                                         
            ai.AddProduct(itemSelect2);
            ai.AddProduct(itemSelect3);
            Assert.That(ai.ProductsAmountInCartShop(), Is.EqualTo("3"));
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test]
        public void TC03_ShoppingCartPage()
        {           
            ShoppingCartPage sp = new ShoppingCartPage(driver);
            sp.ShoppingCart();
            Assert.That(sp.IsLabelDisplay(), Is.EqualTo("Your Cart"));  
            sp.ItemDesc(itemSelect1);
            sp.ItemDesc(itemSelect2);
            sp.ItemDesc(itemSelect3);
            sp.RemoveanItem(itemSelect2);               //Remove an item
            Assert.That(sp.ProductsAmountInCartShop(), Is.EqualTo("2"));
            sp.ProcedToCheckOut("Checkout");            //or Continue shopping         
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test]
        public void TC04_CheckoutFillInfoPage()
        {
            CheckoutOverviewPage ch = new CheckoutOverviewPage(driver);
            FillInformationPage cp = new FillInformationPage(driver);
            Assert.That(cp.LabelCheck(), Is.EqualTo("Checkout: Your Information"));  //Validate next page display
            cp.FillUserInformation("ora", "ant", "123123123");  
        }

        [AllureSeverity(SeverityLevel.normal)]
        [Test]
        public void TC05_CheckoutOverview()
        {
            CheckoutOverviewPage ch = new CheckoutOverviewPage(driver);
            Assert.That(ch.IsLabelDisplay(), Is.EqualTo("Checkout: Overview"));
            ch.ItemOverview();
        }

        [AllureSeverity(SeverityLevel.critical)]
        [Test]
        public void TC06_CheckoutComplete()
        {
            CheckoutCompletePage cp = new CheckoutCompletePage(driver);
            Assert.That(cp.IsFinish());       //Validate the finish image is display
            cp.PrintCheckoutFinishLabel();           
            ShoppingCartPage sp = new ShoppingCartPage(driver);
            Assert.That(sp.IsLabelDisplay(), Is.EqualTo("Products"));
        }

    }
}


