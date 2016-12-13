This blog post is part of [F# Advent 2016](https://sergeytihon.wordpress.com/2016/10/23/f-advent-calendar-in-english-2016/).

Funny. Reading all already published F# Advent posts and thinking: "Man, F# advent has readers across the world, most of them are kick-ass smart functional brains eager to read more and more amazing functional code and you are going to post article about F# with actually *no single line* of code? Good luck with that. Maybe this would be the first codeless F# blogpost ever! What could possibly go wrong?" Ok, I\`ll do it anyway. So here it is:

[comment]:Perex

Let me tell you short story about how we created F# community in Czech Republic and what I learned from it.

At the very beginning there was one "C# for food, F# for fun" developer living in Prague seeking for platform where you can come and share and exchange your knowledge, ideas, experience with F#. Place, where you can come to learn something new as advanced programmer, but also place where you don\`t have to worry about being functional programming newbie. Place, where you can say "I have absolutely no idea what Monad is." and still have fun. By learning from others, be teaching others. Sadly, place like that didn\`t exist. There were already some meetup groups like Prague lambda, but none of it was focused on F# and its usage in real life. Quite ironic for country having such skilled and famous F# programmers like Tomáš Petříček and Evelína Gabasová, isn\`t it?

Ok, this needs to change! We are programmers and what we do, if we need something? We build it! So I asked for help my friend Jirka Pénzeš (he is clojurist, but he is fine :)) experienced in organizing IT conferences and we started with first meetup setup. Finding proper place was quite easy - Prague is full of nice co-working places where you can even get fresh beer, so no problem here. We chose place called "Pracovna" which means "Working place" in Czech. Ok, we got place, now we need cool name. FSharping domain available in .com and .cz? Good, I\`ll take them both. Should we call it FSharping or F#ing? The first one is probably better - F#ing could be easily misunderstood as meetup group for quite different activity which is also fun, but for which we do not usually organize meetups (but this is Prague - you never know, maybe one day...). Ok, so we got place, we got cool name, website is prepared (written in F# on [Suave](https://suave.io), of course), hm... Is there something we forgot? Speakers! We need good speakers! I can have some talks about F#, mostly about web development, but let\`s keep it as fallback we-could-not-get-anyone-better-then-me-oh-dear option. The first kick-off should be done by someone, who is famous and respected in F# community. Someone with great presentation skills and deep F# knowledge. And possibly native Czech speaker. So if you need someone like this, who do you call?! No, no, not Ghostbusters. We called Tomáš Petříček. I can still remember his first reaction when we bashfully asked him whether he would be willing to kick-off our first meetup. He said: "If you invite me, I\`d be pleased." No conditions, no negotiations, just ok, I\`ll come? Wow! And he did!


![First meetup](https://res.cloudinary.com/dzoukr/image/upload/c_scale,q_100,w_820/v1455722399/IMG_6841_li3oqb.jpg)


So we started FSharping - F# meetup group with simple rule: *Come and learn, come and teach, everyone is welcome!*

Since Tomáš\`s amazing kick-off, we managed to have FSharping talks about:

* Introduction to F# (for C# developers) - me
* F# in production - David Podhola, Jindřich Ivánek
* Building websites in F# - me
* FSharping |> beer - summer session mostly based on drinking beer and talking about F# (Prague is ghost city during July and August so we kept serious topics for autumn)
* Actor model and distributed applications in F# - David Podhola
* Options modeling, pricing and vizualization with F#, Fable and D3 - Jan Fajfr

And also "external" talks about F# (for companies and other meetup groups):

* Why is F# cool? - Hewlett Packard Enterprise (HPE)
* [Introduction into F#](http://https://www.facebook.com/events/1294865500541821/) - Google Developer Groups Pardubice
* Introduction into F# - CN Group CZ
* [UI Automation Hints](http://https://www.meetup.com/TopMonks-Caffe/events/235151244/) - TopMonks Caffè
* [Why is F# cool?](http://http://d3s.mff.cuni.cz/teaching/commercial_workshops/?popup=zs1617_cngroup#popup_zs1617_cngroup) - Faculty of Mathematics and Physics at Charles University in Prague


![Suave meetup](https://res.cloudinary.com/dzoukr/image/upload/c_scale,q_100,w_820/v1481610430/fsharping_suave.jpg)


Already planned for Q1 2017:

* Railway Oriented Programming
* WPF UI Testing Automation with F#

Just looking at the list of past talks makes me happy. We did it! We took language we love (mostly me, Jirka loves Clojure, but he is still fine :)), combined it with *no smart jerks, just fun* approach and guess what - it works! And I feel it will be even better in 2017.

So what\`s the moral of this story? To praise ourselves? Hell no! That\`s not the point of our work and never was. What I only wanted to say to the F# world is that there is a nice evolving F# community in Czech Republic that can be taken into account if somebody thinking about organizing some big F# conference in Prague (fingers crossed). And that doing something that makes you happy sometimes brings interesting unexpected side effects (I know we all hate them, but let\`s pretend side effects are rainbow pooping kittens for now) to your life. Few examples:

* I met more extra-smart people during last year than in maybe 4 years before.
* One of the FSharping member told me after last meetup: "Man, thanks to these meetups I can use F# in our company without fear. Now I know somebody use F# as well and we can share and exchange knowledge. I thought F# was for geeks and now I see it is great for daily SW development."
* Some of us removed the dust of presentation skills and started to have public talks again.
* Based on being FSharping group leader, I got "an offer one can\`t refuse". I became fulltime F# developer with duties like spreading knowledge about F# in our company as well as for our customers. Evangelization and getting F# team bigger is one my top responsibilities. Yeap, you read it right. What I did for fun (and no profit) now became profit (with still a lot of fun).
* Gathering examples of real life production usage makes "selling" F# to own customers much easier. E.g. UI testing of one of the crucial applications for  one of the world\`s largest ferry operators is performed fully in F# (something like Canopy, but for WPF apps). Good topic for some of next meetups.
* I am enjoying programming more than ever before. Working on new F# libraries and still trying to learn something new from work of others (mostly reading their code on GitHub).

Ok, so, how should I end this codeless blogpost? I\`d like to give my thanks to few people and because it is advent blogpost, so maybe I could make a wish? Ok.

All FSharping members and speakers - without you, whole meetup would be meaningless. Thanks again and looking forward to see you all in 2017!
Jirka Pénzeš - dude, without your help, there would be no FSharping. Cannot thank enough!
Don Syme - thanks for creating and still keeping eye on such a great language.
Scott Wlaschin - as I already said over Slack: Your F# for fun & profit is still bible for all of us. Thanks for that and for the [book](https://https://www.gitbook.com/book/swlaschin/fsharpforfunandprofit/details).
Tomáš and Evelína - I always enjoy having burger, beer and chat with you even if I sometimes don\`t have a clue, what the hell are you talking about. :) Thanks for supporting us from the very beginning.
Krzysztof, Ademar, Henrik, Steffen, Alfonso, Tomasz and all other great F# OSS contributors - whole F# community stands on your shoulders. Thanks for making them strong!

I wish you all Merry Christmas and a lot of **F#un** in 2017!