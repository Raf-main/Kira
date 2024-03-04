# Kira

    Console.WriteLine("Hello");

## About The Project

System for booking flights using microservice architecture.
The main goal is to gain practical skills in creating sites on a microservice architecture. My current plans are to finish writing the business logic and add infrastructure features such as event sourcing and splitting the database into write and read (CQRS). I also plan to get familiar with k8s.

## Status

Development

![](https://st.depositphotos.com/1760000/4498/i/600/depositphotos_44984037-stock-photo-3d-people-build-a-house.jpg)

## Technology stack

![C#](https://img.shields.io/badge/-C_Sharp-239120?style=for-the-badge&logo=csharp) ![.NET](https://img.shields.io/badge/-.NET-512BD4?style=for-the-badge&logo=.NET) ![JavaScript](https://img.shields.io/badge/-JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black) ![React](https://img.shields.io/badge/-ReactJs-61DAFB?style=for-the-badge&logo=react&logoColor=white) ![Redux](https://img.shields.io/badge/Redux-593D88?style=for-the-badge&logo=redux&logoColor=white) ![Postgresql](https://img.shields.io/badge/-PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white) ![MongoDB](https://img.shields.io/badge/MongoDB-4EA94B?style=for-the-badge&logo=mongodb&logoColor=white) ![RabbitMQ](https://img.shields.io/badge/rabbitmq-%23FF6600.svg?&style=for-the-badge&logo=rabbitmq&logoColor=white) ![Docker](https://img.shields.io/badge/-Docker-white?style=for-the-badge&logo=docker) ![Redis](https://img.shields.io/badge/Redis-DC382D?style=for-the-badge&logo=redis&logoColor=white)

Services

| Service  | Description | Architecture |
| --- | --- | --- |
| ApiGateway | Ocelot API Gateway | Monolithic |
| Identity | Responsible for user authentication | Monolithic |
| Flight  | Responsible for managing flights | Clean |
| Booking | Responsible for booking flights | Clean |

Patterns and principles

- Repository
- Factory
- Singleton
- Adapter (Wrapper)
- Decorator
- Mediator
- CQRS

Backend

- ASP.NET Core

UI

- React/Redux

Databases

- PostgreSQL
- MongoDB (read db, future plan)
- DB Connectivity : Entityframework Core - Code First

Features and packages

- Ocelot
- gRPC
- Swagger
- MediatR
- Fluent validation
- EF Core
- Automapper
- Serilog

Testing

- Unit (NUnit)
- Integration (NUnit)

CI/CD

- Docker
- k8s/Azure (future plan)

## Contact

If you have troubles or questions, drop a mail to rafikrrrafik@gmail.com