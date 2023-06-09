Feature: LogoDisplaingTest
Simple test for checking the logo

@smoke 
Scenario: Check ReportPortal logo
	Given I open ReportPortal
	Then The logo should be displayed