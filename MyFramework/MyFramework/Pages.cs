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
    public class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.WebDriver, page);
            return page;
        }

        public static HomePage HomePage => GetPage<HomePage>();

        public static LoginPage LoginPage => GetPage<LoginPage>();

        public static AdvancedSearchPage AdvancedSearchPage => GetPage<AdvancedSearchPage>();
        
        public static ResultSearchPage ResultSearchPage => GetPage<ResultSearchPage>();

        public static ArticlePage ArticlePage => GetPage<ArticlePage>();

        public static JournalPage JournalPage => GetPage<JournalPage>();

        public static CurrentIssuePage CurrentIssuePage => GetPage<CurrentIssuePage>();
    }
}
