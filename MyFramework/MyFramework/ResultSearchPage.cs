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
    public class ResultSearchPage
    {
        [FindsBy(How = How.XPath, Using = @"//div[@class='wp-feature-articles']")]
        protected IWebElement ArticlesList { get; set; }

        private By OpenIconXPathBy = By.XPath(@"//div/article/div/div/ul[contains(@class,'article-actions')]/li/div[contains(@id,'ej-article-indicators-open')]");

        public bool IsAt()
        {
            return Browser.Title.Contains("Search Results");
        }

        public void GoToFreeArticle()
        {
            Browser.WaitUntilElementIsDisplayed(ArticlesList,20);
            var listOfIcons = ArticlesList.FindElements(OpenIconXPathBy);
            listOfIcons.First().Click();
        }
    }
}
