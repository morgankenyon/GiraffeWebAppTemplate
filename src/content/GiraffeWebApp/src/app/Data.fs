module GiraffeWA.Data

open Dapper
open Models
open Npgsql
open Options
open System.Data
open System.Threading

let private makeCommand (sql: string) (ct: CancellationToken) =
    new CommandDefinition(sql, ?cancellationToken = Some(ct))

let private makeParamCommand (sql: string) (dbParams: obj) (ct: CancellationToken) =
    new CommandDefinition(sql, dbParams, ?cancellationToken = Some(ct))

let private makeConnStr (dbOptions: DatabaseOptions) =
    new NpgsqlConnection(dbOptions.ConnectionString) :> IDbConnection

let private noParamSelect<'T> (dbInfo: DbInfo) (sql: string) =
    task {
        try
            use conn = makeConnStr dbInfo.DatabaseOptions
            conn.Open()

            let! result =
                makeCommand sql dbInfo.Token
                |> conn.QueryAsync<'T>

            return Ok result
        with
        | ex -> return Error ex
    }

let private singleNoParamSelect<'T> (dbInfo: DbInfo) (sql: string) =
    task {
        try
            use conn = makeConnStr dbInfo.DatabaseOptions
            conn.Open()

            let! result =
                makeCommand sql dbInfo.Token
                |> conn.QueryFirstOrDefaultAsync<'T>

            if box result = null then
                return Ok None
            else
                return Ok (Some result)
        with
        | ex -> return Error ex
    }

let private paramSelect<'T> (dbInfo: DbInfo) (sql: string) (dbParams: obj) =
    task {
        try
            use conn = makeConnStr dbInfo.DatabaseOptions
            conn.Open()

            let! result =
                makeParamCommand sql dbParams dbInfo.Token
                |> conn.QueryAsync<'T>

            return Ok result
        with
        | ex -> return Error ex
    }

let private singleParamSelect<'T> (dbInfo: DbInfo) (sql: string) (dbParams: obj) =
    task {
        try
            use conn = makeConnStr dbInfo.DatabaseOptions
            conn.Open()

            let! result =
                makeParamCommand sql dbParams dbInfo.Token
                |> conn.QueryFirstOrDefaultAsync<'T>

            if box result = null then
                return Ok None
            else
                return Ok (Some result)
        with
        | ex -> return Error ex
    }

let private insertSql (dbInfo: DbInfo) (sql: string) (dbParams: obj) =
    task {
        try

            use conn = makeConnStr dbInfo.DatabaseOptions
            conn.Open()

            let command = makeParamCommand sql dbParams dbInfo.Token
            let! insertedId = conn.ExecuteScalarAsync<int64>(command)

            return Ok insertedId
        with
        | ex -> return Error ex
    }

let private updateSql (dbInfo: DbInfo) (sql: string) (dbParams: obj) =
    task {
        try

            use conn = makeConnStr dbInfo.DatabaseOptions
            conn.Open()

            let command = makeParamCommand sql dbParams dbInfo.Token
            let! updatedCount = conn.ExecuteScalarAsync<int64>(command)

            return Ok updatedCount
        with
        | ex -> return Error ex
    }