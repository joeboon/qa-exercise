using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ValtechQaExercise.Drivers;

namespace ValtechQaExercise.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext _scenarioContext;

        private IWebDriver _driver;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("chrome")]
        public void BeforeScenario()
        {
            _driver = DriverManager.CreateDriver(DriverType.Chrome);
            _scenarioContext["driver"] = _driver;
        }

        [AfterScenario("chrome")]
        public void AfterScenario()
        {
            _scenarioContext["driver"] = null;
            _driver?.Dispose();
            _driver = null;
        }

        [BeforeScenario("nodriver")]
        public void BeforeScenarioNoDriver()
        {
            _scenarioContext["driver"] = null;
            _driver?.Dispose();
            _driver = null;
        }

        [AfterScenario("nodriver")]
        public void AfterScenarioNoDriver()
        {
            _scenarioContext["driver"] = null;
            _driver?.Dispose();
            _driver = null;
        }
    }
}
