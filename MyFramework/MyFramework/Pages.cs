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

        public static HomePage HomePage { get { return GetPage<HomePage>(); } }

        public static LoginPage LoginPage { get { return GetPage<LoginPage>(); } }

        public static AdvancedSearchPage AdvancedSearchPage { get { return GetPage<AdvancedSearchPage>(); } }

        public static ResultSearchPage ResultSearchPage { get { return GetPage<ResultSearchPage>(); } }

        public static ArticlePage ArticlePage { get { return GetPage<ArticlePage>(); } }

        public static JournalPage JournalPage { get { return GetPage<JournalPage>(); } }

        public static CurrentIssuePage CurrentIssuePage { get { return GetPage<CurrentIssuePage>(); } }
    }
}
