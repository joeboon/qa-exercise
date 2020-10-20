![Valtech logo](http://i.imgur.com/32Oipl4.png "Valtech logo")

QA exercise
==============================

Submission by Joe Boon
----------------------

 + joeboon@yahoo.co.uk

Overview
--------

The exercise was implemented in Gherkin using SpecFlow with C# for step definitions
and page object models.

Observations
------------

1. Invalid HTML in the website footer creates an incomplete title that has an extra double-quote:  
  `"United`  
  The title is also ambiguous because United States and United Kingdom both present to Selenium as "\\"United".  
  This means the footer hyperlink element contains two incorrect attributes:  
  `title="&quot;United"`   `kingdom&quot;=""`  
  Also the target attribute is called `targer` (with an r at the end), and contains unnecessary quotes.

2. The list of Partners is presented to the user as icons without Alt text.  
This should be fixed to improve accessibility of the web site, and will also help automated tests locate elements.

Exercise #1
-----------
- See scenario "Check Page Object Models match the SUT" which navigates around to check the page objects are aligned with the SUT.
- This is useful to provide a smoke test that fails fast when the application has changed and the test framework needs to be updated.
  
Exercise #2
-----------
- See scenario "Capture a list of all partners (exercise 2)"

Exercise #3
-----------
- See scenario "Verify all offices in the UK (exercise 3)"
- When an address does not match, the test output identifies the incorrect address:
```text
Message: Expected item[0] to be 
"Valtech Bristol, Unit 18xxxxx, Keynsham Rd, Willsbridge, Bristol BS30 6EL, +44 (0) 20 7014 0800, info@valtech.co.uk" with a length of 115, but 
"Valtech Bristol, Unit 18, Keynsham Rd, Willsbridge, Bristol BS30 6EL, +44 (0) 20 7014 0800, info@valtech.co.uk" has a length of 110, differs near ", K" (index 24).
```

Exercise #4
-----------
 - README file - This file.

Instructions for running the tests
==================================

All tests currently run locally and are not yet configured to run against a cloud cross browser platform.

Running from Visual Studio
--------------------------
Open the project, and view Test > Windows > Test Explorer

Running from the command line
-----------------------------

`"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "<PATH-TO-PROJECT>\ValtechQaExercise\bin\Debug\net48\ValtechQaExercise.dll" /logger:console;verbosity=detailed`

 - Note: TODO - Get working with MSTest so it can be run with just the MS TestAgent installed on the CI Server

Setting up on a clean Windows PC
--------------------------------

- Visual Studio 2017 15.9.24 with .NET Desktop development module
- Extension "SpecFlow for Visual Studio 2017" v2019.0.66.1863
- Chrome 86.0.4240.75
- Edge 86.0.622.43
- Firefox 81.0.2
- Clone / Copy the project
- Open in VS and Build. This will restore the NuGet packages required for these versions of the browsers.

You can update the NuGet package versions in response to different browser versions.

For Microsoft Edge you also need to download MSEdgeDriver.exe from [https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/) and copy it to the Drivers folder in the project.

Running tests on Docker
-----------------------

Before running on Docker we would want to port the tests to dotnet Core, and consider using SpecRun or our own runner.


Typical output
==============

Scenario: Capture a list of all partners (exercise 2)
-----------------------------------------------------

```text
Starting ChromeDriver 86.0.4240.22 (398b0743353ff36fb1b82468f63a3a93b4e2e89e-refs/branch-heads/4240@{#378}) on port 57047
Only local connections are allowed.
Please see https://chromedriver.chromium.org/security-considerations for suggestions on keeping ChromeDriver safe.
ChromeDriver was started successfully.

DevTools listening on ws://127.0.0.1:57051/devtools/browser/d70d4afa-6a6e-4938-a0e4-616af4ac6d5d
[16608:9456:1020/005607.784:ERROR:device_event_log_impl.cc(208)] [00:56:07.785] Bluetooth: bluetooth_adapter_winrt.cc:1166 RequestRadioAccessAsync failed: RadioAccessStatus::DeniedByUserWill not be able to change radio power.

Passed   CaptureAListOfAllPartnersExercise2
Standard Output Messages:
 Given I navigate to the Valtech UK home page
 -> done: NavigationStepDefinitions.GivenINavigateToTheValtechUKHomePage() (19.3s)
 Given The Partners section is displaying
 -> done: NavigationStepDefinitions.GivenThePartnersSectionIsDisplaying() (1.4s)
 When I click on "Our Partners" button on the Partners page
 -> done: NavigationStepDefinitions.WhenIClickOnButtonOnThePartnersPage() (2.1s)
 Then the list of partners across industries can be captured
 -> done: PartnerStepDefinitions.ThenTheListOfPartnersAcrossIndustriesCanBeCaptured() (0.5s)

Debug Trace:
Partners List
 Industry=Experience
  - Partner=Adobe
  - Partner=Episerver
  - Partner=Sitecore Experience Platform
  - Partner=Bloomreach
  - Partner=Contentstack
  - Partner=Contentful
 Industry=Commerce
  - Partner=Sap Hybris
  - Partner=Salesforce Commerce Cloud
  - Partner=Sitecore Experience Commerce
  - Partner=Episerver
  - Partner=Magento
  - Partner=Commercetools
  - Partner=Inriver
  - Partner=Coveo
  - Partner=Vtex
 Industry=Marketing & Data
  - Partner=Adobe
  - Partner=Salesforce Commerce Cloud
  - Partner=Siteimprove
 Industry=Cloud
  - Partner=Microsoft
 End of Partners List
```

Scenario: Verify all offices in the UK (exercise 3)
---------------------------------------------------

```text
Starting ChromeDriver 86.0.4240.22 (398b0743353ff36fb1b82468f63a3a93b4e2e89e-refs/branch-heads/4240@{#378}) on port 57088
Only local connections are allowed.
Please see https://chromedriver.chromium.org/security-considerations for suggestions on keeping ChromeDriver safe.
ChromeDriver was started successfully.

DevTools listening on ws://127.0.0.1:57091/devtools/browser/95ba24bc-f64d-4623-82e7-8afefb6f7b29
[2264:14972:1020/005633.383:ERROR:device_event_log_impl.cc(208)] [00:56:33.382] Bluetooth: bluetooth_adapter_winrt.cc:1166 RequestRadioAccessAsync failed: RadioAccessStatus::DeniedByUserWill not be able to change radio power.

Passed   VerifyAllOfficesInTheUKExercise3
Standard Output Messages:
 Given I navigate to the Valtech UK home page
 -> done: NavigationStepDefinitions.GivenINavigateToTheValtechUKHomePage() (15.7s)
 Given I am viewing all offices in United Kingdom
 -> done: OfficesStepDefinitions.GivenIAmViewingAllOfficesInUnitedKingdom() (0.7s)
 When I list all the offices in United Kingdom
 -> done: OfficesStepDefinitions.WhenIListAllTheOfficesIn("United Kingdom") (1.4s)
 Then the list of offices is:
   --- table step argument ---
   | Office                                                                                                          |
   | Valtech Bristol, Unit 18, Keynsham Rd, Willsbridge, Bristol BS30 6EL, +44 (0) 20 7014 0800, info@valtech.co.uk  |
   | Valtech London, 46 Colebrooke Row, London N1 8AF, +44 (0) 20 7014 0800, info@valtech.co.uk                      |
   | Valtech Manchester, Basil Chambers, 65 High Street, Manchester M4 1FS, +44 (0) 20 7014 0800, info@valtech.co.uk |
 -> done: OfficesStepDefinitions.ThenTheListOfOfficesIs(<table>) (0.0s)

Debug Trace:
Offices List
 Office=Valtech Bristol, Unit 18, Keynsham Rd, Willsbridge, Bristol BS30 6EL, +44 (0) 20 7014 0800, info@valtech.co.uk
 Office=Valtech London, 46 Colebrooke Row, London N1 8AF, +44 (0) 20 7014 0800, info@valtech.co.uk
 Office=Valtech Manchester, Basil Chambers, 65 High Street, Manchester M4 1FS, +44 (0) 20 7014 0800, info@valtech.co.uk
 End of Offices List
```

Summary of typical test run
---------------------------

```text
Total tests: 3. Passed: 3. Failed: 0. Skipped: 0.
Test Run Successful.
Test execution time: 2.2985 Minutes
```


Finish up
---------
Fork = [https://github.com/joeboon/qa-exercise](https://github.com/joeboon/qa-exercise)