# .NET 9 API Gateway with Ocelot

## Overview
Focused .NET 9 API Gateway example using Ocelot to route and aggregate requests across multiple downstream microservices.

## Architecture
```text
Client -> .NET 9 Ocelot Gateway -> Orders API
                              |--> Products API
                              |--> Users API
```

## Key Responsibilities
- Single API entry point for clients
- Route requests to downstream services
- Aggregate responses when appropriate
- Hide internal service topology
- Provide a foundation for cross-cutting concerns

## Step-by-Step Flow
1. Client sends a request to the gateway.
2. Ocelot matches the configured route.
3. Gateway forwards the request to the appropriate downstream service.
4. Downstream service executes business logic.
5. Gateway returns the response to the client.
6. Aggregation can combine data from multiple services for client-friendly responses.

## Why This Architecture?
Without a gateway, clients may need to know every internal service endpoint. The gateway reduces client coupling and creates a controlled boundary around the microservices platform.

## Technology Stack
`C#` `.NET 9` `ASP.NET Core` `Ocelot` `API Gateway` `Microservices` `REST APIs` `Distributed Systems`

## LinkedIn Project Description
**Implemented a .NET 9 API Gateway with Ocelot to route and aggregate multiple microservices, demonstrating centralized routing, service abstraction and scalable distributed-system architecture.**

## Recommended Production Enhancements
- JWT/OAuth2 authentication
- Rate limiting
- Resilience/circuit breakers
- Correlation IDs
- Centralized logging
- OpenTelemetry
- Health checks
- API versioning
- Docker/Kubernetes
- CI/CD

## Repository
https://github.com/NaraP/A-.NET-9-API-Gateway-built-with-Ocelot-to-route-and-aggregate-multiple-microservices
