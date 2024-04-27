# Console application

## Part 1

The application expects the user to supply two arguments. It has some basic validation to make sure both arguments are
not empty or above 255 characters.
Based on my interpretation of the specification, the application is set up to only handle integers, floats and strings
as arguments.
If both arguments are successfully parsed the extension method will try to combine the arguments and display the result.
It will handle if numeric values are too large to be parsed as integers or floats.
Integers and floats can be added together, while strings will be concatenated. 
Floats are expected to use a period as a decimal separator.

Example of how to run the application:

**Bash/Zsh**

```sh
dotnet run 6 4 --project src/ConsoleApp/     # 10
dotnet run 2.1 0.4 --project src/ConsoleApp/ # 2.5
dotnet run foo bar --project src/ConsoleApp/ # foobar
```

**PowerShell**

```ps1
dotnet run 6 4 --project src\ConsoleApp\     # 10
dotnet run 2.1 0.4 --project src\ConsoleApp\ # 2.5
dotnet run foo bar --project src\ConsoleApp\ # foobar
```

The popular testing framework xUnit.net is used to verify that the extension method works as expected. The tests are
located in [ArgumentExtensionsTests](tests/ConsoleApp.Tests/ArgumentExtensionsTests.cs).

Run the tests with `dotnet test`.

## Part 2

The application uses MySQL as a database to store the program arguments. In order to run the application with the
database, you can either install MySQL directly or use Docker with `docker compose up -d` to pull down an image and spin
up the database. See [docker-compose.yml](docker-compose.yml) for how the database is configured.

Entity Framework (EF) is used as an ORM to perform database operations. The code repository contains an initial
migration script. On startup, the application will try to migrate any pending database changes, to make sure it is
up-to-date.

If the program arguments were successfully parsed, they will be saved to the database. Afterward all the rows will be
retrieved and printed for the user. The application has some basic error handling regarding the database operations by
catching specific SQL exceptions first and then catching any other errors as a fallback. EF uses parameterized queries,
so the risk of SQL injections are minimised.

Due to that fact that the arguments are only added together in the first part, I have chosen to store the arguments in the
database as strings for simplicity.
