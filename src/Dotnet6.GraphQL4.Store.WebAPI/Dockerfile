ARG ASPNET_VERSION="6.0.0-preview.2-alpine3.13"
ARG SDK_VERSION="6.0.100-preview.2-alpine3.13"
ARG BASE_ADRESS="mcr.microsoft.com/dotnet"

FROM $BASE_ADRESS/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 5000

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM $BASE_ADRESS/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Dotnet6.GraphQL4.CrossCutting/*.csproj ./Dotnet6.GraphQL4.CrossCutting/
COPY ./src/Dotnet6.GraphQL4.Domain.Abstractions/*.csproj ./Dotnet6.GraphQL4.Domain.Abstractions/
COPY ./src/Dotnet6.GraphQL4.Repositories.Abstractions/*.csproj ./Dotnet6.GraphQL4.Repositories.Abstractions/
COPY ./src/Dotnet6.GraphQL4.Services.Abstractions/*.csproj ./Dotnet6.GraphQL4.Services.Abstractions/

COPY ./src/Dotnet6.GraphQL4.Store.Domain/*.csproj ./Dotnet6.GraphQL4.Store.Domain/
COPY ./src/Dotnet6.GraphQL4.Store.Repositories/*.csproj ./Dotnet6.GraphQL4.Store.Repositories/
COPY ./src/Dotnet6.GraphQL4.Store.Services/*.csproj ./Dotnet6.GraphQL4.Store.Services/
COPY ./src/Dotnet6.GraphQL4.Store.WebAPI/*.csproj ./Dotnet6.GraphQL4.Store.WebAPI/

COPY ./NuGet.Config ./
COPY ./Directory.Build.props ./

RUN dotnet restore ./Dotnet6.GraphQL4.Store.WebAPI

COPY ./src/Dotnet6.GraphQL4.CrossCutting/. ./Dotnet6.GraphQL4.CrossCutting/
COPY ./src/Dotnet6.GraphQL4.Domain.Abstractions/. ./Dotnet6.GraphQL4.Domain.Abstractions/
COPY ./src/Dotnet6.GraphQL4.Repositories.Abstractions/. ./Dotnet6.GraphQL4.Repositories.Abstractions/
COPY ./src/Dotnet6.GraphQL4.Services.Abstractions/. ./Dotnet6.GraphQL4.Services.Abstractions/

COPY ./src/Dotnet6.GraphQL4.Store.Domain/. ./Dotnet6.GraphQL4.Store.Domain/
COPY ./src/Dotnet6.GraphQL4.Store.Repositories/. ./Dotnet6.GraphQL4.Store.Repositories/
COPY ./src/Dotnet6.GraphQL4.Store.Services/. ./Dotnet6.GraphQL4.Store.Services/
COPY ./src/Dotnet6.GraphQL4.Store.WebAPI/. ./Dotnet6.GraphQL4.Store.WebAPI/

WORKDIR /src/Dotnet6.GraphQL4.Store.WebAPI
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet6.GraphQL4.Store.WebAPI.dll"]