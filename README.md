# Dotnet5.GraphQL.CleanArchitecture

This project exemplify the implementation of a simple Razor Web APP MVC Core consuming an full **GraphQL** Web API, build in a **.NET 5** multi-layer  project, considering development best practices, like **SOLID** and **DRY**, applying **Domain-Driven** concepts in a **Clean Architecture**.

### Configuration

#### Secrets

To configure database resource, Init secrets in [`./src/Dotnet5.GraphQL.Store.WebAPI`](./src/Dotnet5.GraphQL.Store.WebAPI)

```bash
dotnet user-secrets init
```
Then, define the `DefaultConnection`: 
```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=Store;User=sa;Password=!MyComplexPassword"
```

Or, if your prefer, is possible to define it on [`appsettings.json`](./src/Dotnet5.GraphQL.Store.WebAPI/appsettings.json)

#### AppSettings

```json5
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=Store;User=sa;Password=!MyComplexPassword"
  }
}

```

## Query

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
      "rating": -1864067132,
      "description": "Deleniti voluptas quidem accusamus est debitis quisquam enim."
    },
    "Second": {
      "id": "65af82e8-27f6-44f3-af4a-029b73f14530",
      "name": "debitis",
      "rating": 1764562021,
      "description": "Est veniam unde."
    }
  }
}
```

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

HTTP Body

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

HTTP Body

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
## Built With

### Microsoft Stack

* [.NET 5.0 (preview 8)](https://dotnet.microsoft.com/) - Base framework;
* [ASP.NET 5.0 (preview 8)](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - Web framework;
* [Entity Framework Core 5.0 (preview 7)](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/plan) - ORM.

#### GraphQL Stack

* [GraphQL](https://graphql.org/) - GraphQL is a query language for APIs and a runtime for fulfilling those queries with data;
* [GraphQL for .NET 3.0 (preview 1719)](https://github.com/graphql-dotnet/graphql-dotnet/) - This is an implementation of GraphQL in .NET;
* [GraphQL.Client 3.1.5](https://github.com/graphql-dotnet/graphql-client) - A GraphQL Client for .NET over HTTP;
* [GraphQL Playground 3.5 (alpha 0073)](https://github.com/prisma-labs/graphql-playground/) - GraphQL IDE for better development workflows.

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