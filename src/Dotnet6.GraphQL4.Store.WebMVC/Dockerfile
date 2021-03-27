ARG ASPNET_VERSION="6.0.0-preview.2-alpine3.13"
ARG SDK_VERSION="6.0.100-preview.2-alpine3.13"
ARG BASE_ADRESS="mcr.microsoft.com/dotnet"

FROM $BASE_ADRESS/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 7000

FROM $BASE_ADRESS/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Dotnet6.GraphQL4.Store.WebMVC/*.csproj ./Dotnet6.GraphQL4.Store.WebMVC/

COPY ./NuGet.Config ./
COPY ./Directory.Build.props ./

RUN dotnet restore ./Dotnet6.GraphQL4.Store.WebMVC

COPY ./src/Dotnet6.GraphQL4.Store.WebMVC/. ./Dotnet6.GraphQL4.Store.WebMVC/

WORKDIR /src/Dotnet6.GraphQL4.Store.WebMVC
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet6.GraphQL4.Store.WebMVC.dll"]