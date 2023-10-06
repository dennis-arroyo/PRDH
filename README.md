# Objective

Develop a service that connects to an API endpoint, fetches laboratory tests, and identifies cases for patients with positive tests. Each case should be associated with the earliest positive test for the patient.

# Tools
Integrated Development Environment
- JetBrains Rider 2023.2.2
  
Backend Development
- ASP.NET 7.0.4
- Entity Framework 7.0.11
- Entity Framework SQLite 7.0.11
  
Frontend Development
- Angular CLI 16.2.4
- Node 18.16.0
- NPM 9.5.1

API Testing Tools
- Swagger
- Postman

# Design Choices

Backend Design Pattern

The chosen design pattern for the backend was the Service Layer and Repository Layer design patterns. 

Service Layer:

The Service Layer's role is to encapsulate the business logic of the application and offer an elevated interface for the presentation or controller layer. It serves as a bridge between the presentation layer, such as controllers or API endpoints, and the data access layer, which includes repositories or data access code. Furthermore, the service layer integrates Dependency Injection (DI) by providing service instances to your controllers and other components. This approach promotes loose coupling and enhances testability, enabling you to effortlessly substitute implementations for testing or future modifications.

Repository Layer:

The Repository Layer abstracts and encapsulates the data access code for your application. It provides a clean and consistent interface for accessing and manipulating data from various data sources, such as databases or external APIs.

Frontend Design Pattern

A particular design pattern was not explicitly employed but features like the Service Layer found in the backend implementation were incorporated. TypeScript service files were generated within the Angular components to manage logic and execute requests to the relevant endpoints.

# Challenges
As an experienced software developer in the industry, I've observed that most of the projects I've been assigned to have typically already been developed. My role primarily involves expanding features, optimizing code, and addressing reported bugs. However, when tasked with creating a project from scratch, I encountered some challenges related to configurations. Fortunately, with the assistance of thorough documentation, I successfully built the project.

Endpoint crashing when due to max response limit:

One notable challenge I encountered was related to a maximum response limit error while testing endpoints. Typically, I use tools like Postman or Swagger to test endpoints. However, I faced an issue when using Swagger to test a provided endpoint, as it would crash when requesting data for a relatively large date range. Initially, I suspected a problem with the endpoint itself, but upon testing it with Postman, I realized the issue was related to a maximum response limit. I resolved this by adjusting the maximum limit setting in Postman, which was initially set to 50MB, allowing me to receive a larger dataset.

Upon requesting order tests for the period from January 1 to June 30, 2023, I received a 58MB dataset, which explained why I wasn't receiving the required information. Subsequently, I made the necessary backend adjustments to handle larger data requests.

Pagination in frontend:

Specializing in backend development, I have worked with frontend tools as well. However, implementing pagination on the frontend was a new task for me. Nevertheless, with the assistance of comprehensive documentation from Bootstrap and Angular, a functional pagination system was successfully implemented for the Covid Case Summary table component

# Running the project
Clone the project into your local directory:
   
  - Use the git clone command and the following URL https://github.com/dennis-arroyo/PRDH.git
  - Command: git clone https://github.com/dennis-arroyo/PRDH.git
    
Open your preferred IDE such as Visual Studio or Rider.
    
Click on open project or solution.

Under Run Configurations select PRDH:http

To run the API, click Run.

To run the client application, follow these steps:

   - Open up your command-line and navigate to the ClientApp directory.
   - Type the command npm install
   - Type the command ng serve
   - The application should be running under http://localhost:4200
