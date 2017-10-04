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
    public class ResultPage
    {
        [FindsBy(How = How.XPath, Using = @"id(""ctl00_ctl45_g_17b02124_5f12_4901_8ad8_1c8680d5d195_ctl00_searchResultsSpan"")/div[1]")]
        protected IWebElement ArticlesList { get; set; }

        public bool IsAt()
        {
            return Browser.Title.Contains("Search Results");
        }

        public List<IWebElement> GetArticles()
        {
            Browser.WaitUntilElementIsDisplayed(ArticlesList,5);
            var a = ArticlesList.FindElements(By.TagName("div"));
            return a.ToList();
        }
    }
}
