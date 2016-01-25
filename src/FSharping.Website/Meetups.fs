module FSharping.Website.Meetups

open System
open System.IO
open Newtonsoft.Json.Linq
open Serialization

type Gps = {
    Lat : decimal;
    Lon : decimal;
}

type Meetup = {
    Title : string;
    Rewrite: string;
    Start: DateTime;
    Description : string;
    Address: string;
    Gps : Gps
}

let private path src = "data/meetups/" + src
let private indexFile = "index.json"

let getMeetups =
    let json = indexFile |> path |> File.ReadAllText  |> JObject.Parse
    json.["meetups"]
    |> Seq.map (fun x -> deserialize<Meetup>(x.ToString()))
