using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkTask;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MyFramework
{
    public class AdvancedSearchPage
    {
        [FindsBy(How = How.Id, Using = @"keywords_input_1")]
        public IWebElement KeywordField { get; set; }
        
        [FindsBy(How = How.Id, Using = @"ctl00_ctl45_g_77cc2d0c_f9e9_4965_823b_6d21a4776877_ctl00_searchAgain")]
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
