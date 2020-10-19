﻿using OpenQA.Selenium;
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

        [BeforeScenario]
        public void BeforeScenario()
        {
            // TODO Get driver type from the environment for CI integration
            _driver = DriverManager.CreateDriver(DriverType.Chrome);
            _scenarioContext["driver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext["driver"] = null;
            _driver?.Dispose();
            _driver = null;
        }
    }
}
