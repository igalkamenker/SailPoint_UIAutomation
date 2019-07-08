using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SailPoint_TestAutomation.Base
{
     public class WebDriverFactory
    {
        private static string driversPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + "\\BrowsersDrivers";
        public static IWebDriver GenerateWebDriver(string driver)
        {
            switch (driver.ToLower())
            {
                case "chrome":
                    {
                        
                        return new ChromeDriver(driversPath);
                    }
                case "firefox":
                    {
                        var service = FirefoxDriverService.CreateDefaultService(driversPath, "geckodriver.exe");
                        return new FirefoxDriver(service);
                    }
                case "ie":
                    return new InternetExplorerDriver(driversPath);
                case "edge":
                    return new EdgeDriver(driversPath);
                default:
                    return new ChromeDriver(driversPath);
            }
        }
    }
}
