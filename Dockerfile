FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore BuildAPI.csproj

RUN dotnet publish BuildAPI.csproj -c Release -o /app/publish

FROM base
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BuildAPI.dll"]