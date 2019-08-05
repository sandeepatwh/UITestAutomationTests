Feature: ItemPurchase
	In order to make sure new functionality didnt break

Background: 
	Given User navigates to login screen
	And User logins with following credentials
	| Email                    | Password |
	| sandysomu@gmail.com	   | Password123 |



Scenario: Single Item order placement
	When User select the category
	And User finishes adding single item in the cart
	When User places the order
	Then Order is successfuly placed


Scenario: Verify search result
	When User searches the website with dresses criteria
	Then Number of items appear as 7 in Top Seller and Best Seller section



