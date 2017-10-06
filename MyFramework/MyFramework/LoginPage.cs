using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using FrameworkTask;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BusinessLogic
{
    public class LoginPage
    {
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'txt_UserName')]")]
        private IWebElement usernameField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'txt_Password')]")] 
        private IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'LoginButton')]")]
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
            usernameField.SendKeys(User.Name);
            passwordField.SendKeys(User.Password);
            loginButton.Click();
        }
    }
}
