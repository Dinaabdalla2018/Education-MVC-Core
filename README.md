## Project Education

This project is a web application that allows students to view available courses after signing up and logging in, and allows administrators to add and edit instructors and courses. The application uses Microsoft Identity for authentication and authorization, and is built using the ASP.NET Core MVC framework with dependency injection and token-based authentication.

### Requirements

To run the project, you will need the following:

- Visual Studio 2022
- .NET 7.0 SDK
- SQL Server Express or another SQL Server database

### Installation

To install the project, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file (`Education.sln`) in Visual Studio.
3. In Visual Studio, open the Package Manager Console and run the following command to create the database:

   ``````
   Update-Database
   ```

4. Build and run the project.

### Usage

#### Sign Up

To sign up for the application, click the "Sign Up" and enter your information.

#### Login

To log in to the application, click the "Login" and enter your email and password.

#### Viewing Courses

After logging in, you will be taken to the dashboard, where you can view available courses. Clicking on a course will take you to a page with more information about the course.

#### Adding and Editing Instructors

To add or edit instructors, you must be logged in as an administrator. Once logged in, navigate to the "Instructors" page and click the "Add Instructor" button. Fill out the form with the instructor's information and click "Save" to add the instructor to the database. To edit an existing instructor, click the "Edit" button next to their name and make the desired changes.

#### Token-based Authentication

The application uses token-based authentication to store user information in a cookie. After a user logs in, a token is generated and stored in a cookie. This token is sent with subsequent requests to authenticate the user. The token is encrypted and signed to prevent tampering.

### Security

The application uses Microsoft Identity for authentication and authorization. Users must sign up before they can log in. Only administrators have permission to add and edit instructors.

### Dependencies

The application uses the following dependencies:

- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

#### Demo
![Demo](https://github.com/Dinaabdalla2018/Education-MVC-Core/blob/main/Demo.gif)
### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
