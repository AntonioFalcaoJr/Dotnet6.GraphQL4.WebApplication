ARG ASPNET_VERSION="5.0.0-rc.1-alpine3.12"
ARG SDK_VERSION="5.0.100-rc.1-alpine3.12"
ARG BASE_ADRESS="mcr.microsoft.com/dotnet"

FROM $BASE_ADRESS/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 5000

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM $BASE_ADRESS/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Dotnet5.GraphQL3.CrossCutting/*.csproj ./Dotnet5.GraphQL3.CrossCutting/
COPY ./src/Dotnet5.GraphQL3.Domain.Abstractions/*.csproj ./Dotnet5.GraphQL3.Domain.Abstractions/
COPY ./src/Dotnet5.GraphQL3.Repositories.Abstractions/*.csproj ./Dotnet5.GraphQL3.Repositories.Abstractions/
COPY ./src/Dotnet5.GraphQL3.Services.Abstractions/*.csproj ./Dotnet5.GraphQL3.Services.Abstractions/

COPY ./src/Dotnet5.GraphQL3.Store.Domain/*.csproj ./Dotnet5.GraphQL3.Store.Domain/
COPY ./src/Dotnet5.GraphQL3.Store.Repositories/*.csproj ./Dotnet5.GraphQL3.Store.Repositories/
COPY ./src/Dotnet5.GraphQL3.Store.Services/*.csproj ./Dotnet5.GraphQL3.Store.Services/
COPY ./src/Dotnet5.GraphQL3.Store.WebAPI/*.csproj ./Dotnet5.GraphQL3.Store.WebAPI/

COPY ./NuGet.Config ./
COPY ./Directory.Build.props ./

RUN dotnet restore ./Dotnet5.GraphQL3.Store.WebAPI

COPY ./src/Dotnet5.GraphQL3.CrossCutting/. ./Dotnet5.GraphQL3.CrossCutting/
COPY ./src/Dotnet5.GraphQL3.Domain.Abstractions/. ./Dotnet5.GraphQL3.Domain.Abstractions/
COPY ./src/Dotnet5.GraphQL3.Repositories.Abstractions/. ./Dotnet5.GraphQL3.Repositories.Abstractions/
COPY ./src/Dotnet5.GraphQL3.Services.Abstractions/. ./Dotnet5.GraphQL3.Services.Abstractions/

COPY ./src/Dotnet5.GraphQL3.Store.Domain/. ./Dotnet5.GraphQL3.Store.Domain/
COPY ./src/Dotnet5.GraphQL3.Store.Repositories/. ./Dotnet5.GraphQL3.Store.Repositories/
COPY ./src/Dotnet5.GraphQL3.Store.Services/. ./Dotnet5.GraphQL3.Store.Services/
COPY ./src/Dotnet5.GraphQL3.Store.WebAPI/. ./Dotnet5.GraphQL3.Store.WebAPI/

WORKDIR /src/Dotnet5.GraphQL3.Store.WebAPI
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet5.GraphQL3.Store.WebAPI.dll"]