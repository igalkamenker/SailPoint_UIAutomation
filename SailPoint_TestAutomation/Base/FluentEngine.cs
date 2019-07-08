using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SailPoint_TestAutomation.Base
{
    public class FluentEngine
    {
        public FluentEngine() { }
        public FluentEngine(IWebDriver webDriver)
        {
            m_WebDriver = webDriver;
        }
        private static IWebDriver m_WebDriver;
        public IWebDriver WebDriver => m_WebDriver;

        public static TimeSpan ElementSearchingTimeout { get; set; } = TimeSpan.FromSeconds(7);

        public T GoToPage<T>(string url) where T : new() 
        {
          
            WebDriver.Navigate().GoToUrl(url);
            WebDriver.Manage().Window.Maximize();
            return new T();

        }
        public virtual T GoToPage<T>() where T : new()
        {
            return new T();
        }

        public WebDriverWait Wait
        {
            get
            {
                return new WebDriverWait(WebDriver, ElementSearchingTimeout);
            }
        }

    }
}
