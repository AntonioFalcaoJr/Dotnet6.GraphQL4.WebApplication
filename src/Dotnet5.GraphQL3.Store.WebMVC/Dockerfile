ARG ASPNET_VERSION="5.0.0-rc.1-alpine3.12"
ARG SDK_VERSION="5.0.100-rc.1-alpine3.12"
ARG BASE_ADRESS="mcr.microsoft.com/dotnet"

FROM $BASE_ADRESS/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 7000

FROM $BASE_ADRESS/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Dotnet5.GraphQL3.Store.WebMVC/*.csproj ./Dotnet5.GraphQL3.Store.WebMVC/

COPY ./NuGet.Config ./
COPY ./Directory.Build.props ./

RUN dotnet restore ./Dotnet5.GraphQL3.Store.WebMVC

COPY ./src/Dotnet5.GraphQL3.Store.WebMVC/. ./Dotnet5.GraphQL3.Store.WebMVC/

WORKDIR /src/Dotnet5.GraphQL3.Store.WebMVC
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet5.GraphQL3.Store.WebMVC.dll"]