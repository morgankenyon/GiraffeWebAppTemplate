# GiraffeWebAppTemplate

An opinionated full stack .NET template for the Giraffe F# framework.

## Guiding Princples

* Choose boring tech
  * UI is driven by HTML (via Giraffe.ViewEngine)
  * Limited Javascript
* Lean into functional paradigms
  * Limit use of denpendency injection
  * Limit use of classes/OO principles
* An onion-y architecture
  * IO happens at Handler levels
  * Keep business logic pure
* Stay close to the .NET ecosystem
  * Mimic how things are already done in C#/ASP.NET Core
  * If you're confused about something, ideally searching for the way C# does it would get you halfway there.

Principles are roughly in order of importance.

## Technology Choices

* [Giraffe](https://github.com/giraffe-fsharp/Giraffe) F# framework
  * Builds on top of ASP.NET Core
* Postgres for Database
* [DbUp](https://github.com/DbUp/DbUp) for database migrations
* [Dapper](https://github.com/DapperLib/Dapper) to handle DB queries
* [Giraffe.ViewEngine](https://github.com/giraffe-fsharp/Giraffe.ViewEngine) for UI
* [SimpleCSS](https://simplecss.org/) for styling

## How to Generate

TBD - still working on getting everything set and then will publish to nuget for usage.

## Testing the Template

To install template from source:

* Navigate to `src/content/GiraffeWebApp/`
* Run `dotnet new install ./` to install template
* Create project from template
  * `dotnet new giraffewebtemplate --n MyProject`

To uninstall template:
* Navigate to `src/content/GiraffeWebApp/`
* Run `dotnet new uninstall ./`

## Sources

* [Microsoft Documentation](https://learn.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-project-template)
* [Official Giraffe Template](https://github.com/giraffe-fsharp/giraffe-template/)