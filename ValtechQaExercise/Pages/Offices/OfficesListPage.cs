using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using ValtechQaExercise.Pages.Base;

namespace ValtechQaExercise.Pages.Offices
{
    class OfficesListPage : BasePage
    {
        private By OfficeAddressLocator => By.TagName("address");
        private By CountryLocator(string countryName) => By.XPath($".//h3[contains(text(),'{countryName}')]/parent::div/following-sibling::div");

        public IWebElement CountryList => _driver.FindElement(By.CssSelector(".contacts-overview__list"));

        public OfficesListPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public IList<string> GetCountryOfficeAddresses(string countryName)
        {
            var addressElements = GetCountryOfficeAddressElements(countryName);

            var addresses = addressElements.Select(elem => elem.Text.Trim());

            var addressesSingleLine = addresses.Select(s => MakeAddressIntoSingleLine(s));
            
            // Force evaluation of the enumerable in case the test navigates to another page before listing the results
            return addressesSingleLine.ToList();
        }

        private static string MakeAddressIntoSingleLine(string address)
        {
            string[] lines = address.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<string> trimLines = lines.Select<string, string>(s => s.Trim());
            return string.Join(", ", trimLines);
        }

        private IEnumerable<IWebElement> GetCountryOfficeAddressElements(string countryName)
        {
            WaitForElementToBeVisible(CountryLocator(countryName));

            IWebElement countryElement = CountryList.FindElement(CountryLocator(countryName));

            return countryElement.FindElements(OfficeAddressLocator);
        }

    }
}
