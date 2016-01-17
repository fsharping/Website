module FSharping.Website.Serialization

open Newtonsoft.Json
open Newtonsoft.Json.Serialization

let private settings = new JsonSerializerSettings()
settings.ContractResolver <- CamelCasePropertyNamesContractResolver()

let serializeReadable obj = JsonConvert.SerializeObject(obj, Formatting.Indented, settings)
let serialize obj = JsonConvert.SerializeObject(obj, settings)
let deserialize<'a> json = JsonConvert.DeserializeObject<'a>(json)