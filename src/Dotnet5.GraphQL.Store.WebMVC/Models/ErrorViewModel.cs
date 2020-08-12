using System.Collections.Generic;

namespace Dotnet5.GraphQL.Store.WebMVC.Models
{
    public class ErrorViewModel
    {
        public List<string> Erros { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}