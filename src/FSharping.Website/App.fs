module FSharping.Website.App

open Suave
open Suave.Http
open Suave.Http.Successful
open Suave.Web
open Suave.Types
open Suave.Http.Applicatives
open System.Globalization
open Shaver.Localization

// change default bindings to avoid problems with Docker ports accesibility
let config = { defaultConfig with bindings=[ (HttpBinding.mk' HTTP  "0.0.0.0" 8083) ] }

// routing
let webPart =
    localizeUICulture >>
    choose [
        path "/" >>= OK ("Waiting... Again ;)")
        pathRegex "(.*)\.(css|js|png|otf|eot|svg|ttf|woff|woff2)" >>= Files.browseHome
    ]

startWebServer config webPart