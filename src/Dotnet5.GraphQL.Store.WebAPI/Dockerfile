ARG ASPNET_VERSION="5.0-buster-slim"
ARG SDK_VERSION="5.0-buster-slim"

FROM mcr.microsoft.com/dotnet/core/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Dotnet5.GraphQL.Store.Domain/*.csproj ./Dotnet5.GraphQL.Store.Domain/
COPY ./src/Dotnet5.GraphQL.Store.Repositories/*.csproj ./Dotnet5.GraphQL.Store.Repositories/
COPY ./src/Dotnet5.GraphQL.Store.Services/*.csproj ./Dotnet5.GraphQL.Store.Services/
COPY ./src/Dotnet5.GraphQL.Store.WebAPI/*.csproj ./Dotnet5.GraphQL.Store.WebAPI/

COPY ./NuGet.Config ./
COPY ./Directory.Build.props ./
RUN dotnet restore ./Dotnet5.GraphQL.Store.WebAPI

COPY ./src/Dotnet5.GraphQL.Store.Domain/. ./Dotnet5.GraphQL.Store.Domain/
COPY ./src/Dotnet5.GraphQL.Store.Repositories/. ./Dotnet5.GraphQL.Store.Repositories/
COPY ./src/Dotnet5.GraphQL.Store.Services/. ./Dotnet5.GraphQL.Store.Services/
COPY ./src/Dotnet5.GraphQL.Store.WebAPI/. ./Dotnet5.GraphQL.Store.WebAPI/

WORKDIR /src/Dotnet5.GraphQL.Store.WebAPI
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet5.GraphQL.Store.WebAPI.dll"]