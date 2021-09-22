Feature: AP_Signin
	In order to be able to buy items
	As a registered user of the automation practice website
	I want to be able to signin to my account

@Login @Sad_Path
Scenario: Invalid password & email
	Given I am on the signin page
	And I have entered the email "testing@snailMail.ccm"
	And I have entered the password <passwords>
	When I click the signin button
	Then I should see an alert containing the error message "Epic sadface: Username and password do not match any user in this service"

Examples: 
	| passwords |
	| four      |
	| 1234      |
	| nish      |


@Login @Sad_Path
Scenario: No email No password given
	Given I am on the signin page
	And I have entered the email ""
	And I have entered the password ""
	When I click the signin button
	Then I should see an alert containing the error message "Epic sadface: Username is required"


@Login @Happy_Path
Scenario: Correct email and password takes me to userPage
	Given I am on the signin page
	And I have entered the email "standard_user"
	And I have entered the password <password>
	When I click the signin button
	And i move to user page
	And I click on the backPack item
	Then I should be in the item page containing the Url "https://www.saucedemo.com/inventory-item.html?id=4"
	
Examples: 
	| passwords |
	| secret_sauce|
	