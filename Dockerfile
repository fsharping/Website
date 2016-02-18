FROM         iron/mono
MAINTAINER  Roman Provaznik <dzoukr@dzoukr.cz>

ENV MONO_THREADS_PER_CPU 50
ENV MONO_GC_PARAMS="max-heap-size=100m,soft-heap-limit=50m,major=marksweep-conc"
ENV VIRTUAL_HOST="www.fsharping.cz,fsharping.cz,www.fsharping.com,fsharping.com"
			
ADD ./build/app/ app/
EXPOSE 8083
WORKDIR ./app/
ENTRYPOINT ["mono", "FSharping.Website.exe"]
