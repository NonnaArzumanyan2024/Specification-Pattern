using SimpleSpecification.Models;

namespace SimpleSpecification.Specifications;

public class ExpensiveProductSpecification : ISpecification<Product>
{
    public bool IsSatisfiedBy(Product product)
    {
        return product.Price > 100000;
    }
}