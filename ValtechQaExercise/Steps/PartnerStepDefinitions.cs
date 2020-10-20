using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ValtechQaExercise.Pages.Partners;

namespace ValtechQaExercise.Steps
{
    [Binding]
    public sealed class PartnerStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private PartnersListPage PartnersListPage;

        public PartnerStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            IWebDriver driver = scenarioContext["driver"] as IWebDriver;

            PartnersListPage = new PartnersListPage(driver);
        }

        [Then(@"the list of partners across industries can be captured")]
        public void ThenTheListOfPartnersAcrossIndustriesCanBeCaptured()
        {
            var industryPartners = PartnersListPage.GetAllIndustryPartners();

            System.Diagnostics.Debug.WriteLine("Partners List");
            foreach (var industry in industryPartners)
            {
                System.Diagnostics.Debug.WriteLine("Industry=" + industry.Key);
                foreach (var partner in industry.Value)
                {
                    System.Diagnostics.Debug.WriteLine(" - Partner=" + partner);
                }
            }
            System.Diagnostics.Debug.WriteLine("End of Partners List");
        }
        
    }
}
