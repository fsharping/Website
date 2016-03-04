module FSharping.Website.Pages

open System
open Suave
open Shaver.Razor

let private meetups = Meetups.getMeetups |> Seq.toList
let private upcomingMeetups = meetups |> List.filter (fun x -> x.Start > DateTime.Now)
let private blogposts = Blog.getPosts |> Seq.toList

let home : WebPart =
    [
        ("Menu", partial "views/menu.html" "home");
        ("Content", 
            [("LeftCol",
                [("Blog", partial "views/main/leftColBlog.html" blogposts);
                 ("Meetups", partial "views/main/leftColMeetups.html" upcomingMeetups)
                ] |> nested "views/main/leftCol.html" null);
        
            ] |> nested "views/main/index.html" null);
    ] |> masterPage "views/layout.html" null

let error404 : WebPart =
    [
        ("Menu", partial "views/menu.html" "home");
        ("Content", partial "views/404.html" null);
    ] |> masterPageWithCode HTTP_404 "views/layout.html" null

let private makeTitle txt = sprintf "%s - " txt

let private title key = 
    match Shaver.Resources.getValue "Texts" key <| Some(System.Globalization.CultureInfo.CurrentCulture) with
    | Some(txt) -> makeTitle txt
    | None -> ""

module Meetups =
    
    let rss = singlePage "views/meetups/rss.html" (meetups |> List.rev)

    let index = 
        [
            ("Menu", partial "views/menu.html" "meetups");
            ("Content", partial "views/meetups/index.html" upcomingMeetups);
        ] |> masterPage "views/layout.html" (title "Meetups")

module Blog =
    
    let rss = singlePage "views/blog/rss.html" (blogposts |> List.rev)

    let index =
        let posts = Blog.getPosts |> Seq.toList
        [
            ("Menu", partial "views/menu.html" "blog");
            ("Content", partial "views/blog/index.html" posts);
        ] |> masterPage "views/layout.html" (title "Blog")

    let detail rewrite = warbler (fun _ ->
        let post = Blog.getPosts |> Seq.find (fun x -> x.Rewrite = rewrite)
        [
            ("Menu", partial "views/menu.html" "blog");
            ("Content", partial "views/blog/detail.html" post);
        ] |> masterPage "views/layout.html" (makeTitle post.Title)
    )