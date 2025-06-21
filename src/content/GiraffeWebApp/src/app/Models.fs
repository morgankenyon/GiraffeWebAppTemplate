module GiraffeWA.Models

open Options
open System.Threading


type Message =
    {
        Text : string
    }

type DbInfo =
    { DatabaseOptions: DatabaseOptions
      Token: CancellationToken }