using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BusinessLogic
{
    public class CurrentIssuePage
    {
        [FindsBy(How = How.XPath, Using = @"//a[contains(@id, 'lnkbtnTOC')]")]
        public IWebElement TCOButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//a[@class='toc-popup']")]
        public IWebElement SubscribeButton { get; set; }

        [FindsBy(How = How.LinkText, Using = @"View Contributor Index")]
        public IWebElement ViewContributorIndexButton { get; set; }
    }
}
