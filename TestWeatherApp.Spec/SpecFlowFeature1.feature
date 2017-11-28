Feature: Local weather in a given city
	In order to know hot ot dress for the business trip
	As a delegated employee
	I want check what the weather is like in a city and country of my choosing

@warsaw
Scenario: Get weather in Warsaw
	Given a webpage with a form
	And I type in 'Poland'
	And I type in 'Warsaw'
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports
