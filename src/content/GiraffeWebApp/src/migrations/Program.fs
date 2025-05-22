module GiraffeWA.Migrations

open DbUp

[<EntryPoint>]
let main args =
    let connStr =
        "Host=localhost;Username=postgres;Password=password123;Database=GiraffeWA_DB"

    let upgrader =
        DeployChanges
            .To
            .PostgresqlDatabase(connStr)
            .WithScriptsFromFileSystem("./Scripts")
            .WithTransaction()
            .LogToConsole()
            .Build()

    let result = upgrader.PerformUpgrade()


    0 // return an integer exit code
