FROM         iron/mono
MAINTAINER  Roman Provaznik <dzoukr@dzoukr.cz>

ENV MONO_THREADS_PER_CPU 2000
			
ADD ./build/app/ app/
EXPOSE 8083
WORKDIR ./app/
ENTRYPOINT ["mono", "FSharping.Website.exe"]
