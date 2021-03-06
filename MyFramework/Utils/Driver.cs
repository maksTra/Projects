﻿using System;
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
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddExtension(@"C:\Users\Maksim_Trayanovich\Downloads\gighmmpiobklfepjocnamgkkbiglidom-3.17.0-Crx4Chrome.com.crx");
                    options.AddArgument("start-maximized");
                    driver = new ChromeDriver(options);                    
                    break;
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
