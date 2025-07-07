# Giraffe WebApp Template

![NuGet Version](https://img.shields.io/nuget/v/GiraffeWebApp.Templates)

An opinionated full stack .NET template for the Giraffe F# framework.

## Guiding Princples

_In rough order of priority_

* Choose boring tech
  * UI is driven by HTML (via Giraffe.ViewEngine)
  * Limited Javascript
* Lean into functional paradigms
  * Limit use of dependency injection
  * Limit use of classes/OO principles
* An onion-y architecture
  * IO happens at Handler levels
  * Keep business logic pure
* Stay close to the ASP.NET Core convention
  * If you're confused about how something works in F#/Giraffe, ideally searching for the way C#/ASP.Net Core does it should help you out.

## Technology Choices

* [Giraffe](https://github.com/giraffe-fsharp/Giraffe) F# framework
  * Builds on top of ASP.NET Core
* Postgres for Database
* [DbUp](https://github.com/DbUp/DbUp) for database migrations
* [Dapper](https://github.com/DapperLib/Dapper) to handle DB queries
* [Giraffe.ViewEngine](https://github.com/giraffe-fsharp/Giraffe.ViewEngine) for UI
* [SimpleCSS](https://simplecss.org/) for styling

## How to Install

Run the following command on in a CLI:

```
dotnet new install "GiraffeWebApp.Templates::*"
```

## How to Use

When creating a template, pass the following information:

* `--name` - the name for your project
* `--DbName` - the name of your database
* `--DbSchema` - the name of your db schema

Sample command:
```
dotnet new giraffewebapp --name Gitt --DbName gitt --DbSchema dev
```

## Testing the Template Locally

To install template from source:

* Navigate to `src/content/GiraffeWebApp/`
* Run `dotnet new install ./` to install template
* Create project from template
  * `dotnet new giraffewebapp --n MyProject`

To uninstall template:
* Navigate to `src/content/GiraffeWebApp/`
* Run `dotnet new uninstall ./`

## Sources

* [Microsoft Documentation](https://learn.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-project-template)
* [Official Giraffe Template](https://github.com/giraffe-fsharp/giraffe-template/)