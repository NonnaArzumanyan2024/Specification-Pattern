using SimpleSpecification.Models;
using SimpleSpecification.Specifications;

namespace SimpleSpecification.Services;

public class ProductService
{
    private readonly ISpecification<Product> _specification;

    public ProductService(ISpecification<Product> specification)
    {
        _specification = specification;
    }

    public List<Product> GetProducts(List<Product> products)
    {
        var result = new List<Product>();

        foreach (var product in products)
        {
            if (_specification.IsSatisfiedBy(product))
            {
                result.Add(product);
            }
        }

        return result;
    }
}