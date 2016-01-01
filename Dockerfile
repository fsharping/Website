FROM        fsharp/fsharp
MAINTAINER  Roman Provaznik <dzoukr@dzoukr.cz>
			
ADD ./build/app/ app/
EXPOSE 8083
WORKDIR ./app/
ENTRYPOINT ["mono", "FSharping.Website.exe"]