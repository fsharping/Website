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

module Blog =
    
    let rss =
        let posts = Blog.getPosts |> Seq.toList
        singlePage "views/blog/rss.html" posts

    let index =
        let posts = Blog.getPosts |> Seq.toList
        [
            ("Menu", partial "views/menu.html" "blog");
            ("Content", partial "views/blog/index.html" posts);
        ] |> masterPage "views/layout.html" null

    let detail rewrite =
         warbler 
            (fun _ ->
                let post = Blog.getPosts |> Seq.find (fun x -> x.Rewrite = rewrite)
                let title = post.Title + " - "
                [
                    ("Menu", partial "views/menu.html" "blog");
                    ("Content", partial "views/blog/detail.html" post);
                ] |> masterPage "views/layout.html" title
            )