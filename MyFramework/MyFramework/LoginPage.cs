using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkTask;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BL
{
    class LoginPage
    {
        [FindsBy(How = How.XPath, Using = "id(\"ctl00_ctl45_g_818e981e_cd12_4836_8e55_9fe5e199454d_ctl00_LoginControl_txt_UserName\")")]
        private IWebElement usernameField;

        [FindsBy(How = How.XPath, Using = "id(\"ctl00_ctl45_g_818e981e_cd12_4836_8e55_9fe5e199454d_ctl00_LoginControl_txt_Password\")")]
        private IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "id(\"ctl00_ctl45_g_818e981e_cd12_4836_8e55_9fe5e199454d_ctl00_LoginControl_LoginButton\")")]
        private IWebElement loginButton;

        public void Goto()
        {
            Browser.Goto("/pages/login.aspx?ContextUrl=%2fpages%2fdefault.aspx");
        }

        public bool IsAt()
        {
            return Browser.Title.Contains("Login");
        }

        public void LogIn()
        {
            usernameField.SendKeys("TestName");
            passwordField.SendKeys("test1test");
            loginButton.Click();
        }
    }
}
