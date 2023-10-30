# TinyURL-Style Service - README

## Overview
This project is a Proof of Concept (POC) for a TinyURL-style service that allows users to create short links for long URLs. It includes basic functionality to create, delete, retrieve long URLs, and track the number of times a short URL has been accessed. The service is designed to be run from the command line and does not include a web service or persistent storage.

## Getting Started
To run this POC, follow these steps:

1. Clone the repository to your local machine.

2. Ensure you have the .NET runtime installed.

3. Open the project in your preferred C# development environment (e.g., Visual Studio or Visual Studio Code).

4. Build and run the project.

## Usage
The application provides a simple command-line menu for interacting with the service. It includes the following options:

1. **Create Short URL:** Generates a short URL for a long URL. You can provide a custom short URL or let the application generate a random one.

2. **Delete Short URL:** Deletes a short URL and its associated long URL.

3. **Get Long URL:** Retrieves the long URL associated with a short URL.

4. **Get Click Count:** Retrieves statistics on how many times a short URL's long URL has been accessed (clicked).

5. **Exit:** Closes the application.

Please follow the on-screen instructions to use the service effectively.

## Components
- `URLService`: Manages the core functionality of the TinyURL-style service.
- `URLRepository`: Provides an in-memory representation of data storage.
- `ShortURLGenerator`: Generates short URLs based on a long URL.
- `Constants`: Centralizes constants and configuration settings.

## Configuration
You can configure the POC by adjusting the `Constants` class, which centralizes constants and configuration settings.

## Testing
This project includes unit tests and integrated tests for the `URLService` and `URLRepository` classes. You can run these tests to ensure the correctness and reliability of the core functionality.

## Future Enhancements
This POC provides a basic implementation of a TinyURL-style service. To make it production-ready, you can consider the following enhancements:
- Implement a web service for user interaction.
- Use a proper database for persistent storage.
- Add more advanced statistics and analytics.
- Enhance security features.

## Author
Tejas Hemant Choudhari