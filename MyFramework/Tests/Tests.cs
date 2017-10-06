using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FrameworkTask;
using NUnit.Framework;
using BusinessLogic;
using OpenQA.Selenium;

namespace Tests
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
           Browser.Quit();
        }

       
        [Test]
        public void LoginChecking()
        {
            Pages.LoginPage.Goto();
            Pages.LoginPage.LogIn();
            Browser.WaitUntilElementIsDisplayed(Pages.HomePage.LogOutButton, 5);
            Assert.True(Pages.HomePage.LogOutButton.Displayed);
        }

        [Test]
        public void MenuInArticleChecking()
        {
            Browser.WaitUntilElementIsDisplayed(Pages.HomePage.AdvancedSearchButton, 5);
            Pages.HomePage.AdvancedSearchButton.Click();
            Pages.AdvancedSearchPage.Search("Hand");
            Pages.ResultSearchPage.GoToFreeArticle();
            Browser.WaitUntilElementIsDisplayed(Pages.ArticlePage.ArticleAsPDFButton, 40);
            Assert.True(Pages.ArticlePage.ArticleAsPDFButton.Displayed);
            Assert.True(Pages.ArticlePage.EpubButton.Displayed);
            Assert.True(Pages.ArticlePage.PrintArticleButton.Displayed);
            Assert.True(Pages.ArticlePage.EmailToButton.Displayed);
            Assert.True(Pages.ArticlePage.AddToFavouritesButton.Displayed);
            Assert.True(Pages.ArticlePage.ExportToCitationManagerButton.Displayed);
            Assert.True(Pages.ArticlePage.AlertMeButton.Displayed);
            Assert.True(Pages.ArticlePage.GetContentAndPermissionsButton.Displayed);
            Assert.True(Pages.ArticlePage.ViewImagesInGalleryButton.Displayed);
            Assert.True(Pages.ArticlePage.ViewImagesInSlideshowButton.Displayed);
            Assert.True(Pages.ArticlePage.ExportImagesToPPFileButton.Displayed);
        }

        [Test]
        public void LinksChecking()
        {
            Pages.HomePage.GotoRandomLetter();
            Pages.HomePage.GotoRandomJournal();
            Pages.JournalPage.GotoCurrentIssue();
            Browser.WaitUntilElementIsDisplayed(Pages.CurrentIssuePage.TCOButton,10);
            Assert.True(Pages.CurrentIssuePage.TCOButton.Displayed);
            Assert.True(Pages.CurrentIssuePage.SubscribeButton.Displayed);
            Assert.True(Pages.CurrentIssuePage.ViewContributorIndexButton.Displayed);
        }

    }
}
