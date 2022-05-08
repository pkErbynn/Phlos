# Phlos 
## Synopsis
Phlos is a RESTful API web application component that allows user to make sale order which is persisted into a data-store.
User can perform these core operations:
- make a sale order
- view all sold products
- other: delete an order (non-core)

## Technology stack
- PostgreSQL
- Dotnet Core 6.0
- Entity Framework
- XUnit
- Git

## Implementation Best practices
- SOLID principles
- Unit Testing
- Integration Testing
- CI/CD Pipeline with GitHub Actions
- Automated testing


## Deployment
- Heroku
- Docker Hub (https://hub.docker.com/repository/docker/pkerbynn/phlosales.api)

## Setup
### Requirements
- Visual Studio (Used 2022)

### Usage
1.  Clone this repository
```
$ git clone https://github.com/pkErbynn/Phlos.git
```
2. Open the solution with Visual Studio
3. Start the server

### Docker
1. Pull docker image from registry
```
$ docker pull pkerbynn/phlosales.api
```
3. Run image on port 8080
```
$ docker run -p 8080:80 pkerbynn/phlosales.api
```
4. Go to the API on localhost at `http://localhost:8080/api/v1/prodorders`

### Run test
```
dotnet test
```

