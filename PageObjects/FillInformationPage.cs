using AutomationFramework1.PageObjects;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAutomationFramework1.PageObjects
{
    internal class FillInformationPage : BasePage
    {
        public FillInformationPage(IWebDriver driver) : base(driver) { }

        public IWebElement FirstName => Driver.FindElement(By.CssSelector("#first-name"));
        public IWebElement LastName => Driver.FindElement(By.CssSelector("#last-name"));
        public IWebElement PostalCode => Driver.FindElement(By.CssSelector("#postal-code"));
        public IWebElement ContinueBtnField => Driver.FindElement(By.CssSelector("#continue"));
        public IWebElement LabelDisplayCheck => Driver.FindElement(By.CssSelector("#header_container > .header_secondary_container > .title"));
        public IWebElement CancelOrder => Driver.FindElement(By.CssSelector("#cancel"));
        public IWebElement ErrorInfo => Driver.FindElement(By.CssSelector("#checkout_info_container > div > form > div.checkout_info > div.error-message-container.error > h3"));


        [AllureStep("Enter {0} FirstName, Enter {1} lastName, Enter {3} zipNumber, Enter {4} calcelOrContinueOrder")]
        public void FillUserInformation(string firstName, string lastName, string zipCode)
        {
            if (firstName == "" || lastName == "" || zipCode == "")
            {
                fillText(FirstName, firstName);
                fillText(LastName, lastName);
                fillText(PostalCode, zipCode);
                Click(ContinueBtnField);
                PrintText(ErrorInfo);
            }
            else
            {
                fillText(FirstName, firstName);
                fillText(LastName, lastName);
                fillText(PostalCode, zipCode);
                Click(ContinueBtnField);
            }
        }
        public string LabelCheck()
        {
            return LabelDisplayCheck.Text;
        }
    }
}
