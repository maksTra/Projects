using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FrameworkTask;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace BL
{
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void SetUp()
        {
           Browser.Initialize();
        }

        [TearDown]
        public void TearDown()
        {
           // Browser.Quit();
        }

        /*[Test]
        public void LoginChecking()
        {
            Pages.LoginPage.Goto();
            Pages.LoginPage.LogIn();
            Browser.WaitUntilElementIsDisplayed(Pages.HomePage.LogOutButton, 5);
            Assert.True(Pages.HomePage.LogOutButton.Displayed);
        }*/

        [Test]
        public void MenuInArticleChecking()
        {
            Browser.WaitUntilElementIsDisplayed(Pages.HomePage.AdvancedSearchButton, 5);
            Pages.HomePage.AdvancedSearchButton.Click();
            Pages.AdvancedSearchPage.Search("prsgo");

            var j = Pages.ResultPage.GetArticles();
        }
    }
}
