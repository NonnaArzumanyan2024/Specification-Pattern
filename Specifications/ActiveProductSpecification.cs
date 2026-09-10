using SimpleSpecification.Models;

namespace SimpleSpecification.Specifications;

public class ActiveProductSpecification : ISpecification<Product>
{
    public bool IsSatisfiedBy(Product product)
    {
        return product.IsActive;
    }
}