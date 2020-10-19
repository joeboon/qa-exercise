using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ValtechQaExercise.Pages.Common;
using ValtechQaExercise.Pages.Home;
using ValtechQaExercise.Pages.Offices;
using TechTalk.SpecFlow;
using System;
using ValtechQaExercise.Pages.Partners;
using ValtechQaExercise.Drivers;

namespace ValtechQaExercise.Steps
{
    [Binding]
    public sealed class PageObjectModelChecker
    {
        private readonly ScenarioContext _scenarioContext;

        public PageObjectModelChecker(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then("tests can visit all pages on each browser, so we fail fast if the UI has changed and the automated test page object models need updating")]
        public void ThenAllPageObjectElementsCanBeFoundOnAllBrowsers()
        {
            CheckAllPages(DriverType.Firefox);
            CheckAllPages(DriverType.Edge);
            CheckAllPages(DriverType.Chrome);
        }

        private static void CheckAllPages(DriverType driverType)
        {
            using (IWebDriver driver = DriverManager.CreateDriver(driverType))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                HomePage homePage = new HomePage_Uk(driver);
                Menu menu = new Menu(driver);
                Footer footer = new Footer(driver);
                OfficesListPage officesPage = new OfficesListPage(driver);
                PartnersListPage partnersListPage = new PartnersListPage(driver);

                homePage.NavigateAndAcceptCookies();

                CheckOfficesPage(footer, officesPage);

                CheckPartnersPage(menu, partnersListPage);
            }
        }

        private static void CheckPartnersPage(Menu menu, PartnersListPage partnersListPage)
        {
            menu.NavigateToPartnersMenu();
            menu.NavigateToOurPartners();

            var industryPartners = partnersListPage.GetAllIndustryPartners();

            System.Diagnostics.Debug.WriteLine("PARTNERS");
            foreach (var industry in industryPartners)
            {
                System.Diagnostics.Debug.WriteLine("Industry=" + industry.Key);
                foreach (var partner in industry.Value)
                {
                    System.Diagnostics.Debug.WriteLine(" - Partner=" + partner);
                }
            }
            System.Diagnostics.Debug.WriteLine("---");
        }

        private static void CheckOfficesPage(Footer footer, OfficesListPage officesPage)
        {
            footer.UnitedKingdomLink.Click();

            var ukOffices = officesPage.GetCountryOfficeAddresses("United Kingdom");

            System.Diagnostics.Debug.WriteLine("OFFICES");
            foreach (var address in ukOffices)
            {
                System.Diagnostics.Debug.WriteLine("Office=" + address);
            }
            System.Diagnostics.Debug.WriteLine("---");
        }
    }
}
