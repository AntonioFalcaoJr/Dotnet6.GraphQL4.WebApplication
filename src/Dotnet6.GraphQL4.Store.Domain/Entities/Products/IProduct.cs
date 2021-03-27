using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products
{
    public interface IProduct
    {
        void AddReview(Review review);
    }
}