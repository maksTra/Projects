using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkTask;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BL
{
    public class HomePage
    {
        [FindsBy(How = How.Id, Using = @"ctl00_ucUserActionsToolbar_lnkLogout")]
        public IWebElement LogOutButton { get; private set; }

        [FindsBy(How = How.Id, Using = @"ctl00_SearchBox_lnkAdvanceSearch")]
        public IWebElement AdvancedSearchButton { get ; private set; }

        public void Goto()
        {
            Browser.Goto("/pages/default.aspx");
        }

        public bool IsAt()
        {
            return Browser.Title.Contains("LWW Journals - Beginning with A");
        }
    }
}
