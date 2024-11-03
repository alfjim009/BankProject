# Bank Project Microservices

This project, **Bank Project**, contains multiple microservices for handling banking operations and user management, including:
- `operationservice`: Manages account operations.
- `userservice`: Manages user-related information.
- `sqlserverdocker`: A Microsoft SQL Server database used by both services.

## Prerequisites

- [Docker](https://docs.docker.com/get-docker/) installed on your machine.
- [Docker Compose](https://docs.docker.com/compose/install/) installed and configured.

## Docker Compose Overview

The `docker-compose.yml` file sets up the following three main services:
1. **operationservice**: Exposes ports 5000 and 5001.
2. **userservice**: Exposes ports 8080 and 8081.
3. **sqlserverdocker**: SQL Server container for database operations, mapped to port 8100.

All services are connected over a shared network `bank-network` for internal communication.

## Services Configuration

### 1. operationservice
This service runs the **Operation Service** application, handling banking-related operations.
- **Ports**: `5000` and `5001`
- **Depends on**: `sqlserverdocker` (waits for the database to start)

### 2. userservice
This service runs the **User Service** application, managing user-related information.
- **Ports**: `8080` and `8081`
- **Depends on**: `sqlserverdocker` (waits for the database to start)

### 3. sqlserverdocker
This container runs a Microsoft SQL Server instance, used as the database for both `operationservice` and `userservice`.
- **Container Name**: `sql-server-docker`
- **Image**: `mcr.microsoft.com/mssql/server:2022-latest`
- **Ports**: Exposed on port `8100` mapped to SQL Server's default port `1433`
- **Environment Variables**:
  - `ACCEPT_EULA=Y`: Required to accept the SQL Server license agreement.
  - `MSSQL_SA_PASSWORD=MyPassword*1234`: Sets the system administrator (SA) password for the database.

### Network
All services are connected via the Docker network `bank-network`, enabling internal communication.

## Getting Started

1. Clone this repository to your local machine.
2. Ensure you are in the root project directory (where `docker-compose.yml` is located).
3. Start the services using Docker Compose:

   ```bash
   docker-compose up -d
   ```
    Or run the docker compose with your Visual Studio.