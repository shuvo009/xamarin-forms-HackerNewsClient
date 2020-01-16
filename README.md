# Simple architecture for Xamarin forms
Here I demonstration a simle architecture which automatically guide you to write loosely coupled and more maintainable code using Xamarin forms.

## Project Architecture Diagram
![alt text](https://github.com/shuvo009/xamarin-forms-HackerNewsClient/blob/master/ProjectDiagram.PNG "Logo Title Text 1")


## Core Project (HackerNewsClient.Core)
All of other projects like as HackerNewsClient, HackerNewsClient.Repository, HackerNewsClient.Service etc are refer on this project. All kind of share code or classes like as Interface, Models, Constants etc are goes here. I create several directory for organize code.
* **Classes** directory is used for Utility, Constants and more.
* **Interface** directory is used for Interfaces
* **Models** directory is used for Models, ViewModels

NOTE: You can create more directory here as much as you need.

## Repository Project (HackerNewsClient.Repository)
All kind of database related code are goes here. You have to create repository for each table of database and all repository must be inherit from GenericRepository and you have to also create Interface at core project and implement here for each repository like as StoryRepository. I use **Realm** as a database and **AutoMapper** to copy data from DatabaseModel to Model automatically.

* **DbModels** directory is use for database Models

## Service Project (HackerNewsClient.Service)
All kind of business logic are goes here and also third party services are integate here. You have to create Interface for each service at **core** project and implement here. I implemented **RestService** class which will help you to call API.

* **AppServices** directory is used for implement business logics.
* **CommonServices** directory is used for integrate third party services.

