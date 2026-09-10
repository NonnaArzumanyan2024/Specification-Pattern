using SimpleSpecification.Models;

namespace SimpleSpecification.Specifications;

public class InactiveProductSpecification : ISpecification<Product>
{
    public bool IsSatisfiedBy(Product product)
    {
        return !product.IsActive;
    }
}