# Project 2: Overview
Project 2 for Revature: DBnD - Databases n' Dragons

## Technologies Used
- C#/.NET
- ASP.NET
- Angualr
- Docker
- Azure Devops
- PostgreSQL
- EntityFramework

## General Requirements For Project 2
- [ ] Angular single-page application
    - [x] client-side validation
    - [x] error handling on requests to APIs
    - [x] deployed to Azure Storage or Azure App Service
    - [ ] supports deep links
- [x] ASP.NET Core REST service
    - [x] follow standard HTTP uniform interface, except hypermedia
    - [x] architecture with separation of concerns between domain/business logic, data access, and API; repository pattern
    - [x] deployed to Azure App Service
    - [x] Entity Framework Core
        - [x] DB should be on the cloud
        - [x] not SQL Server - probably PostgreSQL
        - [x] all DB/network access should be async
    - [x] server-side validation
    - [ ] support filtering or pagination on at least one resource
    - [ ] logging
    - [ ] implement hypermedia, or, implement an API Description Language, e.g. using Swashbuckle
    - [ ] (optional: implement a custom filter, health check, or middleware, e.g. exception-handling middleware)
- [x] Azure Pipelines
    - [x] build definitions
        - [x] Unit tests
        - [x] SonarCloud
            - [x] Code coverage at least 50% for both API and Angular app
            - [x] Reliability/Security/Maintainability at least B
    - [ ] (optional: release definitions with deploy instead of in build, and with health checks)
- [x] must have some calls to an external API, or integration with some other service
- [x] authentication and authorization with Auth0
- [x] Project board to track user stories across team
- [ ] Docker (working Dockerfiles for service and for web app)
- [ ] any other tech you want within reason
- [x] the data model (how many tables, what kind of complex relationship like N to N) must be at least as complicated as project 1.
- [x] the user interaction model (what are the user stories, what inputs/interactions can the user make) must be at least as complicated as project 1.
- [x] a project proposal
    - [x] MVP minimum viable product
    - [x] potentially stretch goals, extra features


## Project Specific Functionality

