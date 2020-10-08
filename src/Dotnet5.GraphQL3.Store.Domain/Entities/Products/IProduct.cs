using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products
{
    public interface IProduct
    {
        void AddReview(Review review);
    }
}