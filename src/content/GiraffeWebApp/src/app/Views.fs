module GiraffeWA.Views

open Giraffe.ViewEngine
open Giraffe.ViewEngine.Htmx
open Models

module Partials =
    let homePartial () =
        div [] [ str "Home partial Hello"]

let layout (content: XmlNode list) =
    html [] [
        head [] [
            title []  [ encodedText "GiraffeWA" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/main.css" ]
        ]
        body [] [
            div [] content
            script [ _src "htmx.min.js" ] []
        ]
    ]

let index (model : Message) =
    [
        h1 [] [ encodedText "GiraffeWA" ]
        p [] [ encodedText model.Text ]
        div [ _hxGet "/homePartial"; _hxTrigger "load" ] [ str "Loading" ]
    ] |> layout