# Best News Stories from Hacker News API

## Description
This repository contains a RESTful API built with ASP.NET Core to retrieve the details of the best n stories from the Hacker News API, sorted by their score. The number n of stories to retrieve is specified by the caller to the API.

## How to Run the application
To run the application locally, follow these steps:

1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/SohailSattar/Hacker-News-API-Best-News.git
   ```
2. Make sure you have the .NET 8.0 SDK installed. If not, you can download it from [here](https://dotnet.microsoft.com/download).
3. Navigate to the root directory of the project in your terminal.
5. Run the following commands to build and run the application:
   ```bash
   dotnet build
   dotnet run --project .\BestNews.API\BestNews.API.csproj
   ```
5. The API will be accessible at [https://localhost:7185](https://localhost:7185/swagger/index.html) (or [http://localhost:5188](http://localhost:5188/swagger/index.html)). 


## Features
1. **Separation of Concerns:** Separate projects for different concerns such as API layer, application layer, and data access layer promote modularity and maintainability.
2. **DTO (Data Transfer Object):** Use of DTOs helps in encapsulating data transferred between layers, enhancing data integrity and decoupling dependencies.
3. **Error Handling:** Robust error handling mechanisms gracefully handle different types of errors, providing informative error messages and appropriate HTTP status codes to clients.
4. **Dependency Injection:** Individual service registration and dependency injection facilitate loose coupling and promote testability and maintainability.
5. **Mediator Design Pattern:** Implementing the Mediator design pattern helps in decoupling communication between components and simplifying complex request/response handling.

By incorporating these changes and enhancements, the application becomes more robust, efficient, and secure, providing a better experience for both developers and end-users.
   
## API Endpoints
### Get Best Stories
#### Request
 **GET /api/stories/best/{number}**
 Retrieves the best n stories from the Hacker News API, where n is the number specified by the caller. The story IDs are retrieved from https://hacker-news.firebaseio.com/v0/beststories.json.

#### Parameters:
number: The number of best stories to retrieve.

#### Response:
Returns an array of the best n stories in descending order of score, in JSON format.

#### Example response:
Example response:
```json
[
   {
    "title": "Game of Life, simulating itself, infinitely zoomable",
    "uri": "https://oimo.io/works/life/",
    "postedBy": "surprisetalk",
    "time": "2024-03-23T17:24:02+04:00",
    "score": 1436,
    "commentCount": 240
  },
  {
    "title": "Show HN: Memories – FOSS Google Photos alternative built for high performance",
    "uri": "https://memories.gallery/",
    "postedBy": "radialapps",
    "time": "2024-03-21T23:25:10+04:00",
    "score": 774,
    "commentCount": 228
  },
  {
    "title": "Picotron Is a Fantasy Workstation",
    "uri": "https://www.lexaloffle.com/picotron.php",
    "postedBy": "celadevra_",
    "time": "2024-03-22T06:48:23+04:00",
    "score": 663,
    "commentCount": 187
  }
]
```

## Assumptions
* The application assumes that the Hacker News API is accessible and provides the expected response format.
* Caching mechanism is implemented using IDistributedCache to optimize performance and prevent overloading the Hacker News API.

## Enhancements or Changes
Given more time, here are some enhancements or changes that could be made to the application:
1. **Unit Testing:** Write comprehensive unit tests to ensure the correctness of the application's functionality.
2. **Pagination:** Add support for pagination in the API response to handle large numbers of stories more efficiently.
3. **Logging:** Implement logging to record important events and debug information for easier troubleshooting.
4. **Rate Limiting:** Introduce rate limiting to prevent abuse of the API and ensure fair usage.
5. **Authentication and Authorization:** Add authentication and authorization mechanisms to secure the API endpoints.
6. **Redis Caching:** Utilize Redis as a caching mechanism to improve performance and scalability. Redis is an in-memory data store that can be used to cache frequently accessed data, reducing the need to fetch data from external APIs repeatedly. Integrate Redis with the application to store and retrieve cached data efficiently, thereby reducing response times and improving overall system performance.
