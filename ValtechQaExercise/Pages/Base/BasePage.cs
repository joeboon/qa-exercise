using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ValtechQaExercise.Pages.Base
{
    public class BasePage
    {
        public static readonly TimeSpan ELEMENT_VISIBLE_TIMEOUT = TimeSpan.FromSeconds(15);

        protected readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void WaitForElementToBeVisible(By locator)
        {
            WaitForElementToBeVisible(locator, ELEMENT_VISIBLE_TIMEOUT);
        }

        public void WaitForElementToBeVisible(By locator, TimeSpan elementVisibleTimeout)
        {
            var wait = new WebDriverWait(_driver, elementVisibleTimeout)
            {
                Message = $"Element with locator {locator.ToString()} did not become visible"
            };

            wait.Until<bool>(driver => ElementIsVisible(driver, locator));
        }

        public bool WaitForIsElementVisible(By locator)
        {
            try
            {
                WaitForElementToBeVisible(locator);

                return ElementIsVisible(_driver, locator);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        private bool ElementIsVisible(IWebDriver driver, By locator)
        {
            try
            {
                var element = driver.FindElement(locator);
                return element.Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool ElementIsVisible(IWebElement element)
        {
            return element.Displayed;
        }

    }
}
