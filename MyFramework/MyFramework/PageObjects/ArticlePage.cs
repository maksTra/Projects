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
    public class ArticlePage
    {
        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul/li[contains(@id, 'pdfListItem')]")]
        public IWebElement ArticleAsPDFButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul/li[contains(@id, 'ePUb')]")]
        public IWebElement EpubButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul/li[3]")]
        public IWebElement PrintArticleButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul/li[contains(@id, 'emailLink')]")]
        public IWebElement EmailToButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul/li[4]")]
        public IWebElement AddToFavouritesButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul/li[5]")]
        public IWebElement ExportToCitationManagerButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul/li[contains(@id, 'citedAlertListItem')]")]
        public IWebElement AlertMeButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul/li[contains(@id, 'rightsLinkListItem')]")]
        public IWebElement GetContentAndPermissionsButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul[contains(@id, 'imagesSection')]/li[1]")]
        public IWebElement ViewImagesInGalleryButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul[contains(@id, 'imagesSection')]/li[2]")]
        public IWebElement ViewImagesInSlideshowButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//aside/div/div/div/div/div/section/div/div/ul[contains(@id, 'imagesSection')]/li[3]")]
        public IWebElement ExportImagesToPPFileButton { get; set; }
    }
}
