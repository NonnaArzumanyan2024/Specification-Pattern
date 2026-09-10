namespace SimpleSpecification.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T item);
}