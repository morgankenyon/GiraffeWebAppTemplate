module GiraffeWA.Views

open Giraffe.ViewEngine
open Models

let layout (content: XmlNode list) =
    html [] [
        head [] [
            title []  [ encodedText "GiraffeWA" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/main.css" ]
        ]
        body [] content
    ]

let partial () =
    h1 [] [ encodedText "GiraffeWA" ]

let index (model : Message) =
    [
        partial()
        p [] [ encodedText model.Text ]
    ] |> layout