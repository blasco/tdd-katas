# TDD-Katas

## Setting up a quick C# project with NUnit

Create a solution:
```dotnet new sln -n TDDKata```

Create the main project and add it to the solution: 
```dotnet new classlib -n TDDKata```
```dotnet sln add TDDKata/TDDKata.csproj```

Create a test project, add it to the solution, and link the main project: 
```dotnet new nunit -n TDDKata.Tests```
```dotnet sln add TDDKata.Tests/TDDKata.Tests.csproj```
```dotnet add TDDKata.Tests/TDDKata.Tests.csproj reference TDDKata/TDDKata.csproj```

(Optional) Create a console project, add it to the solution,and link the main project:
```dotnet new console -n TDDKata.Console```
```dotnet sln add TDDKata.Console/TDDKata.Console.csproj```
```dotnet add TDDKata.Console/TDDKata.Console.csproj reference TDDKata/TDDKata.csproj```

### Running the Tests
The test can be run with: 
```dotnet test```

Build the project:
```dotnet build```

Run the console project:
```dotnet run --project TDDKata.Console```
