using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkTask;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BusinessLogic
{
    public class AdvancedSearchPage
    {
        [FindsBy(How = How.Id, Using = @"keywords_input_1")]
        public IWebElement KeywordField { get; set; }

        [FindsBy(How = How.XPath, Using = @"//input[contains(@id, 'searchAgain')]")]
        public IWebElement SearchButton { get; set; }

        public void Goto()
        {
            Browser.Goto("/pages/advancedsearch.aspx");
        }

        public bool IsAt()
        {
            return Browser.Title.Contains("Advanced Search");
        }

        public void Search(string keyword)
        {
            Browser.WaitUntilElementIsDisplayed(KeywordField, 5);
            KeywordField.SendKeys(keyword);
            Browser.WaitUntilElementIsDisplayed(SearchButton, 5);
            SearchButton.Click();
        }
    }
}
