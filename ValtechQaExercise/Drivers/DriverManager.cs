using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Firefox;

namespace ValtechQaExercise.Drivers
{
    // TODO Consider making non-static and caching drivers
    public static class DriverManager
    {
        public static IWebDriver CreateDriver(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.Chrome:
                    return CreateChromeDriver();
                case DriverType.Edge:
                    return CreateEdgeDriver();
                case DriverType.Firefox:
                    return CreateFirefoxDriver();
                default:
                    throw new InvalidOperationException("Unexpected Driver Type: " + driverType.ToString());
            }
        }

        /// <summary>
        /// Create a Chrome driver with options required for that browser
        /// </summary>
        /// <returns></returns>
        private static IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver();
        }

        /// <summary>
        /// Create a Microsoft Edge driver with options required for that browser
        /// To download MSEdgeDriver.exe, pick the correct version here:
        ///   https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/
        /// Please install Microsoft WebDriver first, using one of the methods described here:
        ///   https://blogs.windows.com/msedgedev/2018/06/14/webdriver-w3c-recommendation-feature-on-demand
        /// </summary>
        /// <returns></returns>
        private static IWebDriver CreateEdgeDriver()
        {
            EdgeOptions edgeOptions = new EdgeOptions()
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.DismissAndNotify,
                UseChromium = true,
            };

            return new EdgeDriver(edgeOptions);
        }

        /// <summary>
        /// Create a Firefox driver with options required for that browser
        /// </summary>
        /// <returns></returns>
        private static IWebDriver CreateFirefoxDriver()
        {
            return new FirefoxDriver();
        }
    }
}
