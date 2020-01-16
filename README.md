# Simple architecture for Xamarin forms
Here I demonstration a simle architecture which automatically guide you to write loosely coupled and more maintainable code using Xamarin forms.

## Project Architecture Diagram
![alt text](https://github.com/shuvo009/xamarin-forms-HackerNewsClient/blob/master/ProjectDiagram.PNG "Logo Title Text 1")


## Core Project (HackerNewsClient.Core)
All of other projects like as HackerNewsClient, HackerNewsClient.Repository, HackerNewsClient.Service etc are refer on this project. All kind of share code or classes like as Interface, Models, Constants etc are goes here. I create several directory for organize code.
* **Classes** directory is use for Utility, Constants and more.
* **Interface** directory is use for Interfaces
* **Models** directory is use for Models, ViewModels

NOTE: You can create more directory here as much as you need.

## Repository Project (HackerNewsClient.Repository)
All kind of database related code are goes here. you have to create repository for each table of database and all repository must inherit from GenericRepository and you have to also create Interface for each repository.
