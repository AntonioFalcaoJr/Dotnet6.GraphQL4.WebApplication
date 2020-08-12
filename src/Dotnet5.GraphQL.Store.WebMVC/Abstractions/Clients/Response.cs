using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet5.GraphQL.Store.WebMVC.Abstractions.Clients
{
    public class Response<T>
    {
        public Response()
        {
            Errors = new List<string>();
            Results = new List<T>();
        }

        public List<string> Errors { get; set; }

        public bool IsValid => Errors?.Any() ?? false;

        public List<T> Results { get; set; }

        public void HandleErrors()
        {
            if (Errors?.Any() ?? false) throw new Exception($"Message: {string.Join(" , ", Errors.Select(x => x))}");
        }
    }
}