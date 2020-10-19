using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ValtechQaExercise.Pages.Base;

namespace ValtechQaExercise.Pages.Partners
{

    class PartnersListPage : BasePage
    {
        private By IndustryNameLocator => By.CssSelector(".partners-block__title");
        private By PartnerLinksLocator => By.CssSelector("a.partners-block__logo");

        public IWebElement PartnersList => _driver.FindElement(By.ClassName("partners-block"));
        public IEnumerable<IWebElement> IndustryAreas => PartnersList.FindElements(By.ClassName("partners-block__section"));

        public PartnersListPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public IDictionary<string, IList<string>> GetAllIndustryPartners()
        {
            var actions = new Actions(_driver);
            var allIndustryPartners = new Dictionary<string, IList<string>>();

            foreach (var industry in IndustryAreas)
            {
                actions.MoveToElement(industry); // Replicate user behaviour
                string name = GetIndustryName(industry);
                IList<string> partners = GetPartnerNames(industry);
                allIndustryPartners.Add(name, partners);
            }

            return allIndustryPartners;
        }

        private string GetIndustryName(IWebElement IndustryArea)
        {
            return IndustryArea.FindElement(IndustryNameLocator).Text.Trim();
        }

        // TODO Update this to use Alt instead of Hrefs once the partner logos have Alt text for accessibility
        private IList<string> GetPartnerNames(IWebElement IndustryArea)
        {
            IEnumerable<IWebElement> partnerLinkElements = IndustryArea.FindElements(PartnerLinksLocator);

            var partnerNames = partnerLinkElements.Select(elem => GetPartnerNameFromLink(elem));

            // Force evaluation of the enumerable in case the test navigates to another page before listing the results
            return partnerNames.ToList();
        }

        private string GetPartnerNameFromLink(IWebElement elem)
        {
            string href = elem.GetAttribute("href");
            Uri uri = new Uri(href);

            string name = uri.Segments.Last().Trim('/');
            name = name.Replace('-', ' ');

            string titlecaseName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);

            return titlecaseName;
        }
    }
}
