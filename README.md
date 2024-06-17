Overview : The NameParser API is a service that parses full names into their respective components: title, forename, middle name, and surname. It validates the input to ensure it is well-formed and contains valid characters.

Project Structure
NameParser.cs: Contains the logic for parsing full names.
Program.cs: Sets up the web application and dependency injection.
ParseNameController.cs: Defines the API endpoint for parsing names.

Code Explanation
NameParser Class
The NameParser class implements the INameParser interface and provides the ParseFullName method to break down a full name into its components.

Web API Configuration
The Program.cs file sets up the web application and configures the services, including Swagger for API documentation and testing.

API Controller
The ParseNameController handles the incoming HTTP requests to parse the full name.

Testing the API with Swagger
Swagger is integrated into the project for easy testing and documentation of the API.

Run the Project: Start the application (usually by running dotnet run).
Test the Endpoint: https://localhost:7023/api/ParseName/parse-name.
Click on the ParseName endpoint.
Click Try it out.
Enter a JSON object with the FullName property.
Click Execute to see the parsed name components.







