// ts2fable 0.6.1
module rec Seview
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","seview/react")>] react: IExportViewLib = jsNative
let [<Import("*","seview/preact")>] preact: IExportViewLib = jsNative
let [<Import("*","seview/mithril")>] mithril: IExportViewLib = jsNative
let [<Import("*","seview")>] seview: IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract sv: transform: obj option * options: obj option -> obj option

type [<AllowNullLiteral>] IExportViewLib =
    abstract h: children: Children -> obj option

type element =
    obj

type [<AllowNullLiteral>] transformFn =
    [<Emit "$0($1...)">] abstract Invoke: node: obj option -> element

type [<AllowNullLiteral>] sv =
    [<Emit "$0($1...)">] abstract Invoke: transform: transformFn * options: obj -> h

type ChildTree = 
    | Child 
    | Composite of ChildTree list

type Child =
    string

type [<AllowNullLiteral>] ChildArray =
    inherit Array<Children>

type Children =
    U2<Child, ChildArray>

[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Children =
    let ofChild v: Children = v |> U2.Case1
    let isChild (v: Children) = match v with U2.Case1 _ -> true | _ -> false
    let asChild (v: Children) = match v with U2.Case1 o -> Some o | _ -> None
    let ofChildArray v: Children = v |> U2.Case2
    let isChildArray (v: Children) = match v with U2.Case2 _ -> true | _ -> false
    let asChildArray (v: Children) = match v with U2.Case2 o -> Some o | _ -> None

type [<AllowNullLiteral>] h =
    [<Emit "$0($1...)">] abstract Invoke: children: Children -> obj option