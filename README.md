# Dotnet5.GraphQL.WebApplication


#### Secrets

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=192.168.0.27,1433;Database=Store;User=sa;Password=!MyComplexPassword"
```

OR

#### AppSettings

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=192.168.0.27,1433;Database=Store;User=sa;Password=!MyComplexPassword"
  }
}

```

## Query

#### Fragment for comparison and Arguments

*QUERY*

```json
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

*RESULT*

```json
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
```

#### Query named's and Variables

*QUERY*

```json
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

*QUERY VARIABLES*

```json
{
  "productId": "2c05b59b-8fb3-4cba-8698-01d55a0284e5"
}
```

*HTTP Body*
```json
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

*QUERY*

```json
query all($showPrice: Boolean = false) {
  products {
    id
    name
    price @include(if: $showPrice)
    rating @skip(if: $showPrice)
  }
}
```

*QUERY VARIABLES*

```json
{
  "showPrice": true
}
```

*HTTP Body*

```json
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

* [.NET 5.0](https://dotnet.microsoft.com/) - Base framework;
* [ASP.NET 5.0](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - Web framework;
* [Entity Framework Core 5.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/plan) - ORM.

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