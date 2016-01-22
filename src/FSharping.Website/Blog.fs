module FSharping.Website.Blog

open System
open System.IO
open Newtonsoft.Json.Linq
open Serialization
open FSharp.Markdown

type Blogpost = {
    Title : string;
    Perex: string;
    Rewrite : string;
    File : string;
    Published : DateTime;
    Author: string;
    Markdown : string;
    Html : string;
}

let private blogPath src = "data/blog/" + src
let private indexFile = "index.json"
let private perexMark = "[comment]:Perex"

let private withMarkdown post =
    let markdown = post.File |> blogPath |> File.ReadAllText
    {post with Markdown = markdown}

let private withHtml post =
    {post with Html = Markdown.TransformHtml(post.Markdown)}

let private withPerex post =
    let perex = post.Markdown.Split([|perexMark|], StringSplitOptions.RemoveEmptyEntries)
    match perex.Length with
    | 2 -> {post with Perex = perex.[0]}
    | _ -> {post with Perex = post.Html}

let getPosts =
    let json = indexFile |> blogPath |> File.ReadAllText  |> JObject.Parse
    json.["posts"]
    |> Seq.map (fun x -> deserialize<Blogpost>(x.ToString()))
    |> Seq.map withMarkdown
    |> Seq.map withHtml
    |> Seq.map withPerex
