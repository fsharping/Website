module FSharping.Website.App

open Suave
open Suave.Http
open Suave.Web
open Shaver.Localization
open Suave.Filters
open Suave.Operators
open System.Net

// change default bindings to avoid problems with Docker ports accesibility
let config = { defaultConfig with bindings=[ HttpBinding.mk HTTP (IPAddress.Parse "127.0.0.1") 8083us ] }

// routing
let webPart =
    localizeUICulture >>
    choose [
        path "/" >=> Pages.home
        path "/blog" >=> Pages.home
        path "/meetups" >=> Pages.home
        pathRegex "(.*)\.(css|js|png|otf|eot|svg|ttf|woff|woff2|ico|xml|json)" >=> Files.browseHome
    ]

startWebServer config webPart