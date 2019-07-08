using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SailPoint_TestAutomation.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SailPoint_TestAutomation.Pages
{
    public class Page_TableSearchFilterDemo : FluentEngine
    {
        public  IDictionary<string, string> Repository => new Dictionary<string, string>
        {
            ["BtnFilter"] = "//button[contains(@class,'btn-filter')]",
            ["Input_#"] = "//input[@placeholder='#']",
            ["Input_Username"] = "//input[@placeholder='Username']",
            ["Input_FirstName"] = "//input[@placeholder='First Name']",
            ["Input_LastName"] = "//input[@placeholder='Last Name']",
            ["TableListedUsers_Column_LastName_WithoutStyle"] = "//table[@class='table']/tbody/tr[not(@style)]//td[4]",
            ["TableListedUsers_Column_LastName_WithStyle"] = "//table[@class='table']/tbody/tr[@style='display: table-row;']//td[4]",
            ["TableListedUsers_WitoutResults_Text"] = "//tr[@class='no-result text-center']/td"
        };

        

        public Page_TableSearchFilterDemo ClickOnButtonFilter()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Repository["BtnFilter"]))).Click();
            return this;
        }

    
        public bool TextBoxLastNameInsertText (string text)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Repository["Input_LastName"]))).SendKeys(text);
            ReadOnlyCollection<IWebElement> ElementCollection = Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Repository["TableListedUsers_Column_LastName_WithoutStyle"])));
               
            foreach (var element in ElementCollection)
            {
                if (!element.Text.ToLower().Contains(text.ToLower()))
                    return false;

            }
            
            return true;
        }

        public string TextBoxFirstNameInsertText(string text)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Repository["Input_FirstName"]))).SendKeys(text);
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Repository["TableListedUsers_WitoutResults_Text"]))).Text;
        }
    }
}
