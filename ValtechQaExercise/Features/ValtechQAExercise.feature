Feature: ValtechQAExercise
	As a job candidate
	I want to test the Valtech website
	So I can demonstrate my skils
  [valtech-uk / qa-exercise](https://github.com/valtech-uk/qa-exercise)

Background:
  Given I navigate to the Valtech UK home page

@chrome
Scenario: Capture a list of all partners (exercise 2)
	Given The Partners section is displaying
	When I click on "Our Partners" button on the Partners page
	Then the list of partners across industries can be captured

@chrome
Scenario: Verify all offices in the UK (exercise 3)
  Given I am viewing all offices in United Kingdom
	When I list all the offices in United Kingdom
	Then the list of offices is:
	  | Office                                                                                                          |
	  | Valtech Bristol, Unit 18, Keynsham Rd, Willsbridge, Bristol BS30 6EL, +44 (0) 20 7014 0800, info@valtech.co.uk  |
	  | Valtech London, 46 Colebrooke Row, London N1 8AF, +44 (0) 20 7014 0800, info@valtech.co.uk                      |
	  | Valtech Manchester, Basil Chambers, 65 High Street, Manchester M4 1FS, +44 (0) 20 7014 0800, info@valtech.co.uk |
