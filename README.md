# Fable seview bindings: WIP

Fable bindings for [Seview](https://github.com/foxdonut/seview) the S-Expression View, a wrapper for html/VDOM builder DSLs.

seview currently supports:

- [Mithril](https://github.com/foxdonut/seview#mithril)
- [Preact](https://github.com/foxdonut/seview#preact)
- [React](https://github.com/foxdonut/seview#react)

## Usage

`seview` exports a single function, `sv`, that you use to obtain a function which you can name as you wish; in the examples, I name this function `h`. Calling `h(view)`, where view is the view expressed as arrays as we have seen above, produces the final result suitable for your virtual DOM library.

When you call `sv`, you pass it a function that gets called for every node in the view.

Each node has the following structure:

```js
{
  tag: "button",
  attrs: { id: "save", className: "btn btn-default", ... }
  children: [ ... ]
}
```

Perhaps try:

```fsharp
type ChildTree =
    | Child
    | Composite of ChildTree list
```

### Fable usage

We will have to add a full DSL similar to how Fable does it for [fable-react](https://github.com/fable-compiler/fable-react/blob/master/src/Fable.React/Fable.React.Standard.fs#L4)

```fsharp
open Seview

let txt = Some "hello"
h1 (Some "hello") None
h1 txt None
txt1 "hello world"
```

## Why?

Seview can be used with the excellent [Meiosis pattern](https://meiosis.js.org/) as a building block for next gen _elmish_ like architecture.

## Status

WIP: Not yet tested

## Overview

The bindings in `Seview.fs` were created using `seview.d.ts`, created from the seview module using [dts](https://github.com/Microsoft/dts-gen#how-do-i-use-it) CLI.

More resources:

- [fable-meiosis](https://github.com/fable-meiosis)
- [fable2-samples](https://github.com/fable2-samples)

## Requirements

- [dotnet SDK](https://www.microsoft.com/net/download/core) 2.1 or higher
- [Paket](https://fsprojects.github.io/Paket/installation.html) to manage F# dependencies
- [node.js](https://nodejs.org) with [npm](https://www.npmjs.com/)
- An F# editor like Visual Studio, Visual Studio Code with [Ionide](http://ionide.io/) or [JetBrains Rider](https://www.jetbrains.com/rider/).

## Building and running the app

### install JS dependencies

- `yarn install`

### install F# dependencies

- Windows: `.paket/paket.exe install` or `yarn run paket`
- Non-Windows: `mono .paket/paket.exe install` or `yarn run paket:mono`

Alternatively install paket as a global .NET tool

```bash
$ dotnet tool install --tool-path ".paket" Paket --add-source https://api.nuget.org/v3/index.json --framework netcoreapp2.1
```

With defaults, try simply: `$ dotnet tool install Paket`

In this case, make sure that the install location of `paket` is in your system `PATH`, see: [dotnet-tool-install](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install)

### Start and run

- `npm start` to compile and watch with fable-splitter.

Alternatively:

- `npm run build` - same but outputs javascript to `/out`.

## Add F# Modules

While fable-splitter is watching with one of above `npm` commands:

- Add `nuget ModuleName` to paket.dependencies and run paket install command above.
- Add `ModuleName` to src/paket.references

## Source Files

- `App.fsporj` - add source paths here. Note `paket.references` is referenced here.
- `App.fs` - starting point.
- `Util/File.fs` - sample lib file.
