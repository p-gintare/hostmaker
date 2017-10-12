Feature: CalculationFormTests
	In order to be able to check my property value
	As a property owner
	I want to be able to select my property address and bedroom number and get estimate what I can make

@WindowMaximize
Scenario: I can get my property estimate
	Given I go to Hostmaker.co
	When I enter my postcode 'N1 9 PD'
	And I select 'White Lion Street' as my address
	And I select 2 bedroom from the number of bedrooms option
	And I enter email address as 'test@test.com'
	And I click calculate
	Then I should see the estimate we can make between 1075 and 1200
