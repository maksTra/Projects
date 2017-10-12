using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkTask
{
    public class Browser
    {
        public static IWebDriver WebDriver { get; private set; }
        private static string baseUrl = "http://journals.lww.com";
        
        public static void Initialize(string driverName)
        {
            WebDriver = Driver.GetDriver(driverName);
            WebDriver.Manage().Window.Maximize();
            Goto("");
        }

        public static void Goto(string url)
        {
            WebDriver.Url = baseUrl + url;
        }

        public static void Quit()
        {
            WebDriver.Quit();
        }

        public static string Title { get { return WebDriver.Title; } }

        public static void WaitUntilElementIsDisplayed(IWebElement element, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitUntilElementIsDisplayed(By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }
    }
}