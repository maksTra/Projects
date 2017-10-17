using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FrameworkTask;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BusinessLogic
{
    public class JournalPage
    {
        [FindsBy(How = How.XPath, Using = @"id(""zz2_RootAspMenu"")/li[1]/a[1]")]
        public IWebElement ArticlesAndIssuesButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"id(""zz2_RootAspMenu"")/li[1]/ul[1]/li[1]/a[1]")]
        public IWebElement CurrentIssueButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@class='advance-search']/a")]
        public IWebElement AdvancedSearchButton { get; set; }

        public void GotoCurrentIssue()
        {
            while (Browser.WebDriver.WindowHandles.Count==1)
            {
                Thread.Sleep(500);
            }
            Browser.WebDriver.SwitchTo().Window(Browser.WebDriver.WindowHandles[1]);
            Browser.WaitUntilElementIsDisplayed(ArticlesAndIssuesButton, 30);
            ArticlesAndIssuesButton.Click();
            Browser.WaitUntilElementIsDisplayed(CurrentIssueButton,10);
            CurrentIssueButton.Click();
        }

        //Advanced search in journal
        public void GotoAdvancedSearch()
        {
            AdvancedSearchButton.Click();
        }

        public void GotoJournal(string journalName)
        {
            Browser.Goto($"/{journalName}/pages/default.aspx");
        }
    }
}
