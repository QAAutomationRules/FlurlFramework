Feature: GitHub API
	
	As a github user
	I want to be able to call the Github API to Create new Repositories, Get User Details and Delete Repositories

@Smoke
Scenario: GET User details from Github
	Given the user has a Github account
	When the user executes a GET User call
	Then the user receives a response with the correct github project details


@Smoke
Scenario: Create a new Repository in Github
	Given the user has a Github account
	When the user Creates a new GitHub Repository
	Then the github repository is created in the system

@Smoke
Scenario: Delete all Repositories in Github
	Given the user has a Github account
	When the user Deletes all GitHub Repositories
	Then the github repositories are Deleted from the system


@Smoke
Scenario:  Edit a Repository in Github
	Given the user has a Github account
	When the user Edits a Repository in Github
	Then the github repository is edited