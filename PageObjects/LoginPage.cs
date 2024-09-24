using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework1.PageObjects
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base (driver) {}
        public IWebElement UserName => Driver.FindElement(By.CssSelector("#user-name"));
        public IWebElement Password => Driver.FindElement(By.CssSelector("#password"));
        public IWebElement LoginBtn => Driver.FindElement(By.CssSelector("#login-button"));
        public IWebElement MainMenu => Driver.FindElement(By.CssSelector("#react-burger-menu-btn"));
        public IWebElement LogoutBtn => Driver.FindElement(By.CssSelector("#logout_sidebar_link"));
        public IWebElement Submit => Driver.FindElement(By.CssSelector("#login_credentials > h4"));

        public void login (string userName, string password)
        {
            fillText(UserName, userName);
            fillText(Password, password);
            Click(LoginBtn);
        }       
        public void logout()
        {
            Click(MainMenu);
            Click(LogoutBtn);
        }
        public string checkUsersApproved()
        {
            return Submit.Text;
        }
    }
}
