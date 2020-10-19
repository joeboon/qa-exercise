Feature: FrameworkChecks
  As an automation engineer
	I want to exercise the test framework
	So I quickly know whether tests will fail due to changes

@smoke
@nodriver
Scenario: Check Page Object Models match the SUT
  Then tests can visit all pages on each browser, so we fail fast if the UI has changed and the automated test page object models need updating

 