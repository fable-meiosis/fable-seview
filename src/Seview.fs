// ts2fable 0.6.1
module rec Seview
open System
open Fable.Core
open Fable.Import.JS

let [<Import("h","seview/react")>] svReact: IExports = jsNative
let [<Import("h","seview/preact")>] svPreact: IExports = jsNative
let [<Import("h","seview/mithril")>] svMithril: IExports = jsNative
let [<Import("sv","seview")>] seview: IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract sv: transform: obj option * options: obj option -> obj option
