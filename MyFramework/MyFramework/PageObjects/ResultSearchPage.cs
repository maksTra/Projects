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

        [FindsBy(How = How.XPath, Using = @"//div[contains(@data-value, 'Relevance')]")]
        public IWebElement SortByMatchButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[contains(@data-value, 'Newest')]")]
        public IWebElement SortByNewestButton { get; set; }


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

        public void SortByNewest()
        {
            Browser.WaitUntilElementIsDisplayed(SortByMatchButton, 10);
            SortByMatchButton.Click();
            Browser.WaitUntilElementIsDisplayed(SortByNewestButton, 10);
            SortByNewestButton.Click();
        }

        public List<string> GetFirst20Titles()
        {
            List<string> result = Browser.WebDriver.FindElements(By.XPath("//div[contains(@class, 'wp-feature-articles')]/div/article[1]/div[1]/div[1]/header[1]/h4[1]/a[1]")).
                Where(x=>x.FindElements(By.XPath("../../../ul[contains(@class, 'article-actions')]/li[contains(@id, 'PAP')]")).Count==0).
                Select(x => x.GetAttribute("title")).
                Take(20).
                ToList();

            return result;
        }
    }
}
