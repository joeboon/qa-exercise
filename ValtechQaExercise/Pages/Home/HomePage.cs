using System;
using OpenQA.Selenium;
using ValtechQaExercise.Pages.Base;

namespace ValtechQaExercise.Pages.Home
{
    public class HomePage : BasePage
    {
        private readonly Uri _url = new Uri("https://www.valtech.com/");

        private readonly TimeSpan HomePageAnimationTimeout = TimeSpan.FromSeconds(30);

        private By CookieBannerLocator => By.Id("cookiebanner");
        private By TwitterLinkLocator => By.XPath("//a[@title='Twitter']");

        public IWebElement CookieBanner => _driver.FindElement(CookieBannerLocator);
        public IWebElement AcceptCookiesButton => _driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept"));

        public HomePage(IWebDriver driver) 
            : base(driver)
        {
        }

        public virtual void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public void NavigateAndAcceptCookies()
        {
            Navigate();
            AcceptCookiesIfPrompted();
        }

        public void AcceptCookiesIfPrompted()
        {
            if (WaitForIsElementVisible(CookieBannerLocator))
            {
                AcceptCookiesButton.Click();
            }

            WaitForHomePageToLoad();
        }

        private void WaitForHomePageToLoad()
        {
            WaitForElementToBeVisible(TwitterLinkLocator, HomePageAnimationTimeout);
        }
    }
}
