#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LocatorPoc.Api/LocatorPoc.Api.csproj", "LocatorPoc.Api/"]
RUN dotnet restore "LocatorPoc.Api/LocatorPoc.Api.csproj"
COPY . .
WORKDIR "/src/LocatorPoc.Api"
RUN dotnet build "LocatorPoc.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocatorPoc.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY locator-startup.sh app/locator-startup.sh
COPY --from=build /app/build ./locator-startup.sh
ENTRYPOINT ["/locator-startup.sh"]