FROM        fsharp/fsharp
MAINTAINER  Roman Provaznik <dzoukr@dzoukr.cz>
			
ADD ./build/app/ app/
EXPOSE 8083
ENTRYPOINT ["mono", "/app/FSharping.Website.exe"]