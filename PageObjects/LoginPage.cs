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
        public IWebElement Submit => Driver.FindElement(By.CssSelector("#login_credentials > h4"));
        public IWebElement ErrorLogin => Driver.FindElement(By.CssSelector(".error-message-container.error > h3"));

        public string login (string userName, string password)
        {
            if (userName != "standard_user" ||/* userName != "locked_out_user" || userName != "problem_user" || userName != "performance_glitch_user" || userName != "error_user" || userName != "visual_user" ||*/ password != "secret_sauce" )
            {
                fillText(UserName, userName);
                fillText(Password, password);
                Click(LoginBtn);
                PrintText(ErrorLogin);
                return PrintText(ErrorLogin);
            }
            else
            {
                fillText(UserName, userName);
                fillText(Password, password);
                Click(LoginBtn);
                return "LoginPass";
            }
        }       
      
        public string checkUsersApproved()
        {
            return PrintText(Submit);
        }
    }
}
