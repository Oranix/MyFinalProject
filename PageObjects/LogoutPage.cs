using AutomationFramework1.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAutomationFramework1.PageObjects
{
    internal class LogoutPage : BasePage
    {
        public LogoutPage(IWebDriver driver) : base(driver) { }

        public IWebElement BackHomeBtn => Driver.FindElement(By.CssSelector("#back-to-products"));
        public IWebElement MenuBtn => Driver.FindElement(By.CssSelector("#react-burger-menu-btn"));
        public IWebElement LogoutBtn => Driver.FindElement(By.CssSelector("#logout_sidebar_link"));
        public IWebElement ErrorLogin => Driver.FindElement(By.CssSelector("#login_button_container > div > form > div.error-message-container.error > h3"));
        public IWebElement LoginBtn => Driver.FindElement(By.CssSelector("#login-button"));


        public void LogoutFromUser()
        {
            Click(BackHomeBtn);
            Click(MenuBtn);
            Click(LogoutBtn);
        }
        public string checkUsersApproved()
        {
            Click(LoginBtn);
            PrintInfromation(ErrorLogin);
            return PrintText(ErrorLogin);
        }
    }
}
