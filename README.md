# Dotnet5.GraphQL.CleanArchitecture

This project exemplify the implementation of a simple Razor Web APP MVC Core consuming an full **GraphQL** Web API, build in a **.NET 5** multi-layer  project, considering development best practices, like **SOLID** and **DRY**, applying **Domain-Driven** concepts in a **Clean Architecture**.

![CI](https://github.com/AntonioFalcao/Dotnet5.GraphQL.WebApplication/workflows/CI/badge.svg?branch=master)
![WebAPI Docker Image](https://github.com/AntonioFalcao/Dotnet5.GraphQL.WebApplication/workflows/WebAPI%20Docker%20Image/badge.svg?branch=master)
![WebMVC Docker Image](https://github.com/AntonioFalcao/Dotnet5.GraphQL.WebApplication/workflows/WebMVC%20Docker%20Image/badge.svg?branch=master)

---

## Environment configuration

### Development

##### Secrets

To configure database resource, `init` secrets in [`./src/Dotnet5.GraphQL.Store.WebAPI`](./src/Dotnet5.GraphQL.Store.WebAPI), and then define the `DefaultConnection`: 

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=Store;User=sa;Password=!MyComplexPassword"
```

After this, to configure the HTTP client, `init` secrets in [`./src/Dotnet5.GraphQL.Store.WebMVC`](./src/Dotnet5.GraphQL.Store.WebMVC) and define **Store** client host:

```bash
dotnet user-secrets init
dotnet user-secrets set "HttpClient:Store" "http://localhost:5000/graphql"
```

##### AppSettings 

If you prefer, is possible to define it on WebAPI [`appsettings.Development.json`](./src/Dotnet5.GraphQL.Store.WebAPI/appsettings.Development.json) and WebMVC [`appsettings.Development.json`](./src/Dotnet5.GraphQL.Store.WebMVC/appsettings.Development.json) files:

WebAPI

```json5
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=Store;User=sa;Password=!MyComplexPassword"
  }
}
```

WebMCV

```json5
{
  "HttpClient": {
    "Store": "http://localhost:5000/graphql"
  }
}
```
___

### Production

Considering use Docker for CD (Continuous Deployment). On respective [compose](./docker-compose.yml) both web applications and sql server are in the same network, and then we can use named hosts. Already defined on WebAPI [`appsettings.json`](./src/Dotnet5.GraphQL.Store.WebAPI/appsettings.json) and WebMVC [`appsettings.json`](./src/Dotnet5.GraphQL.Store.WebMVC/appsettings.json) files:   

##### AppSettings 

WebAPI

```json5
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=mssql;Database=Store;User=sa;Password=!MyComplexPassword"
  }
}
```

WebMCV

```json5
{
  "HttpClient": {
    "Store": "http://webapi:5000/graphql"
  }
}
```
___

## Running

The [`./docker-compose.yml`](./docker-compose.yml) provide the `WebAPI`, `WebMVC` and `MS SQL Server` applications:

```bash
docker-compose up -d
``` 

## GraphQL Playground 

By default,**Playground** respond at `http://localhost:5000/ui/playground`, but is possible configure the host and many others details in [`../...WebAPI/GraphQL/DependencyInjection/Configure.cs`](./src/Dotnet5.GraphQL.Store.WebAPI/GraphQL/DependencyInjection/Configure.cs)

```c#
app.UseGraphQLPlayground(
    new GraphQLPlaygroundOptions
    {
        Path = "/ui/playground",
        BetaUpdates = true,
        RequestCredentials = RequestCredentials.Omit,
        HideTracingResponse = false,

        EditorCursorShape = EditorCursorShape.Line,
        EditorTheme = EditorTheme.Dark,
        EditorFontSize = 14,
        EditorReuseHeaders = true,
        EditorFontFamily = "JetBrains Mono"
    });
```

## Queries

#### Fragment for comparison and Arguments

QUERY

