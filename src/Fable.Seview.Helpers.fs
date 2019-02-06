// ts2fable 0.6.1
module rec Fable.Seview.Helpers

open System
open Fable.Core
open Fable.Import.JS
open Fable.Core.JsInterop

// auto-open?
open Fable.Seview.Props

let [<Import("*","seview/react")>] react: IExportViewLib = jsNative
let [<Import("*","seview/preact")>] preact: IExportViewLib = jsNative
let [<Import("*","seview/mithril")>] mithril: IExportViewLib = jsNative
let [<Import("*","seview")>] seview: IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract sv: transform: obj option * options: obj option -> obj option

type [<AllowNullLiteral>] IExportViewLib =
    abstract h: children: ChildTree -> obj option

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

// generated from ts2fable
type [<AllowNullLiteral>] h =
    [<Emit "$0($1...)">] abstract Invoke: children: Children -> obj option

type [<AllowNullLiteral>] Element =
    interface end

[<Emit("h([$0, $1, $2])")>]
let createElement(comp: obj, props: obj, [<ParamList>] children: obj): Element =
    jsNative

let inline domEl (tag: string) (props: IHTMLProp seq) (children: Element seq): Element =
    createElement(tag, keyValueList CaseRules.LowerFirst props, children)

