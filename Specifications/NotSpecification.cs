using SimpleSpecification.Models;

namespace SimpleSpecification.Specifications;

public class NotSpecification : ISpecification<Product>
{
    private readonly ISpecification<Product> _specification;

    public NotSpecification(ISpecification<Product> specification)
    {
        _specification = specification;
    }

    public bool IsSatisfiedBy(Product product)
    {
        return !_specification.IsSatisfiedBy(product);
    }
}