```markdown
{
  First: product(id: "2c05b59b-8fb3-4cba-8698-01d55a0284e5") {
    ...comparisonFields
  }
  Second: product(id: "65af82e8-27f6-44f3-af4a-029b73f14530") {
    ...comparisonFields
  }
}

fragment comparisonFields on Product {
  id
  name
  rating
  description
}
```

RESULT

```json5
{
  "data": {
    "First": {
      "id": "2c05b59b-8fb3-4cba-8698-01d55a0284e5",
      "name": "libero",
      "rating": 5,
      "description": "Deleniti voluptas quidem accusamus est debitis quisquam enim."
    },
    "Second": {
      "id": "65af82e8-27f6-44f3-af4a-029b73f14530",
      "name": "debitis",
      "rating": 10,
      "description": "Est veniam unde."
    }
  }
}
```
___
#### Query named's and Variables


QUERY

```markdown
query all {
  products {
    id
    name
  }
}

query byid($productId: ID!) {
  product(id: $productId) {
    id
    name
  }
}
```

VARIABLES

```json5
{
  "productId": "2c05b59b-8fb3-4cba-8698-01d55a0284e5"
}
```

HTTP BODY

```markdown
{
    "operationName": "byid",
    "variables": {
        "productId": "2c05b59b-8fb3-4cba-8698-01d55a0284e5"
    },
    "query": "query all {
        products {
          id
          name
        }
    }
    query byid($productId: ID!) {
        product(id: $productId) {
          id
          name
        }
    }"
}
```

PLAYGROUND

![queries](./.assets/img/queries.PNG) 
___
#### Variables with include, skip and default value

QUERY

```markdown
query all($showPrice: Boolean = false) {
  products {
    id
    name
    price @include(if: $showPrice)
    rating @skip(if: $showPrice)
  }
}
```

VARIABLES

```json5
{
  "showPrice": true
}
```

HTTP BODY

```markdown
{
    "operationName": "all",
    "variables": {
        "showPrice": false
    },
    "query": "query all($showPrice: Boolean = false) {
          products {
            id
            name
            price @include(if: $showPrice)
            rating @skip(if: $showPrice)
          }
    }"
}
```
___

## Mutations

MUTATION

```markdown
mutation($review: reviewInput!) {
  createReview(review: $review) {
    id
  }
}
```
VARIABLES

```json5
{
  "review": {
    "title": "some title",
    "comment": "some comment",
    "productId": "0fb8ec7e-7af1-4fe3-a2e2-000996ffd20f"
  }
}
```

## Built With

### Microsoft Stack - v5.0 (preview 8)

* [.NET 5.0](https://dotnet.microsoft.com/) - Base framework;
* [ASP.NET 5.0](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - Web framework;
* [Entity Framework Core 5.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/plan) - ORM;
* [Microsoft SQL Server on Linux for Docker](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/plan) - Database.

### GraphQL Stack - v3.0 (preview / alpha)

* [GraphQL](https://graphql.org/) - GraphQL is a query language for APIs and a runtime for fulfilling those queries with data;
* [GraphQL for .NET](https://github.com/graphql-dotnet/graphql-dotnet/) - This is an implementation of GraphQL in .NET;
* [GraphQL.Client](https://github.com/graphql-dotnet/graphql-client) - A GraphQL Client for .NET over HTTP;
* [GraphQL Playground](https://github.com/prisma-labs/graphql-playground/) - GraphQL IDE for better development workflows.

#### Community Stack

* [AutoMapper](https://automapper.org/) - A convention-based object-object mapper;
* [FluentValidation](https://fluentvalidation.net/) - A popular .NET library for building strongly-typed validation rules;
* [Bogus](https://github.com/bchavez/Bogus) - A simple and sane fake data generator for C#, F#, and VB.NET.

## Contributing

Available soon!

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/AntonioFalcao/Dotnet5.GraphQL.WebApplication/tags).

## Authors

* **Antônio Falcão** - [GitHub](https://github.com/AntonioFalcao)

> See also the list of [contributors](https://github.com/AntonioFalcao/Dotnet5.GraphQL.WebApplication/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details

## Acknowledgments

* Nothing more, for now.
