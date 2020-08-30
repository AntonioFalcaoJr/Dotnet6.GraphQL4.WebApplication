ARG ASPNET_VERSION="5.0-alpine"
ARG SDK_VERSION="5.0-alpine"

FROM mcr.microsoft.com/dotnet/core/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 7000

FROM mcr.microsoft.com/dotnet/core/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Dotnet5.GraphQL.Store.WebMVC/*.csproj ./Dotnet5.GraphQL.Store.WebMVC/

COPY ./NuGet.Config ./
COPY ./Directory.Build.props ./

RUN dotnet restore ./Dotnet5.GraphQL.Store.WebMVC

COPY ./src/Dotnet5.GraphQL.Store.WebMVC/. ./Dotnet5.GraphQL.Store.WebMVC/

WORKDIR /src/Dotnet5.GraphQL.Store.WebMVC
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet5.GraphQL.Store.WebMVC.dll"]