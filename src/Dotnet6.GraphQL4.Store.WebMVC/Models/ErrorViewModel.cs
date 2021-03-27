using System.Collections.Generic;

namespace Dotnet6.GraphQL4.Store.WebMVC.Models
{
    public class ErrorViewModel
    {
        public List<string> Erros { get; set; }
        public string RequestId { get; init; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}