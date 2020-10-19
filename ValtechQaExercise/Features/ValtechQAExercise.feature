Feature: ValtechQAExercise
	As a job candidate
	I want to test the Valtech website
	So I can demonstrate my skils
  [valtech-uk / qa-exercise](https://github.com/valtech-uk/qa-exercise)

Background:
  Given I navigate to the Valtech UK home page

Scenario: Capture a list of all partners (exercise 2)
	Given The Partners section is displaying
	When I click on "Our Partners" button on the Partners page
	Then the list of partners across industries can be captured
