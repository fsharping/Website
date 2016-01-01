module FSharping.Website.Pages

open Suave.Types
open Shaver.Razor


let home : WebPart = 
    [
        ("Menu", partial "views/menu.html" "dashboard");
        ("Content", partial "views/main.html" null);
    ] |> masterPage "views/layout.html" null
