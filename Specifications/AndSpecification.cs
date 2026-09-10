using SimpleSpecification.Models;

namespace SimpleSpecification.Specifications;

public class AndSpecification : ISpecification<Product>
{
    private readonly ISpecification<Product> _left;
    private readonly ISpecification<Product> _right;

    public AndSpecification(
        ISpecification<Product> left,
        ISpecification<Product> right)
    {
        _left = left;
        _right = right;
    }

    public bool IsSatisfiedBy(Product product)
    {
        return _left.IsSatisfiedBy(product) &&
               _right.IsSatisfiedBy(product);
    }
}