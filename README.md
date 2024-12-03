# demo-pub
demo public repo

I have successfully built and deployed the initial version of the proposed API, meeting the requirements outlined in the API document within a short span of 2 hours. While the initial version is functional, there is scope for enhancing security features such as encryption, validation, and authentication in future iterations. These additions will ensure the API adheres to standard API security practices.

Deployed API URL 

https://demoservices-fafgfnceeacnd5fw.southindia-01.azurewebsites.net/






**Test Scenario:** 
Create a .NET Web API Endpoint for Airport Routing
Test Objective:
 To create a .NET Web API endpoint that takes an origin airport as a parameter and returns a
list of destination airports.
 To ensure that the API logs the requests and responses for debugging and monitoring
purposes.
Test Steps:
1. Set up the .NET Web API Project
 Create a new .NET Web API project using Visual Studio or your preferred development
environment.
 Make sure you have all the necessary packages and dependencies installed.
2. Create an AirportController with the Desired Endpoint
 Create an AirportController class with the necessary attributes and methods.
 Implement a GET endpoint, e.g., GetDestinations, that accepts the origin airport code as a
parameter.
3. Implement the Business Logic
 Inside the GetDestinations action, write the logic to retrieve a list of destination airports
based on the origin airport provided. You may use any airports of choice with made up
routes. For example: NYC as origin airport may service the following airports: LON, PAR, LAX;
ROM etc.
 You can use a sample list of airports for testing purposes or connect to a database or
external service to fetch this information.
4. Add Logging
 Configure and implement logging within your API project. You can use a library, or the built-
in logging provided by ASP.NET Core or even a text file will be fine.
 Ensure that requests, responses, and any errors are logged for debugging and monitoring
purposes.
5. Test the API Manually
 Start the API project.
 Use tools like Postman or curl to manually test the API endpoint by sending GET requests
with various origin airports.
 Verify that the API returns the expected results and that logs are generated.

Remember that this is a high-level test scenario, and the actual implementation may vary based on
your project&#39;s specific requirements. You can adapt and expand this test scenario to suit your needs
and project specifications. 
