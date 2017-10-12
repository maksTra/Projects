using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FrameworkTask;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BusinessLogic
{
    public class HomePage
    {
        [FindsBy(How = How.Id, Using = @"ctl00_ucUserActionsToolbar_lnkLogout")]
        public IWebElement LogOutButton { get; private set; }

        [FindsBy(How = How.Id, Using = @"ctl00_SearchBox_lnkAdvanceSearch")]
        public IWebElement AdvancedSearchButton { get ; private set; }

        [FindsBy(How = How.XPath, Using = @"//div[@id='ej-journals-a-z-alpha-list']")]
        private IWebElement panelWithLetters { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@id='ej-featured-articles-container']/span")]
        protected IWebElement spanOfJournals { get; set; }

        public void Goto()
        {
            Browser.Goto("/pages/default.aspx");
        }

        public void GotoLetter(string letter)
        {
            //TBD
        }

        public void GotoRandomLetter()
        {
            var listOfLetters = panelWithLetters.FindElements(By.TagName("a"));
            var randomLetter = listOfLetters.Skip(new Random().Next(listOfLetters.Count)).Take(1).First();
            randomLetter.Click();
            Browser.WaitUntilElementIsDisplayed(By.XPath($"//span[text()='{randomLetter.Text}']"),10);
        }

        public void GotoRandomJournal()
        {
            var listOfJournals = spanOfJournals.FindElements(By.TagName("article"));
            var randomJournal = listOfJournals.Skip(new Random().Next(listOfJournals.Count)).Take(1).Select(x => x.FindElement(By.XPath("//h4/a"))).First();
            randomJournal.Click();
        }

        public bool IsAt()
        {
            return Browser.Title.Contains("LWW Journals - Beginning with");
        }
    }
}
