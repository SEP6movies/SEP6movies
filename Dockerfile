
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["SEP6-movies.csproj", "./"]
RUN dotnet restore "SEP6-movies.csproj"
COPY . .
WORKDIR "/src/SEP6-movies"
RUN dotnet build "SEP6-movies.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SEP6-movies.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SEP6-movies.dll"]
