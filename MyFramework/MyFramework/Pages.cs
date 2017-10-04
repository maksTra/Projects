using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkTask;
using MyFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BL
{
    class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.WebDriver, page);
            return page;
        }

        public static HomePage HomePage
        {
            get { return GetPage<HomePage>(); }
        }

        public static LoginPage LoginPage
        {
            get { return GetPage<LoginPage>(); }
        }

        public static AdvancedSearchPage AdvancedSearchPage
        {
            get { return GetPage<AdvancedSearchPage>(); }
        }

        public static ResultPage ResultPage
        {
            get { return GetPage<ResultPage>(); }
        }
    }
}
