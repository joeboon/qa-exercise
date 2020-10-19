using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ValtechQaExercise.Pages.Common;
using ValtechQaExercise.Pages.Offices;

namespace ValtechQaExercise.Steps
{
    [Binding]
    public sealed class OfficesStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private Footer Footer;
        private OfficesListPage OfficesListPage;

        public OfficesStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            IWebDriver driver = scenarioContext["driver"] as IWebDriver;

            Footer = new Footer(driver);
            OfficesListPage = new OfficesListPage(driver);
        }

        [Given(@"I am viewing all offices in United Kingdom")]
        public void GivenIAmViewingAllOfficesInUnitedKingdom()
        {
            Footer.UnitedKingdomLink.Click();
        }

        [When(@"I list all the offices in (.*)")]
        public void WhenIListAllTheOfficesIn(string countryName)
        {
            IList<string> officeAddresses = OfficesListPage.GetCountryOfficeAddresses(countryName);
            _scenarioContext["officeAddresses"] = officeAddresses;

            System.Diagnostics.Debug.WriteLine("Offices List");
            foreach (var address in officeAddresses)
            {
                System.Diagnostics.Debug.WriteLine("Office=" + address);
            }
            System.Diagnostics.Debug.WriteLine("End of Offices List");
        }

        [Then(@"the list of offices is:")]
        public void ThenTheListOfOfficesIs(Table table)
        {
            IEnumerable<string> expectedOfficeAddresses = table.Rows.Select(row => row["Office"]);
            IEnumerable<string> actualOfficeAddresses = _scenarioContext["officeAddresses"] as IList<string>;

            actualOfficeAddresses.Should().BeEquivalentTo(expectedOfficeAddresses);
        }


    }
}
