using System;
using OpenQA.Selenium;

namespace ValtechQaExercise.Pages.Home
{
    class HomePage_Uk : HomePage
    {
        // Navigate to .co.uk, rather than .com/en_gb, because that is what users are more likely to do
        private readonly Uri _url = new Uri("https://www.valtech.co.uk/");

        public HomePage_Uk(IWebDriver driver) 
            : base(driver)
        {
        }

        public override void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }
    }
}
