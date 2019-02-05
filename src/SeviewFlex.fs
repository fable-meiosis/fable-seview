// ts2fable 0.6.1
module rec SeviewFlex
open Fable.Core
open System

let [<Import("*","seview/react")>] hr: IExportViewLib = jsNative
let [<Import("*","seview/preact")>] hp: IExportViewLib = jsNative
let [<Import("*","seview/mithril")>] hm: IExportViewLib = jsNative
let [<Import("*","seview")>] sv: IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract sv: transform: transformFn * options: obj option -> obj option

type [<AllowNullLiteral>] IExportViewLib =
    abstract h: children: 'a list -> obj option

type [<AllowNullLiteral>] transformFn =
    [<Emit "$0($1...)">] abstract Invoke: node: 'a option -> 'b

type [<AllowNullLiteral>] sv =
    [<Emit "$0($1...)">] abstract Invoke: transform: transformFn * options: obj -> h

type Child =
    string

type Children = Child array

type [<AllowNullLiteral>] h =
    [<Emit "$0($1...)">] abstract Invoke: children: U2<Child, Children> array -> 'b option