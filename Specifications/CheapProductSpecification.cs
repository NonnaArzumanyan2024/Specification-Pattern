using SimpleSpecification.Models;

namespace SimpleSpecification.Specifications;

public class CheapProductSpecification : ISpecification<Product>
{
    public bool IsSatisfiedBy(Product product)
    {
        return product.Price <= 10000;
    }
}