# Releasing a New Version

* Ensure the version is updated in the `./GiraffeWebApp.Templates.csproj` file.
* Run `pack.ps1` in this directory.
* In the `./bin/Release/` directory you should see a new `*.nupkg` file corresponding to the build specified in the `*.csproj` file.
* Upload this package to nuget.org.