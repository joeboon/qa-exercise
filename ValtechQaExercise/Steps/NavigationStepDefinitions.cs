using OpenQA.Selenium;
using TechTalk.SpecFlow;
using FluentAssertions;
using ValtechQaExercise.Pages.Common;
using ValtechQaExercise.Pages.Home;

namespace ValtechQaExercise.Steps
{
    [Binding]
    public sealed class NavigationStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private Menu Menu;
        private HomePage HomePage;

        public NavigationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            IWebDriver driver = scenarioContext["driver"] as IWebDriver;

            Menu = new Menu(driver);
            HomePage = new HomePage_Uk(driver);
        }

        [Given(@"I navigate to the Valtech UK home page")]
        public void GivenINavigateToTheValtechUKHomePage()
        {
            HomePage.NavigateAndAcceptCookies();
        }
        
        [Given(@"The Partners section is displaying")]
        public void GivenThePartnersSectionIsDisplaying()
        {
            Menu.NavigateToPartnersMenu();
            Menu.IsPartnersHeaderVisible().Should().BeTrue();
        }

        [When(@"I click on ""Our Partners"" button on the Partners page")]
        public void WhenIClickOnButtonOnThePartnersPage()
        {
            // TODO Consider accepting the button label as a parameter in the cucumber expression
            Menu.NavigateToOurPartners();
        }
      
    }
}
