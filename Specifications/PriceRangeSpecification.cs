using SimpleSpecification.Models;

namespace SimpleSpecification.Specifications;

public class PriceRangeSpecification : ISpecification<Product>
{
    private readonly decimal _minPrice;
    private readonly decimal _maxPrice;

    public PriceRangeSpecification(decimal minPrice, decimal maxPrice)
    {
        _minPrice = minPrice;
        _maxPrice = maxPrice;
    }

    public bool IsSatisfiedBy(Product product)
    {
        return product.Price >= _minPrice &&
               product.Price <= _maxPrice;
    }
}