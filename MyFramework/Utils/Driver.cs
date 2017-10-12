using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;

namespace FrameworkTask
{
    internal class Driver
    {
        private static IWebDriver driver;

        private Driver()
        { }

        public static IWebDriver GetDriver(string browser)
        {
            switch (browser)
            {
                /*case "Chrome":
                    driver = new ChromeDriver();
                    break;*/
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
               /* case "Edge":
                    driver = new EdgeDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "Safari":
                    driver = new SafariDriver();
                    break;
                case "Opera":
                    driver = new OperaDriver();
                    break;*/
            }
            return driver;
        }
    }
}
