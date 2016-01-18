module FSharping.Website.App

open Suave
open Suave.Http
open Suave.Web
open Shaver.Localization
open Suave.Filters
open Suave.Operators
open System.Net
open Suave.Writers

let mimeTypes =
  defaultMimeTypesMap
    @@ (function | ".woff2" -> mkMimeType "application/font-woff2" false | _ -> None)

// change default bindings to avoid problems with Docker ports accesibility
let config = { defaultConfig with bindings=[ HttpBinding.mk HTTP IPAddress.Any 8083us ]; mimeTypesMap = mimeTypes }

// routing
let webPart =
    localizeUICulture >>
    choose [
        path "/" >=> Pages.home
        path "/blog" >=> Pages.Blog.index
        path "/blog/rss.xml" >=> Pages.Blog.rss
        pathScan "/blog/%s" (fun rewrite -> Pages.Blog.detail rewrite)
        path "/meetups" >=> Pages.home
        pathRegex "(.*)\.(css|js|png|otf|eot|svg|ttf|woff|woff2|ico|xml|json)" >=> Files.browseHome
        pathRegex "(.*)" >=> Pages.error404
    ]

startWebServer config webPart