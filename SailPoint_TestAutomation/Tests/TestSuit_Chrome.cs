using NUnit.Framework;
using OpenQA.Selenium;
using SailPoint_TestAutomation.Base;
using SailPoint_TestAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailPoint_TestAutomation
{
    [TestFixture]
    public class TestSuit_Chrome : FluentEngine
    {

        [TestCase, Description("Click the filter - > #, “Username”, “First Name”, “Last Name” text boxes becomes enabled")]
        public void Chrome_TextBoxesEnabled()
        {
            var Page_TableSearchFilterDemo = new FluentEngine(WebDriverFactory.GenerateWebDriver("chrome")).
                 GoToPage<Page_TableSearchFilterDemo>("https://www.seleniumeasy.com/test/table-search-filter-demo.html").
                 ClickOnButtonFilter();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(null, WebDriver.FindElement(By.XPath(Page_TableSearchFilterDemo.Repository["Input_#"])).GetAttribute("disabled"));
                Assert.AreEqual(null, WebDriver.FindElement(By.XPath(Page_TableSearchFilterDemo.Repository["Input_Username"])).GetAttribute("disabled"));
                Assert.AreEqual(null, WebDriver.FindElement(By.XPath(Page_TableSearchFilterDemo.Repository["Input_FirstName"])).GetAttribute("disabled"));
                Assert.AreEqual(null, WebDriver.FindElement(By.XPath(Page_TableSearchFilterDemo.Repository["Input_LastName"])).GetAttribute("disabled"));

            });
        }

          [TestCase, Description("In the “Last Name” text box, insert the letters “ar” -> Only records with “ar” in their name appear")]
        public void Chrome_OnlyRecordsBySearchString()
        {
            var AreOnlyFilteredRecordsShow = new FluentEngine(WebDriverFactory.GenerateWebDriver("chrome")).
                 GoToPage<Page_TableSearchFilterDemo>("https://www.seleniumeasy.com/test/table-search-filter-demo.html").
                 ClickOnButtonFilter().
                 TextBoxLastNameInsertText("ar");

            Assert.AreEqual(true, AreOnlyFilteredRecordsShow);

        }

        [TestCase, Description("In the “First Name” text box, insert the letters “SailPoint” -> Table shows “No result found”")]
        public void Chrome_TextNoResultFound()
        {
            var TextNoResultFound = new FluentEngine(WebDriverFactory.GenerateWebDriver("chrome")).
                 GoToPage<Page_TableSearchFilterDemo>("https://www.seleniumeasy.com/test/table-search-filter-demo.html").
                 ClickOnButtonFilter().
                 TextBoxFirstNameInsertText("SailPoint");

            Assert.AreEqual("No result found", TextNoResultFound);
        }

        [TearDown, Description("Close Webdriver & Browser")]
        public void CloseBrowserAfterEachTest()
        {
            WebDriver.Quit();
        }
    }
}
