using SimpleSpecification.Models;

namespace SimpleSpecification.Specifications;

public class OrSpecification : ISpecification<Product>
{
    private readonly ISpecification<Product> _left;
    private readonly ISpecification<Product> _right;

    public OrSpecification(
        ISpecification<Product> left,
        ISpecification<Product> right)
    {
        _left = left;
        _right = right;
    }

    public bool IsSatisfiedBy(Product product)
    {
        return _left.IsSatisfiedBy(product) ||
               _right.IsSatisfiedBy(product);
    }
}