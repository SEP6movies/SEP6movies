FROM launcher.gcr.io/google/aspnetcore:3.1
ADD ./ /app
ENV ASPNETCORE_URLS=http://*:${PORT}
WORKDIR /app
ENTRYPOINT [ "dotnet", "SEP6movies.dll" ]
