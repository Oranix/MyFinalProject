using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Firefox;
using System.Xml.Linq;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Edge;
using NUnit.Framework.Interfaces;
using System.Net.Mime;
using Allure.Commons;

namespace NUnitAutomationFramework1.Test
{
    internal class BaseTest
    {
        private static bool allureEnvWritten; //Parameter 
        //Configuration file JSON setup
        public static readonly IConfigurationRoot config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(path:"C:\\Users\\ora\\source\\repos\\AutomationFramework1\\NUnitAutomationFramework1\\Test\\appsettings.json")
           .Build();

        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {                     
            var browserName = TestContext.Parameters["browserName"] ?? config["browserName"];
            switch (browserName)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    if (!allureEnvWritten)   //TO SHOW THE GLOBAL INFORMATION ABOUT THE BROWSER LIKE VERSION AND TYPE
                    {
                        var allureEnvironment = new XElement("environment",
                        new XElement("parameter",
                        new XElement("key", "browser"),
                        new XElement("value", ((ChromeDriver)driver).Capabilities.GetCapability("browserName"))),
                        new XElement("parameter",
                        new XElement("key", "browser.version"),
                        new XElement("value", ((ChromeDriver)driver).Capabilities.GetCapability("browserVersion"))));
                        allureEnvironment.Save("..\\..\\..\\allure-results/environment.xml");
                        allureEnvWritten = true;
                    }
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    if (!allureEnvWritten)
                    {
                        var allureEnvironment = new XElement("environment",
                        new XElement("parameter",
                        new XElement("key", "browser"),
                        new XElement("value", ((FirefoxDriver)driver).Capabilities.GetCapability("browserName"))),
                        new XElement("parameter",
                        new XElement("key", "browser.version"),
                        new XElement("value", ((FirefoxDriver)driver).Capabilities.GetCapability("browserVersion"))));
                        allureEnvironment.Save("..\\..\\..\\allure-results/environment.xml");
                        allureEnvWritten = true;
                    }
                    break;
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    if (!allureEnvWritten)
                    {
                        var allureEnvironment = new XElement("environment",
                        new XElement("parameter",
                        new XElement("key", "browser"),
                        new XElement("value", ((EdgeDriver)driver).Capabilities.GetCapability("browserName"))),
                        new XElement("parameter",
                        new XElement("key", "browser.version"),
                        new XElement("value", ((EdgeDriver)driver).Capabilities.GetCapability("browserVersion"))));
                        allureEnvironment.Save("..\\..\\..\\allure-results/environment.xml");
                        allureEnvWritten = true;
                    }
                    break;
                default:
                throw new NotSupportedException($"No such browser {browserName}");
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(config["baseUrl"]);
        }

        [TearDown]
        public void TakeScreenShotOnFailure() ///Take screen shots if tests are fail!!!! display in allure
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                AllureLifecycle.Instance.AddAttachment("Full page screenshot", MediaTypeNames.Image.Jpeg, ((ITakesScreenshot)driver).GetScreenshot().AsByteArray);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}
