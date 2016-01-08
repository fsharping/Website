module FSharping.Website.Pages

open Suave
open Shaver.Razor


let home : WebPart = 
    [
        ("Menu", partial "views/menu.html" "dashboard");
        ("Content", partial "views/main.html" null);
    ] |> masterPage "views/layout.html" null

let error404 : WebPart =
    [
        ("Menu", partial "views/menu.html" "dashboard");
        ("Content", partial "views/404.html" null);
    ] |> masterPageWithCode HTTP_404 "views/layout.html" null
