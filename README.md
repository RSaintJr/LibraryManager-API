# LibraryManager API

RESTful API developed in C#/.NET 10 for library collection management and loan tracking. The project applies software engineering principles, automated testing, and secure access control.

## Features

* Authentication and access control via JWT (JSON Web Tokens) with role-based authorization (Admin and Customer).
* Book collection management with database-optimized pagination and filtering support.
* Implementation of business rules for loan availability validation and return logging.
* Global exception handling using a custom Middleware.

## Tech Stack

* C# / .NET 10
* ASP.NET Core Web API
* Entity Framework Core (SQLite)
* xUnit and Moq (Unit Testing)
* Docker
* Swagger / OpenAPI

## Execution Instructions (Local)

1. Clone the repository:
   ```bash
   git clone [https://github.com/RSaintJr/LibraryManager-API.git](https://github.com/RSaintJr/LibraryManager-API.git)
   ```

2. Restore dependencies and apply database migrations:
   ```bash
   dotnet restore
   dotnet ef database update --project LibraryManager.API
   ```

3. Run the application:
   ```bash
   dotnet run --project LibraryManager.API
   ```

## Execution Instructions (Docker)

Ensure Docker is installed and running on your machine. From the solution's root directory, execute the following commands:

1. Build the application image:
   ```bash
   docker build -t librarymanager-api -f LibraryManager.API/Dockerfile .
   ```

2. Run the container mapping port 8080:
   ```bash
   docker run -d -p 8080:8080 --name library-api librarymanager-api
   ```

## Automated Tests

The unit testing coverage validates the integrity of the service business rules. To execute them, run the following command in the solution's root directory:
   ```bash
   dotnet test
   ```
