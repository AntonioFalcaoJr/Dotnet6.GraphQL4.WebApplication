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