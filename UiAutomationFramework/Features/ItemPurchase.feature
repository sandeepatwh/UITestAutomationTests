Feature: ItemPurchase
	In order to make sure new functionality didnt break

Background: 
	Given User navidates to login screen
	And User logins with following credentials
	| Email                    | Password |
	| sandysomu@gmail.com | Password123 |


@mytag
Scenario: Multiple Items order placement
	When User select the category
	And User finishes adding single item in the cart
	When User places the order
	Then Order is successfuly placed




